using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

namespace Request
{
    public class RequestManager
    {
        private Dictionary<string, Request> requestList;
        private Request currentRequest;
        public Room.Speechbubble speechbubble;

        public RequestManager(Room.Speechbubble bubble)
        {
            speechbubble = bubble;
            requestList = new Dictionary<string, Request>();
        }

        public void LoadRequests()
        {
            const string relativePath = "/Resources/Requests/";
            string[] filenames = Directory.GetFiles(Application.dataPath + relativePath, "*.req").Select(Path.GetFileName).ToArray();

            foreach (string file in filenames)
            {
                StreamReader sr = new StreamReader(Application.dataPath + relativePath + file);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Request r = new Request(speechbubble);
                    r.Initialize(line);
                    requestList.Add(r.attributes[RequestAttribute.ID], r);
                }
            }
        }

        public void ShowStart()
        {
            Request startingRequest;
            if (requestList.TryGetValue("_START_", out startingRequest))
            {
                currentRequest = startingRequest;
                startingRequest.Occur();
            }
            else
            {
                Debug.LogError("Loaded requests contain no _START_ ID");
            }
        }

        public void handleNext()
        {
            if (speechbubble.IsReady())
            {
                if (!currentRequest.Next())
                {
                    ChooseRequest();
                }
            }
        }

        public void handleYes()
        {
            if (speechbubble.IsReady())
            {
                if (!currentRequest.AnswerYes())
                {
                    ChooseRequest();
                }
            }
        }

        public void handleNo()
        {
            if (speechbubble.IsReady())
            {
                if (!currentRequest.AnswerNo())
                {
                    ChooseRequest();
                }
            }
        }

        private void ChooseRequest()
        {
            int max = 0;
            foreach (Request r in requestList.Values)
            {
                max += int.Parse(r.attributes[RequestAttribute.SelectionChance]);
            }

            int selection = Random.Range(0, max);

            Debug.Log("Randomly choosing value " + selection.ToString() + " from a max of " + max.ToString());

            foreach (Request r in requestList.Values)
            {
                selection -= int.Parse(r.attributes[RequestAttribute.SelectionChance]);

                if (selection < 0)
                {
                    currentRequest = r;
                    r.Occur();
                    break;
                }
            }
        }
    }
}
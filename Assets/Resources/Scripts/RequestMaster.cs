using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

namespace Request
{
    public class RequestMaster
    {
        private Dictionary<string, Request> requestList;
        public Room.Speechbubble speechbubble;

        public RequestMaster()
        {
            requestList = new Dictionary<string, Request>();
        }

        public void LoadRequests()
        {
            string[] filenames = Directory.GetFiles("Resources/", "*.req").Select(Path.GetFileName).ToArray();

            foreach (string file in filenames)
            {
                StreamReader sr = new StreamReader(file);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Request r = new Request(speechbubble);
                    r.Initialize(line);
                    requestList.Add(r.attributes[RequestAttribute.ID], r);
                }
            }
        }

        public void ChooseRequest()
        {
            int max = 0;
            foreach (Request r in requestList.Values)
            {
                max += int.Parse(r.attributes[RequestAttribute.SelectionChance]);
            }

            int selection = Random.Range(0, max);

            foreach (Request r in requestList.Values)
            {
                max -= int.Parse(r.attributes[RequestAttribute.SelectionChance]);

                if (max <= 0)
                {
                    r.Occur();
                    break;
                }
            }
        }
    }
}
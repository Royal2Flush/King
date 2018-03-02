using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Request
{
    public enum RequestAttribute { ID, Character, SelectionChance };

    public class Request
    {
        private Room.Speechbubble speechBubble;
        public Dictionary<RequestAttribute, string> attributes { get; private set; }
        private Dictionary<string, Speech> speechList;
        private bool initialized = false;

        public Request(Room.Speechbubble speechBubble)
        {
            this.speechBubble = speechBubble;

            speechList = new Dictionary<string, Speech>();
        }

        public void Initialize(string requestString)
        {
            ParseAttributes(requestString);
            initialized = true;
        }

        public int Occur()
        {
            if (!initialized)
            {
                Debug.LogError(attributes[RequestAttribute.ID] + " not initialized before used!");
                return 1;
            }
            Speech startingStatement;
            if (speechList.TryGetValue("_START_", out startingStatement))
            {
                startingStatement.Show();
            }
            else
            {
                Debug.LogError(attributes[RequestAttribute.ID] + " contains no _START_ ID");
            }

            return 0;
        }

        private void ParseAttributes(string requestString)
        {
            string[] parts = requestString.Split('|');

            if (parts.Length < 4)
            {
                Debug.LogError("Speech initialized with " + parts.Length.ToString() + ", but expected at least 4!");
            }

            attributes.Add(RequestAttribute.ID, parts[0]);
            attributes.Add(RequestAttribute.Character, parts[1]);
            try
            {
                int.Parse(parts[2]);
                attributes.Add(RequestAttribute.SelectionChance, parts[2]);
            }
            catch
            {
                Debug.LogError("SelectionChance of request " + attributes[RequestAttribute.ID] + " is non-Integer. Using 0.");
                attributes.Add(RequestAttribute.SelectionChance, "0");
            }
            

            foreach (string speechString in HelperFuctions.SliceArray<string>(parts, 3, -1))
            {
                switch (speechString[0])
                {
                    case 'S':
                        Statement s = new Statement(speechBubble);
                        s.Initialize(speechString);
                        speechList.Add(s.attributes[SpeechAttribute.ID], s);
                        break;
                    case 'D':
                        Decision d = new Decision(speechBubble);
                        d.Initialize(speechString);
                        speechList.Add(d.attributes[SpeechAttribute.ID], d);
                        break;
                    default:
                        Debug.LogError("Speech in Request " + attributes[RequestAttribute.ID] + " has invalid ID");
                        break;
                }
            }
        }
    }
}
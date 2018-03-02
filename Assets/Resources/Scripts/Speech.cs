using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Request
{
    public enum SpeechAttribute { ID, BubbleText, LinksToID, OnYes, OnNo};

    public abstract class Speech
    {
        public Dictionary<SpeechAttribute, string> attributes { get; protected set; }
        protected Room.Speechbubble speechBubble;
        protected bool initialized = false;

        public Speech(Room.Speechbubble speechBubble)
        {
            attributes = new Dictionary<SpeechAttribute, string>();
            this.speechBubble = speechBubble;
        }

        public virtual void Initialize(string attributeString)
        {
            ParseAttributes(attributeString);
            initialized = true;
        }

        public int Show()
        {
            if (!initialized)
            {
                Debug.LogError(attributes[SpeechAttribute.ID] + " not initialized before used!");
                return 1;
            }

            return 0;
        }

        protected virtual string[] ParseAttributes(string attributeString)
        { 
            string[] parts = attributeString.Split('^');

            if (parts.Length < 3)
            {
                Debug.LogError("Speech initialized with " + parts.Length.ToString() + ", but expected at least 3!");
            }

            // parts[0] is the S or D to differentiate between Statement and Decision
            attributes.Add(SpeechAttribute.ID, parts[1]);
            attributes.Add(SpeechAttribute.BubbleText, parts[2]);

            string[] unusedParts = HelperFuctions.SliceArray<string>(parts, 3, -1);
            return unusedParts;
        }  
    }
}
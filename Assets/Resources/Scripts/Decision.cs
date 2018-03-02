using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Request
{
    public class Decision : Speech
    {
        private Answer Yes;
        private Answer No;

        public Decision(Room.Speechbubble speechBubble) : base(speechBubble)
        {
            
        }

        public override void Initialize(string attributeString)
        {
            base.Initialize(attributeString);

            Yes = new Answer(attributes[SpeechAttribute.OnYes]);
            No = new Answer(attributes[SpeechAttribute.OnNo]);
        }

        protected override string[] ParseAttributes(string attributeString)
        {
            string[] decisionParts = base.ParseAttributes(attributeString);

            if (decisionParts.Length < 2)
            {
                Debug.LogError("Speech initialized with " + decisionParts.Length.ToString() + ", but expected at least 2!");
            }

            attributes.Add(SpeechAttribute.OnYes, decisionParts[0]);
            attributes.Add(SpeechAttribute.OnNo, decisionParts[1]);

            string[] unusedParts = HelperFuctions.SliceArray<string>(decisionParts, 2, -1);
            return unusedParts;
        }   
    }
}
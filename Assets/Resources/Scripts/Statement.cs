using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Request
{
    public class Statement : Speech
    {
        public Statement(Room.Speechbubble speechBubble) : base(speechBubble)
        {

        }

        public override void Initialize(string attributeString)
        {
            base.Initialize(attributeString);
        }

        protected override string[] ParseAttributes(string attributeString)
        {
            string[] decisionParts = base.ParseAttributes(attributeString);

            if (decisionParts.Length < 1)
            {
                Debug.LogError("Speech initialized with " + decisionParts.Length.ToString() + ", but expected at least 1!");
            }

            attributes.Add(SpeechAttribute.LinksToID, decisionParts[0]);

            string[] unusedParts = HelperFuctions.SliceArray<string>(decisionParts, 2, -1);
            return unusedParts;
        }
    }
}
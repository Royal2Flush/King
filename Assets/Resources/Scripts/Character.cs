using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public enum CharacterState { away, idle, coming, talking, leaving }

    public class Character : MonoBehaviour
    {
        public CharacterState state;
        public string ID;
        public List<string> groupIDs;
        private int happiness;

        void Start()
        {
            state = CharacterState.away;
        }

        void Update()
        {
            switch (state)
            {
                case CharacterState.away:
                    break;
                case CharacterState.idle:
                    break;
                case CharacterState.coming:
                    Come();
                    break;
                case CharacterState.leaving:
                    Retreat();
                    break;
                case CharacterState.talking:
                    Talk();
                    break;
                default:
                    break;
            }
        }

        public void arrive()
        {
            if (state == CharacterState.away)
            {
                Debug.Log(ID + " arriving");
            }
            else
            {
                Debug.LogError(ID + " tries to arrive but is already here!");
            }
        }

        public void changeHappiness(int value)
        {
            happiness += value;
        }

        private void Come()
        {

        }

        private void Retreat()
        {

        }

        private void Talk()
        {

        }
    }
}
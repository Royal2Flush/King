using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        public static Dictionary<string, Character> characterDict;
        public static Dictionary<string, List<Character>> characterGroupDict;

        public string ID;
        public List <string> groupIDs;
        public int happiness;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void changeHappiness(int value)
        {
            happiness += value;
        }
    }
}
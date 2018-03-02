using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {

        public Room.Speechbubble bubble;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("right"))
            {
                bubble.Show("Hello World");
            }
            if (Input.GetKeyDown("left"))
            {
                bubble.Hide();
            }
        }

    }
}
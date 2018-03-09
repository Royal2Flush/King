using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public Room.Speechbubble speechbubble;

        private Request.RequestManager rm;

        void Start()
        {
            rm = new Request.RequestManager(speechbubble);
            rm.LoadRequests();
            rm.ShowStart();
        }

        void Update()
        {
            if(Input.GetKeyDown("up"))
            {
                rm.handleNext();
            }
            if(Input.GetKeyDown("right"))
            {
                rm.handleYes();
            }
            if (Input.GetKeyDown("left"))
            {
                rm.handleNo();
            }
        }

    }
}
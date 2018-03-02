using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Room
{

    public enum bubbleState { idle, appearing, there, disappearing };

    public class Speechbubble : MonoBehaviour
    {

        public Text requestText;

        private const float minScale = 0.001f;
        private const float scaleTime = 10f;
        private Vector3 nativeScale;
        private Vector3 idleScale;

        private float thereStartTime;
        private const float wobbleTime = 0.2f; // x 2 pi
        private const float wobbleScale = 0.02f;

        private bubbleState state;

        void Start()
        {
            if (requestText == null) // we forgot to set it in Unity
            {
                requestText = gameObject.GetComponentInChildren<Text>();
            }

            state = bubbleState.idle;
            nativeScale = gameObject.transform.localScale;
            idleScale = new Vector3(nativeScale.x * minScale, nativeScale.y * minScale);
            gameObject.transform.localScale = idleScale;
            gameObject.SetActive(false);
        }

        void Update()
        {
            switch (state)
            {
                case bubbleState.idle:
                    break;
                case bubbleState.appearing:
                    Appear();
                    break;
                case bubbleState.there:
                    Wobble();
                    break;
                case bubbleState.disappearing:
                    Disappear();
                    break;
                default:
                    break;
            }
        }

        public void Show(string request)
        {
            if (state == bubbleState.idle)
            {
                requestText.text = request;
                state = bubbleState.appearing;
                gameObject.SetActive(true);
            }
        }

        public void Hide()
        {
            if (state == bubbleState.there)
            {
                state = bubbleState.disappearing;
            }
        }

        private void Appear()
        {
            gameObject.transform.localScale = HelperFuctions.ScaleVector(gameObject.transform.localScale, Time.deltaTime / minScale / scaleTime);
            if (gameObject.transform.localScale.x >= nativeScale.x)
            {
                gameObject.transform.localScale = nativeScale;
                state = bubbleState.there;
                thereStartTime = Time.time;
            }
        }

        private void Wobble()
        {
            gameObject.transform.localScale = new Vector3(nativeScale.x * (1 + wobbleScale * Mathf.Sin((Time.time - thereStartTime) / wobbleTime)), nativeScale.y * (1 - wobbleScale * Mathf.Sin((Time.time - thereStartTime) / wobbleTime)));
        }

        private void Disappear()
        {
            gameObject.transform.localScale = HelperFuctions.ScaleVector(gameObject.transform.localScale, 1 / (Time.deltaTime / minScale / scaleTime));
            if (gameObject.transform.localScale.x <= nativeScale.x * minScale)
            {
                gameObject.transform.localScale = HelperFuctions.ScaleVector(nativeScale, minScale);
                state = bubbleState.idle;
                gameObject.SetActive(false);
            }
        }
    }
}
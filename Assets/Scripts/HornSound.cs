using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TrafficInfinity
{
    public class HornSound : MonoBehaviour
    {

        public AudioSource buttonSound;
        private bool isButtonPressed = false;

        private void Start()
        {
            buttonSound = GameObject.Find("HornButton").GetComponent<AudioSource>();
        }

        public void OnButtonPressed()
        {
            if (!isButtonPressed)
            {
                isButtonPressed = true;
                buttonSound.Play();
            }
        }

        public void OnButtonReleased()
        {
            if (isButtonPressed)
            {
                isButtonPressed = false;
                buttonSound.Stop();
            }
        }
    }
}

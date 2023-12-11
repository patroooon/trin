using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TrafficInfinity
{
    public class LightController : MonoBehaviour
    {
        public GameObject FlashlightOn;
        private bool isMoving;

        private void Update()
        {
            if (isMoving == true)
            {
                FlashlightOn.SetActive(false);
            }

            if (isMoving == false)
            {
                FlashlightOn.SetActive(true);
            }
        }
    }
}

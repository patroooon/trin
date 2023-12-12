using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TrafficInfinity
{
    public class LightController : MonoBehaviour
    {
        public GameObject FlashlightOn;
        private bool onMovingValue = RandomMove2.onMoving;
      

        private void Update()
        {
            if (!RandomMove2.onMoving)
            {
                FlashlightOn.SetActive(true);
            }

            else
            {
                FlashlightOn.SetActive(false);
            }

        }
    }
}

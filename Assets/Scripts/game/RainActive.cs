using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class RainActive : MonoBehaviour
    {
        public GameObject objectToActivate; 
        public float activationThreshold = 500f; 

        private void Update()
        {
            if (transform.position.z >= activationThreshold)
            {
                objectToActivate.SetActive(true);
            }
            else
            {
                objectToActivate.SetActive(false);
            }
        }
    }
}

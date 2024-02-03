using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class LightActivate : MonoBehaviour
    {
        public List<GameObject> objectsToEnable;
        public float zThreshold = 2050f;

        private void Update()
        {
            if (transform.position.z >= zThreshold)
            {
                foreach (GameObject obj in objectsToEnable)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}

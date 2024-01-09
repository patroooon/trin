using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class StreetLightCreat : MonoBehaviour
    {
        public GameObject prefab;
        void Start()
        {
            for (var i = 0; i < 10; i++)
            {
                Instantiate(prefab, new Vector3(i * 0, 0, 40.0f), Quaternion.identity);
            }
        }
    }
}

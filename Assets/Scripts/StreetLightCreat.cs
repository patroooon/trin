using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class StreetLightCreat : MonoBehaviour
    {
        /* public Transform[] objectsToPosition;
         public float distanceBetweenObjects = 40f;

         private void PositionObjects()
         {
             float startZ = 0f;

             foreach (Transform obj in objectsToPosition)
             {
                 obj.position = new Vector3(obj.position.x, obj.position.y, startZ);
                 startZ += distanceBetweenObjects;
             }
         }
        */




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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class Score : MonoBehaviour
    {
        public static float distanceTraveled;
        public static int roundedDistance;

        private Rigidbody rb;
        private Vector3 oldPosition;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            oldPosition = rb.position;

            InvokeRepeating("CalculateDistance", 1f, 1f);
        }

        public void CalculateDistance()
        {
            Vector3 newPosition = rb.position;
            float distance = Vector3.Distance(newPosition, oldPosition);
            distanceTraveled += distance;
            oldPosition = newPosition;

            int roundedDistance = Mathf.RoundToInt(distanceTraveled);
            Debug.Log("Пройденное расстояние: " + roundedDistance);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class Score : MonoBehaviour
    {
        private Rigidbody rb;
        private Vector3 oldPosition;
        private float distanceTraveled;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            oldPosition = rb.position;

            InvokeRepeating("CalculateDistance", 1f, 1f);
        }

        private void CalculateDistance()
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

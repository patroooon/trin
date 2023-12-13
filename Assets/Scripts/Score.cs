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
        }

        private void Update()
        {
            Vector3 newPosition = rb.position;
            float distance = Vector3.Distance(newPosition, oldPosition);
            distanceTraveled += distance;
            oldPosition = newPosition;

            Debug.Log("Пройденное расстояние: " + distanceTraveled);
        }
    }
}

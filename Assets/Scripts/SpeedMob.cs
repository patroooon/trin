using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class SpeedMob : MonoBehaviour
    {   
        public float speedDifference = 20f;
        public float timeDestroy = 5f;
        public PlayerController PlayerController;

        private float currentSpeed;

        private void Update()
        {
            float value = PlayerController.m_speedMove;
            currentSpeed = value + speedDifference;
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            Debug.Log("Скорость объекта: " + currentSpeed);
        }
    }
}

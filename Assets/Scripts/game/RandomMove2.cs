using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class RandomMove2 : MonoBehaviour
    {
        //public float speedVan = 15f;
        public float minStopDuration = 1f;
        public float maxStopDuration = 3f;
        //public float increaseSpeedDistance = 30f;
        public Transform van;
        public PlayerController PlayerController;
        public static bool onMoving = true;

        private float stopDuration;
        private float timer;
        private float lastDistance = 0f;

        private void Start()
        {
            stopDuration = Random.Range(minStopDuration, maxStopDuration);
            lastDistance = Mathf.Abs(van.position.z - transform.position.z);
        }

        private void Update()
        {
            float speedVan = PlayerController.m_speedMove;
            float currentDistance = Mathf.Abs(van.position.z - transform.position.z);
            Debug.Log("Скорость грузовика увеличена! Текущее значение: " + speedVan);

            if (onMoving)
            {
               
                transform.Translate(Vector3.forward * speedVan * Time.deltaTime);
            }

            
            timer += Time.deltaTime;

            if (timer >= stopDuration)
            {
                
                onMoving = !onMoving;
                timer = 0f;

                if (onMoving)
                {
                    
                    stopDuration = Random.Range(minStopDuration, maxStopDuration);
                }
            }
        }


    }
}

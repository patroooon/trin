using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class RandomMove : MonoBehaviour
    {
        public float speed = 15f;
        public float minStopTime = 1f;
        public float maxStopTime = 5f;

        private Vector3 targetPosition;
        private bool isMoving = true;

        private void Start()
        {
            SetRandomTargetPosition();
        }

        private void Update()
        {
            if (isMoving)
            {
                // Двигаем объект к целевой позиции
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                // Если достигли целевой позиции, останавливаемся на случайное время
                if (transform.position == targetPosition)
                {
                    isMoving = false;
                    Invoke("SetRandomTargetPosition", Random.Range(minStopTime, maxStopTime));
                }
            }
        }

        private float previousZPosition;
        private float nextZPosition;
        

        private void SetRandomTargetPosition()
        {
            // Генерируем случайную Z-позицию больше предыдущей
            float randomZ = Random.Range(previousZPosition+1f, 5f);
            targetPosition = new Vector3(0f, 0f, Random.Range(previousZPosition, 100f));
            previousZPosition = randomZ;
            isMoving = true;
            //float randomZ = Random.Range(previousZPosition + 1f, 1000f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class RandomMove2 : MonoBehaviour
    {
        public float speedVan = 1f;
        public float minStopDuration = 1f;
        public float maxStopDuration = 3f;
        public static bool onMoving = true;

        private float stopDuration;
        private float timer;

        private void Start()
        {
            stopDuration = Random.Range(minStopDuration, maxStopDuration);
        }

        private void Update()
        {
            if (onMoving)
            {
                // Движение объекта по оси Z
                transform.Translate(Vector3.forward * speedVan * Time.deltaTime);
            }

            // Таймер для случайных остановок
            timer += Time.deltaTime;

            if (timer >= stopDuration)
            {
                // Изменение состояния движения и сброс таймера
                onMoving = !onMoving;
                timer = 0f;

                if (onMoving)
                {
                    // Генерация новой случайной длительности остановки
                    stopDuration = Random.Range(minStopDuration, maxStopDuration);
                }
            }
        }


    }
}

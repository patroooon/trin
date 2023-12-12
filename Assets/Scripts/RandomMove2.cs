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
                // �������� ������� �� ��� Z
                transform.Translate(Vector3.forward * speedVan * Time.deltaTime);
            }

            // ������ ��� ��������� ���������
            timer += Time.deltaTime;

            if (timer >= stopDuration)
            {
                // ��������� ��������� �������� � ����� �������
                onMoving = !onMoving;
                timer = 0f;

                if (onMoving)
                {
                    // ��������� ����� ��������� ������������ ���������
                    stopDuration = Random.Range(minStopDuration, maxStopDuration);
                }
            }
        }


    }
}

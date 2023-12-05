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

        private bool isMoving = true;
        private float stopDuration;
        private float timer;

        private void Start()
        {
            stopDuration = Random.Range(minStopDuration, maxStopDuration);
        }

        private void Update()
        {
            if (isMoving)
            {
                // �������� ������� �� ��� Z
                transform.Translate(Vector3.forward * speedVan * Time.deltaTime);
            }

            // ������ ��� ��������� ���������
            timer += Time.deltaTime;

            if (timer >= stopDuration)
            {
                // ��������� ��������� �������� � ����� �������
                isMoving = !isMoving;
                timer = 0f;

                if (isMoving)
                {
                    // ��������� ����� ��������� ������������ ���������
                    stopDuration = Random.Range(minStopDuration, maxStopDuration);
                }
            }
        }


    }
}

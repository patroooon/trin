using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class VanController : MonoBehaviour
    {

        public float speed = 5.0f; // �������� �������� �������
        public Vector3 direction = Vector3.right; // ����������� �������� �������



        public void Update()
        {
            StartCoroutine(MoveCoroutine());
            IEnumerator MoveCoroutine()
            {
                while (true)
                {
                    yield return new WaitForSeconds(Random.Range(1, 5)); // ��������� ����� �������� �� 1 �� 5 ������
                    transform.position += direction * speed * Time.deltaTime; // �������� �������
                }
            }
        }
    }
}

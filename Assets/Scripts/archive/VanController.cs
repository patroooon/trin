using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class VanController : MonoBehaviour
    {

        public float speed = 5.0f; // Скорость движения объекта
        public Vector3 direction = Vector3.right; // Направление движения объекта



        public void Update()
        {
            StartCoroutine(MoveCoroutine());
            IEnumerator MoveCoroutine()
            {
                while (true)
                {
                    yield return new WaitForSeconds(Random.Range(1, 5)); // Случайное время ожидания от 1 до 5 секунд
                    transform.position += direction * speed * Time.deltaTime; // Движение объекта
                }
            }
        }
    }
}

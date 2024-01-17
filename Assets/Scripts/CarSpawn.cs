using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class CarSpawn : MonoBehaviour
    {
        public GameObject objectPrefab;
        public float speed = 20f;
        public float minSpawnInterval = 1f;
        public float maxSpawnInterval = 3f;
        public float destroy = 5f;
       

        void Start()
        {
            StartCoroutine(SpawnObjectsWithDelay());
        }
        IEnumerator SpawnObjectsWithDelay()
        {
            while (true)
            {
                // Создание объекта
                GameObject newObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

                // Получение компонента Transform нового объекта
                Transform objectTransform = newObject.transform;

                // Установка скорости движения объекта по оси Z
                objectTransform.position += Vector3.forward * speed * Time.deltaTime;

                // Задержка перед созданием следующего объекта
                float delay = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(delay);
                Destroy(gameObject, destroy);
            }
        }
    }
}


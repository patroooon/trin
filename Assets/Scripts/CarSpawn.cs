using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class CarSpawn : MonoBehaviour
    {
        public GameObject[] objectPrefabs; // Массив префабов объектов, которые нужно респавнить
        public float minSpawnDelay = 1f; // Минимальный интервал времени между респавном объектов
        public float maxSpawnDelay = 5f; // Максимальный интервал времени между респавном объектов
        public float objectLifetime = 10f; // Время жизни объекта до его удаления

        private void Start()
        {
            // Запускаем корутину для респавна объектов с заданным интервалом
            StartCoroutine(SpawnObjects());
        }

        private System.Collections.IEnumerator SpawnObjects()
        {
            while (true)
            {
                // Генерируем случайный интервал времени для ожидания перед респавном
                float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
                yield return new WaitForSeconds(spawnDelay);

                // Генерируем случайный индекс префаба из массива
                int randomIndex = Random.Range(0, objectPrefabs.Length);

                // Создаем новый объект из случайного префаба
                GameObject newObject = Instantiate(objectPrefabs[randomIndex], transform.position, transform.rotation);

                // Запускаем корутину для удаления объекта через время objectLifetime
                StartCoroutine(DestroyObject(newObject, objectLifetime));
            }
        }

        private System.Collections.IEnumerator DestroyObject(GameObject objectToDestroy, float delay)
        {
            yield return new WaitForSeconds(delay);

            // Удаляем объект
            Destroy(objectToDestroy);
        }

    }
}


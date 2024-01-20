using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class CarSpawn : MonoBehaviour
    {
        public GameObject[] objectPrefabs; // ������ �������� ��������, ������� ����� ����������
        public float minSpawnDelay = 1f; // ����������� �������� ������� ����� ��������� ��������
        public float maxSpawnDelay = 5f; // ������������ �������� ������� ����� ��������� ��������
        public float objectLifetime = 10f; // ����� ����� ������� �� ��� ��������

        private void Start()
        {
            // ��������� �������� ��� �������� �������� � �������� ����������
            StartCoroutine(SpawnObjects());
        }

        private System.Collections.IEnumerator SpawnObjects()
        {
            while (true)
            {
                // ���������� ��������� �������� ������� ��� �������� ����� ���������
                float spawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
                yield return new WaitForSeconds(spawnDelay);

                // ���������� ��������� ������ ������� �� �������
                int randomIndex = Random.Range(0, objectPrefabs.Length);

                // ������� ����� ������ �� ���������� �������
                GameObject newObject = Instantiate(objectPrefabs[randomIndex], transform.position, transform.rotation);

                // ��������� �������� ��� �������� ������� ����� ����� objectLifetime
                StartCoroutine(DestroyObject(newObject, objectLifetime));
            }
        }

        private System.Collections.IEnumerator DestroyObject(GameObject objectToDestroy, float delay)
        {
            yield return new WaitForSeconds(delay);

            // ������� ������
            Destroy(objectToDestroy);
        }

    }
}


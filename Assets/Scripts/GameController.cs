using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class GameController : MonoBehaviour
    {
        public Transform Van;
        public Transform Player;
        public float maxDistance = 5f;

        private void Update()
        {
            //float distance = Vector3.Distance(Van.position, Player.position);
            float distance = Mathf.Abs(Van.position.z - Player.position.z);
            if (distance >= maxDistance)
            {
                Debug.Log("большое расстояние!");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Игра завершена!");
        }
    }
}

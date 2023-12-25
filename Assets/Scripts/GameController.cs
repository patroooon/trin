using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TrafficInfinity
{
    public class GameController : MonoBehaviour
    {
        public Transform Van;
        public Transform Player;
        public float maxDistance = 5f;
        public UnityEvent onDistanceFar;
        public UnityEvent onCarCrash;

        private void Update()
        {
            
            float distance = Mathf.Abs(Van.position.z - Player.position.z);
            if (distance >= maxDistance)
            {
                onDistanceFar?.Invoke();
                Debug.Log("большое расстояние!");
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            onCarCrash?.Invoke();
            Debug.Log("Игра завершена!");
        }

        /*public void CarRestart()
        {
            
        }*/
    } 
}

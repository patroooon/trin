using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TrafficInfinity
{
    public class GameController : MonoBehaviour
    {
        public Transform Van;
        public Transform Player;
        public float maxDistance = 10f;
        private bool m_isOver;
       



        private void Update()
        {
            if (m_isOver)
            {
                return;
            }
            
            float distance = Mathf.Abs(Van.position.z - Player.position.z);
            if (distance >= maxDistance)
            {
                m_isOver = true;
                GameEvent.onDistanceFar?.Invoke();     
                Debug.Log("большое расстояние!");
               

            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (m_isOver)
            {
                return;
            }

            m_isOver = true;

            GameEvent.onCarCrash?.Invoke();
            Debug.Log("Игра завершена!");
        }

    } 
}

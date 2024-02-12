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
                StartCoroutine(DelayedDistanceFarEvent());
                  
                Debug.Log("������� ����������!");
            }
        }

        IEnumerator DelayedDistanceFarEvent()
        {
            yield return new WaitForSeconds(1f); // �������� � 1 �������
            GameEvent.onDistanceFar?.Invoke();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (m_isOver)
            {
                return;
            }

            m_isOver = true;

            GameEvent.onCarCrash?.Invoke();
            Debug.Log("���� ���������!");
        }
   
} 
}

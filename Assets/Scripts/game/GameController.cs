using System.Collections;
using UnityEngine;

namespace TrafficInfinity
{
    public class GameController : MonoBehaviour
    {
        public Transform Van;
        public Transform Player;
        public float maxDistance = 10f;
        private bool m_isOver;
        [SerializeField] private PlayerController m_playerController;

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
                  
                Debug.Log("большое расстояние!");
            }
        }

        IEnumerator DelayedDistanceFarEvent()
        {
            m_playerController.m_isPauseActive = false;
            yield return new WaitForSeconds(1f); // задержка в 1 секунду
            GameEvent.onDistanceFar?.Invoke();
            m_playerController.m_isPauseActive = true;
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

using UnityEngine;

namespace TrafficInfinity
{
    public class StatePause : GameState
    {
        [SerializeField] private GameplayState m_gamePlayState;
        [SerializeField] private RandomMove2 m_trafficController;
        [SerializeField] private PlayerController m_playerController;

        public void OnContinue()
        {
            m_gamePlayState.Enter();
            m_trafficController.ActivateMoveTraffic(true);
            m_playerController.ActivateInput(true);
            Exit();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_trafficController.ActivateMoveTraffic(false);
            m_playerController.ActivateInput(false);
            m_gamePlayState.Exit();
        }
    }
}
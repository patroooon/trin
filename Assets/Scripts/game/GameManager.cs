using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class GameManager : MonoBehaviour
    {
        public MainMenuState mainMenuState;
        [SerializeField] private StatePause pauseState;
        [SerializeField] private PlayerController m_playerController;

        private void OnEnable()
        {
            m_playerController.onPauseActivate += PauseActivate;
        }

        private void OnDisable()
        {
            m_playerController.onPauseActivate -= PauseActivate;
        }

        private void Start()
        {
            mainMenuState.gameObject.SetActive(true);
        }

        private void PauseActivate()
        {
            pauseState.Enter();
        }
    }
}

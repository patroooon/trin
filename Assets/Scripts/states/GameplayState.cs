using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace TrafficInfinity
{
    public class GameplayState : GameState
    {
        public GameController gameController;
        public PlayerController playerController;
        public GameState gameOverState;

        private LeaderboardManager leaderboardManager;

        private void Start()
        {
            leaderboardManager = FindObjectOfType<LeaderboardManager>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            gameController.enabled = true;
            playerController.enabled = true;

            
           GameEvent.onCarCrash += OnGameOver;
           GameEvent.onDistanceFar += OnGameOver;
           
        }

        public void OnGameOver()
        {
            
            Debug.Log("GameOver!!!");
            Exit();
            gameOverState.Enter();

         
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvent.onCarCrash -= OnGameOver;
            GameEvent.onDistanceFar -= OnGameOver;
            

            gameController.enabled = false;
            playerController.enabled = false;
        }

    }
}

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace TrafficInfinity
{
    public class GameplayState : GameState
    {
        public GameController gameController;
        public PlayerController playerController;
        public GameState gameOverState;
        //public TMP_Text scoreText;
        
        protected override void OnEnable()
        {
            base.OnEnable();

            gameController.enabled = true;
            playerController.enabled = true;

            
           GameEvent.onCarCrash += OnGameOver;
           GameEvent.onDistanceFar += OnGameOver;
           
        }

        private void OnGameOver()
        {
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

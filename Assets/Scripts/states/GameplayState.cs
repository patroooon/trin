using UnityEngine;

namespace TrafficInfinity
{
    public class GameplayState : GameState
    {
        public GameController gameController;
        public PlayerController playerController;
        public GameState gameOverState;

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
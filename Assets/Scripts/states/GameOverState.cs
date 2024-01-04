using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TrafficInfinity
{
    public class GameOverState : GameState
    {
        public GameState mainMenuState;
        public GameController gameController;
       // public GameObject gameOverScreen;
       // public Transform originalPosition;

        public void Restart()
        {
            Exit();
            mainMenuState.Enter();
           // transform.position = originalPosition.position;
        }
    }
}

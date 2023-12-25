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

        public void Restart()
        {
            Exit();
            mainMenuState.Enter();
        }
    }
}

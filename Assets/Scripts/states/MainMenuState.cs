using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class MainMenuState : GameState
    {
        public GameController gameController;
        public GameState gamePlayState;
       

        public void PlayGame()
        {
            Exit();
            gamePlayState.Enter();
        }
    }
}

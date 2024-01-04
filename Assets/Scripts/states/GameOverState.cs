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
        public GameObject Van;
        public GameObject Player;


        public void Restart()
        {
            Exit();
            mainMenuState.Enter();
            Van.transform.position = new Vector3(0, 0, 0);
            Player.transform.position = new Vector3(0, 0, 0);
            Van.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TrafficInfinity
{
    public class GameplayState : GameState
    {
        public GameController gameController;
        public PlayerController playerController;
        public GameState gameOverState;
        public TMP_Text scoreText;
       

        
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

           /* string textValue = scoreText.text;

            if (int.TryParse(textValue, out int intValue))
            {
                
                Debug.Log("Converted value: " + intValue);
            }
            else
            {
                Debug.LogError("Unable to convert text to int");
            }


            scoreData.SaveScore(intValue);
            Debug.Log("Данные сохранены");*/
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

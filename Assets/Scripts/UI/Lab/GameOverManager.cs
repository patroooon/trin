using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TrafficInfinity
{
    public class GameOverManager : MonoBehaviour
    {
        public TMP_Text scoreText;
        public TMP_InputField nameInput;
        public ScoreData scoreData;

        private void Start()
        {
            // Пример установки начального текста счета
            scoreText.text = "Score: 100"; // Предположим, что ваш счет находится в TMP_Text
        }

        public void SaveScore()
        {
            int score = int.Parse(scoreText.text.Replace("Score: ", "")); // Получаем счет из текста и преобразуем в int
            string playerName = nameInput.text;

            scoreData.AddScore(playerName, score); // Добавляем счет в Scriptable Object
        }
    }
}

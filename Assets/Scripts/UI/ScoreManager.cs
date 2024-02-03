using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TrafficInfinity
{
    public class ScoreManager : MonoBehaviour
    {
        public PlayerRecord playerRecord;
        public TMP_Text scoreText;
        public TMP_InputField nameInput;

        private int currentScore;

        void Start()
        {
            // Инициализация счета
            currentScore = 0;
            UpdateScoreText();
        }

        public class PlayerRecord
        {
            public string playerName;
            public int score;
        }
        
        // Вызывается при увеличении счета
        public void IncreaseScore(int amount)
        {
            currentScore += amount;
            UpdateScoreText();
        }

        // Обновление текста счета на экране
        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }

        // Вызывается при завершении игры
        public void OnGameOver()
        {
            // Создание новой записи PlayerRecord с именем и счетом
            PlayerRecord newPlayerRecord = new PlayerRecord
            {
                playerName = nameInput.text,
                score = currentScore
            };

            // Добавление новой записи в список
           
            
            //playerRecord.playerRecords.Add(newPlayerRecord);

            // Сохранение списка записей игроков в ScriptableObject
            SavePlayerRecord();

            // Здесь можно добавить другие действия по завершении игры

            Debug.Log("Game ended! Player record saved.");
        }

        // Сохранение списка записей игроков в ScriptableObject
        private void SavePlayerRecord()
        {
            
            // Пример использования JsonUtility:
            string json = JsonUtility.ToJson(playerRecord);
            PlayerPrefs.SetString("PlayerRecords", json);
            PlayerPrefs.Save();
        }
    }
}


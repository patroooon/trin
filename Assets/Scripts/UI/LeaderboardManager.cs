using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using TMPro;


namespace TrafficInfinity
{
    public class LeaderboardManager : MonoBehaviour
    {
        public TMP_InputField nameInputField;
        public TMP_Text scoreInputField;
        public TMP_Text lBGOPText;
        public TMP_Text lBMMText;

        private const string playerNameKeyPrefix = "PlayerName";
        private const string playerScoreKeyPrefix = "PlayerScore";
        private const int maxEntries = 10;

        
        public void SaveScore()
        {
            string playerName = nameInputField.text;
            int playerScore = int.Parse(scoreInputField.text);

            // Удаление самого низкого результата, если количество записей превышает максимум
            if (PlayerPrefs.HasKey(playerScoreKeyPrefix + maxEntries))
            {
                PlayerPrefs.DeleteKey(playerNameKeyPrefix + maxEntries);
                PlayerPrefs.DeleteKey(playerScoreKeyPrefix + maxEntries);
            }

            // Сдвиг всех записей вниз
            for (int i = maxEntries - 1; i > 0; i--)
            {
                if (PlayerPrefs.HasKey(playerScoreKeyPrefix + i))
                {
                    PlayerPrefs.SetString(playerNameKeyPrefix + (i + 1), PlayerPrefs.GetString(playerNameKeyPrefix + i));
                    PlayerPrefs.SetInt(playerScoreKeyPrefix + (i + 1), PlayerPrefs.GetInt(playerScoreKeyPrefix + i));
                }
            }

            // Сохранение новой записи
            PlayerPrefs.SetString(playerNameKeyPrefix + 1, playerName);
            PlayerPrefs.SetInt(playerScoreKeyPrefix + 1, playerScore);
            PlayerPrefs.Save();

            Debug.Log("Score saved - Name: " + playerName + ", Score: " + playerScore);
        }

        // Метод для отображения таблицы рекордов
        public void ShowLeaderboard()
        {
            List<Tuple<string, int>> leaderboard = new List<Tuple<string, int>>();


            for (int i = 1; i <= maxEntries; i++)
            {
                if (PlayerPrefs.HasKey(playerScoreKeyPrefix + i))
                {
                    string playerName = PlayerPrefs.GetString(playerNameKeyPrefix + i);
                    int playerScore = PlayerPrefs.GetInt(playerScoreKeyPrefix + i);
                    leaderboard.Add(new Tuple<string, int>(playerName, playerScore));
                }
            }


            leaderboard.Sort((x, y) => y.Item2.CompareTo(x.Item2));


            lBGOPText.text = "";
            lBMMText.text = "";
            foreach (var entry in leaderboard)
            {
                lBGOPText.text += "Name: " + entry.Item1 + ", Score: " + entry.Item2 + "\n";
                lBMMText.text += "Name: " + entry.Item1 + ", Score: " + entry.Item2 + "\n";
            }

            
            Debug.Log("Leaderboard displayed.");
        }


    }
}



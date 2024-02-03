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
            // ������������� �����
            currentScore = 0;
            UpdateScoreText();
        }

        public class PlayerRecord
        {
            public string playerName;
            public int score;
        }
        
        // ���������� ��� ���������� �����
        public void IncreaseScore(int amount)
        {
            currentScore += amount;
            UpdateScoreText();
        }

        // ���������� ������ ����� �� ������
        private void UpdateScoreText()
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }

        // ���������� ��� ���������� ����
        public void OnGameOver()
        {
            // �������� ����� ������ PlayerRecord � ������ � ������
            PlayerRecord newPlayerRecord = new PlayerRecord
            {
                playerName = nameInput.text,
                score = currentScore
            };

            // ���������� ����� ������ � ������
           
            
            //playerRecord.playerRecords.Add(newPlayerRecord);

            // ���������� ������ ������� ������� � ScriptableObject
            SavePlayerRecord();

            // ����� ����� �������� ������ �������� �� ���������� ����

            Debug.Log("Game ended! Player record saved.");
        }

        // ���������� ������ ������� ������� � ScriptableObject
        private void SavePlayerRecord()
        {
            
            // ������ ������������� JsonUtility:
            string json = JsonUtility.ToJson(playerRecord);
            PlayerPrefs.SetString("PlayerRecords", json);
            PlayerPrefs.Save();
        }
    }
}


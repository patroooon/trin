using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;

namespace TrafficInfinity
{
    public class ScoreManager : MonoBehaviour
    {
        public TMP_InputField nameInputField;
        public TextMeshProUGUI scoreText;
        public GameObject gameOverPanel;
        public GameObject leaderboardPanel;
        public Button saveButton;
        public Button leaderboardButton;

        private const string PlayerPrefsKey = "Leaderboard";
        private const int MaxEntries = 10;

        private List<LeaderboardEntry> leaderboardEntries;

        [Serializable]
        private class LeaderboardEntry
        {
            public string playerName;
            public int score;
        }

        private void Start()
        {
            saveButton.onClick.AddListener(SaveScore);
            leaderboardButton.onClick.AddListener(ShowLeaderboard);

            leaderboardEntries = new List<LeaderboardEntry>();

            string json = PlayerPrefs.GetString(PlayerPrefsKey);
            if (!string.IsNullOrEmpty(json))
            {
                leaderboardEntries = JsonUtility.FromJson<List<LeaderboardEntry>>(json);
            }
        }

        private void SaveScore()
        {
            if (string.IsNullOrEmpty(nameInputField.text))
                return;

            int score = int.Parse(scoreText.text);

            leaderboardEntries.Add(new LeaderboardEntry
            {
                playerName = nameInputField.text,
                score = score
            });

            leaderboardEntries.Sort((a, b) => b.score.CompareTo(a.score));

            if (leaderboardEntries.Count > MaxEntries)
                leaderboardEntries.RemoveAt(MaxEntries);

            string json = JsonUtility.ToJson(leaderboardEntries);
            PlayerPrefs.SetString(PlayerPrefsKey, json);
            PlayerPrefs.Save();
        }

        private void ShowLeaderboard()
        {
            string leaderboardText = "Leaderboard:\n";

            for (int i = 0; i < leaderboardEntries.Count; i++)
            {
                leaderboardText += $"{i + 1}. {leaderboardEntries[i].playerName}: {leaderboardEntries[i].score}\n";
            }

            gameOverPanel.SetActive(false);
            leaderboardPanel.SetActive(true);
            scoreText.text = leaderboardText;
        }
    }
}

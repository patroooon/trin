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

        private const string playerScoreKeyPrefix = "PlayerScore";

        public void SaveScore()
        {
            //string playerName = nameInputField.text;
            int playerScore;
            
            if (!int.TryParse(scoreInputField.text, out playerScore))
            {
                Debug.LogError("Invalid score input!");
                return;
            }
            
            if (PlayerPrefs.HasKey(playerScoreKeyPrefix))
            {
                int lowestScore = PlayerPrefs.GetInt(playerScoreKeyPrefix);
                if (playerScore < lowestScore)
                {
                    Debug.Log("Score is lower than the lowest score in the leaderboard. Not saving.");
                    return;
                }
                else
                {
                    PlayerPrefs.DeleteKey(playerScoreKeyPrefix);
                    SavePrefs(playerScore);
                }
            }
            else
            {
                SavePrefs(playerScore);
            }
            //Debug.Log("Score saved - Name: " + playerName + ", Score: " + playerScore);
        }

        private void SavePrefs(int playerScore)
        {
            PlayerPrefs.SetInt(playerScoreKeyPrefix, playerScore);
            PlayerPrefs.Save();
        }
        
        public void ShowLeaderboard()
        {
            int playerScore = PlayerPrefs.GetInt(playerScoreKeyPrefix);
            lBGOPText.text = "";
            lBMMText.text = "";
            lBMMText.text += "BestScore" + " " + playerScore + "\n";
            Debug.Log("Leaderboard displayed.");
        }

        public void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace TrafficInfinity
{
    public class LeaderboardManager : MonoBehaviour
    {

        public TMP_InputField playerNameInput;
        public TMP_InputField playerScoreInput;
        public TMP_Text resultText;
        public Button saveButton;
        public Button resultButton;

        private List<Player> players = new List<Player>();

        private void Start()
        {
            saveButton.onClick.AddListener(SavePlayer);
            resultButton.onClick.AddListener(DisplayRecords);

            
            LoadRecords();
        }

        private void SavePlayer()
        {
            string playerName = playerNameInput.text;
            string recordInputText = playerScoreInput.text;

            if (string.IsNullOrWhiteSpace(playerName) || string.IsNullOrWhiteSpace(recordInputText))
            {
                Debug.LogError("Both player name and record must be filled");
                return;
            }

            if (!int.TryParse(recordInputText, out int playerRecord))
            {
                Debug.LogError("Enter a valid record");
                return;
            }

            Player player = new Player { Name = playerName, Record = playerRecord };
            players.Add(player);

           
            players.Sort((p1, p2) => p2.Record.CompareTo(p1.Record));

            
            playerNameInput.text = "";
            playerScoreInput.text = "";

            
            SaveRecords();

            Debug.Log("Data saved successfully");
        }

        private void DisplayRecords()
        {
            
            resultText.text = "Records:\n";

            foreach (var player in players)
            {
                resultText.text += $"{player.Name}: {player.Record}\n";
            }
        }

        private void SaveRecords()
        {
            
            string json = JsonUtility.ToJson(players);
            PlayerPrefs.SetString("PlayerRecords", json);
            PlayerPrefs.Save();
        }

        private void LoadRecords()
        {
            
            string json = PlayerPrefs.GetString("PlayerRecords", "");
            players = JsonUtility.FromJson<List<Player>>(json);

            if (players == null)
            {
                players = new List<Player>();
            }
        }
    }

    [System.Serializable]
    public class Player
    {
        public string Name;
        public int Record;
    }
}


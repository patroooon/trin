using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreData", menuName = "ScriptableObjects/ScoreData", order = 1)]
public class ScoreData : ScriptableObject
{
    [System.Serializable]
    public class PlayerScore
    {
        public string playerName;
        public int score;
    }

    public PlayerScore[] highScores = new PlayerScore[10];

    public void AddScore(string playerName, int score)
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            if (score > highScores[i].score)
            {
                // Shift other scores down
                for (int j = highScores.Length - 1; j > i; j--)
                {
                    highScores[j] = highScores[j - 1];
                }

                // Insert new score
                highScores[i] = new PlayerScore { playerName = playerName, score = score };
                break;
            }
        }
    }
}
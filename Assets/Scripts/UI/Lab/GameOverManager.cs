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
            // ������ ��������� ���������� ������ �����
            scoreText.text = "Score: 100"; // �����������, ��� ��� ���� ��������� � TMP_Text
        }

        public void SaveScore()
        {
            int score = int.Parse(scoreText.text.Replace("Score: ", "")); // �������� ���� �� ������ � ����������� � int
            string playerName = nameInput.text;

            scoreData.AddScore(playerName, score); // ��������� ���� � Scriptable Object
        }
    }
}

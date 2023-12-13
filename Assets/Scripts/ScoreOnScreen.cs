using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrafficInfinity
{
    public class ScoreOnScreen : MonoBehaviour
    {
        public Text resultText;

        private void Start()
        {
            // ��������� ���������� �� ������� �������
            int result = Score.roundedDistance;

            // ���������� ���������� �������
            resultText.text = "����: " + result.ToString();
        }
    }
}

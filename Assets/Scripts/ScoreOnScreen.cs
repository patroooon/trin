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
            // Получение результата из другого скрипта
            int result = Score.roundedDistance;

            // Обновление текстового объекта
            resultText.text = "счет: " + result.ToString();
        }
    }
}

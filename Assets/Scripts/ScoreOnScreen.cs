using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TrafficInfinity
{
    public class ScoreOnScreen : MonoBehaviour
    {
        
            public Transform player; 
            public TMP_Text distanceText; 

            private float distanceTraveled = 0f; 
            private void Update()
            {
                
                distanceTraveled = player.position.z;

               
                distanceText.text = distanceTraveled.ToString("0") ;
            }
        









        //public Text resultText;

        //private void Start()
        //{
        //    // Получение результата из другого скрипта
        //    int result = Score.roundedDistance;

        //    // Обновление текстового объекта
        //    resultText.text = "счет: " + result.ToString();
        //}
    }
}

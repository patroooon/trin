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
        //    // ��������� ���������� �� ������� �������
        //    int result = Score.roundedDistance;

        //    // ���������� ���������� �������
        //    resultText.text = "����: " + result.ToString();
        //}
    }
}

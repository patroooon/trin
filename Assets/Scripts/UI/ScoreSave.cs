using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
   [CreateAssetMenu(fileName = "ScoreData", menuName = "ScriptableObjects/ScoreData")]
    public class ScoreData : ScriptableObject
    {
        public List<int> scores = new List<int>();
        

         public void SaveScore(int score)
        {
            scores.Add(score);
        }
    }
}

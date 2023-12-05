using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    [CreateAssetMenu(fileName = "New Auto", menuName = "Assets/New Auto")]
    public class Auto : ScriptableObject
    {
        public int id;
        public string autoName;
        public int speed;
        public int boost;
    }
}

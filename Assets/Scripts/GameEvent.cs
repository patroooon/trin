using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public static class GameEvent
    {
        public static event System.Action onMoving;
        public static event System.Action carsCollision;
        public static event System.Action longDistance;


       
    }
}

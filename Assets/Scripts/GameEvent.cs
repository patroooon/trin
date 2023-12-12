using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public static class GameEvent
    {
        public static event System.Action onMoving;
        public static event System.Action onFar;
        public static event System.Action onCrash;


        

        public static void CollisionCars(Collision collision)
        {
            onCrash?.Invoke();
        }
       
        
    }
}

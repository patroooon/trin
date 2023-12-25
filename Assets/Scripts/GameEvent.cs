using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public static class GameEvent
    {
        public static event System.Action onCarCrash;
        public static event System.Action onDistanceFar;
    }

    
}

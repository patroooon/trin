using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrafficInfinity
{
    public class GameManager : MonoBehaviour
    {
        public MainMenuState mainMenuState;

        private void Start()
        {
            mainMenuState.gameObject.SetActive(true);
        }
    }
}

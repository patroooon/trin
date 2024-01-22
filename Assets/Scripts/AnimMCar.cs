using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TrafficInfinity
{
    public class AnimMCar : MonoBehaviour
    {
        public Transform Van;
        public Transform Player;
        //public float maxDistance = 10f;
        public GameController GameController;


          private Animator anim;

        private void Update()
        {
            float maxDistance = GameController.maxDistance;
            float distance = Mathf.Abs(Van.position.z - Player.position.z);
            if (distance >= maxDistance)
            {
                anim = GetComponent<Animator>();
                anim.enabled = true;

            }

        }


    }
}


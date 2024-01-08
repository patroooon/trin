using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TrafficInfinity
{
    public class AnimMCar : MonoBehaviour
    {
        public Animation anim;

        public void PlayAnimation()
        {
            anim.Play("CarAnimation");
        }
    }
}

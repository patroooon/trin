using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrafficInfinity
{
    public class LoadScene1 : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Scene"))
            {
                SceneManager.LoadSceneAsync("level2", LoadSceneMode.Additive);
                Debug.Log("уровень загружен");
            }
        }

        // SceneManager.LoadSceneAsync("level1", LoadSceneMode.Additive);

    }
}
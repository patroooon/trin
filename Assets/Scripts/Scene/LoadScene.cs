using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrafficInfinity
{
    public class LoadScene : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Scene"))
            {
                SceneManager.LoadSceneAsync("level1", LoadSceneMode.Additive);
                Debug.Log("������� ��������");
            }
        }

        // SceneManager.LoadSceneAsync("level1", LoadSceneMode.Additive);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrafficInfinity
{
    public class LoadScene : MonoBehaviour
    {
        public float targetZPosition = 300f;
        private void Update()
        {
            float currentZPosition = transform.position.z;

            if (currentZPosition >= targetZPosition)
            {
                StartCoroutine(LoadNextScene());
            }
        }

        private IEnumerator LoadNextScene()
        {

            yield return SceneManager.LoadSceneAsync("level1", LoadSceneMode.Additive);
        }

      
    }
}
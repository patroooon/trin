using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrafficInfinity
{
    public class LoadScene : MonoBehaviour
    {
        public List<GameObject> lightObjects;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Scene"))
            {
                SceneManager.LoadSceneAsync("levelDark", LoadSceneMode.Additive);
                Debug.Log("уровень загружен");
                
               
                RenderSettings.ambientLight = Color.black;

              /*  foreach (GameObject obj in lightObjects)
                {
                    obj.SetActive(true);
                }*/
            }
           

        }

        

    }
}
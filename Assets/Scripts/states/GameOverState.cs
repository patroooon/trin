using UnityEngine;
using UnityEngine.SceneManagement;

namespace TrafficInfinity
{
    public class GameOverState : GameState
    {
        public GameState mainMenuState;
        public GameController gameController;
        public GameObject Van;
        public GameObject Player;

        public void Restart()
        {
            Exit();
            mainMenuState.Enter();     
            Van.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

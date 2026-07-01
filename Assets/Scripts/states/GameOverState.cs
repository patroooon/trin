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
        [SerializeField] private LeaderboardManager m_leaderManager;
        [SerializeField] private LeaderBoardUnity m_leaderBoarfUnity;

        public void Restart()
        {
            Exit();
            mainMenuState.Enter();     
            Van.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            m_leaderManager.SaveScore();
            m_leaderBoarfUnity.AddScore();
        }
    }
}

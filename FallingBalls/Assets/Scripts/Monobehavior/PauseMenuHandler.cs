using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monobehavior
{
    public class PauseMenuHandler : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuGO;
        private bool IsPaused { get; set; }

        private void OnEnable()
        {
            EventsBus.EventBus.PlayerDestroyed += OnGameOverPaused;
        }

        private void OnDisable()
        {
            EventsBus.EventBus.PlayerDestroyed -= OnGameOverPaused;

            Time.timeScale = 1.0f;
        }

        public void OnClickPause()
        {
            Time.timeScale = 0.0f;

            IsPaused = true;

            pauseMenuGO.SetActive(true);
        }

        public void OnClickResume()
        {
            Time.timeScale = 1.0f;

            IsPaused = false;

            pauseMenuGO.SetActive(false);
        }

        public void OnClickRestart()
        {
            SceneManager.LoadScene(0);

            Time.timeScale = 1.0f;

            IsPaused = false;

            pauseMenuGO.SetActive(false);
        }

        public void OnExitApplication() => 
            Application.Quit();

        public bool IsPausedGame() => 
            IsPaused;

        private void OnGameOverPaused()
        {
            IsPaused = true;

            Time.timeScale = 0.0f;
        }
    }
}
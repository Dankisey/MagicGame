using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controller
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private Canvas _menuCanvas; 
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;

        private bool _isActive = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_isActive)
                    Hide();
                else
                    Show();
            }
        }

        private void Show()
        {
            _menuCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            _isActive = true;
        }

        private void Hide()
        {
            _menuCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            _isActive = false;
        }

        private void OnContinueButtonClick()
        {
            Hide();
        }

        private void OnRestartButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        private void OnQuitButtonClick()
        {
            Application.Quit();
        }

        private void Start()
        {
            Hide();
        }

        private void Subscribe()
        {
            _continueButton.onClick.AddListener(OnContinueButtonClick);
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
        }

        private void Unsubscribe()
        {
            _continueButton.onClick.RemoveListener(OnContinueButtonClick);
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _quitButton.onClick.RemoveListener(OnQuitButtonClick);
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}
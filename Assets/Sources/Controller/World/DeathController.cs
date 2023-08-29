using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Game.Model;
using Game.View;

namespace Game.Controller
{
    public class DeathController : MonoBehaviour
    {
        [SerializeField] private TextWriter _gameOverTextWriter;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Canvas _deathCanvas;

        private Player _player;

        public void Init(Player player)
        {
            if (_player != null)
                Unsubscribe();

            _player = player;
        }

        private void OnPlayerDeath(Character character)
        {
            ShowDeathCanvas();
        }

        private void ShowDeathCanvas()
        {
            _deathCanvas.gameObject.SetActive(true);
            _gameOverTextWriter.ChangeText("Game Over");
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
            _deathCanvas.gameObject.SetActive(false);
        }

        private void Subscribe()
        {
            _player.Died += OnPlayerDeath;
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
        }

        private void Unsubscribe() 
        {
            _player.Died -= OnPlayerDeath;
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _quitButton.onClick.RemoveListener(OnQuitButtonClick);
        }

        private void OnEnable()
        {
            if (_player != null)
                Subscribe();
        }

        private void OnDisable()
        {
            if(_player != null)
                Unsubscribe();
        }
    }
}
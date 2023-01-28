using Pipes;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public int Score { get; private set; }
        public bool PlayerNeedTutorial { get; set; } = true;
        
        public GameObject tutorial;
        
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PipeSpawner _pipeSpawner;
        [SerializeField] private DBManager _dbManager;
    
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _highScoreText;
    
        [SerializeField] private GameObject _highScore;
        [SerializeField] private GameObject _playButton;
        [SerializeField] private GameObject _gameOver;
        [SerializeField] private GameObject _getReady;

        public void Awake()
        {
            //Reset();
            _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
            Application.targetFrameRate = 144;
        
            Pause();
        
            _gameOver.SetActive(false);
        }

        public void Play()
        {
            _pipeSpawner.PipesSpwaned = 0;
            Score = 0;
            _scoreText.text = Score.ToString();
        
            if (PlayerNeedTutorial)
            {
                tutorial.SetActive(true);
            }
            
            _playButton.SetActive(false);
            _getReady.SetActive(false);
            _gameOver.SetActive(false);
            _highScore.SetActive(false);

            Time.timeScale = 1f;
        
            _playerMovement.enabled = true;
            _playerAnimation.enabled = true;

            PipesMovement[] pipes = FindObjectsOfType<PipesMovement>();

            foreach (var pipe in pipes)
            {
                Destroy(pipe.gameObject);
            }
        }

        private void Pause()
        {
            Time.timeScale = 0f;

            _playerMovement.enabled = false;
            _playerAnimation.enabled = false;
        }

        public void GameOver()
        {
            _gameOver.SetActive(true);
            _playButton.SetActive(true);
            _highScore.SetActive(true);
            tutorial.SetActive(false);

            SavingHighScore();
            _dbManager.PostData();
            Pause();
        }

        public void InceaseScore()
        {
            Score++;
            _scoreText.text = Score.ToString();
        }
    
        private void SavingHighScore()
        {
            if (Score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Score);
                _highScoreText.text = Score.ToString();
            }
        }
        
        private void Reset()
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
    }
}
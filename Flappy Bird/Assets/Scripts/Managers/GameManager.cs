using Pipes;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public int Score { get; set; }
        public bool PlayerNeedTutorial { get; set; } = true;
        
        public GameObject tutorial;
        
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PipeSpawner _pipeSpawner;
        [SerializeField] private DBManager _dbManager;
    
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highScoreText;
    
        [SerializeField] private GameObject highScore;
        [SerializeField] private GameObject playButton;
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject getReady;

        public void Awake()
        {
            highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
            Application.targetFrameRate = 144;
        
            Pause();
        
            gameOver.SetActive(false);
        }

        public void Play()
        {
            _pipeSpawner.PipesSpwaned = 0;
            Score = 0;
            scoreText.text = Score.ToString();
        
            if (PlayerNeedTutorial)
            {
                tutorial.SetActive(true);
            }
            
            playButton.SetActive(false);
            getReady.SetActive(false);
            gameOver.SetActive(false);
            highScore.SetActive(false);

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
            gameOver.SetActive(true);
            playButton.SetActive(true);
            highScore.SetActive(true);
            tutorial.SetActive(false);

            SavingHighScore();
            _dbManager.PostData();
            Pause();
        }

        public void InceaseScore()
        {
            Score++;
            scoreText.text = Score.ToString();
        }
    
        private void SavingHighScore()
        {
            if (Score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", Score);
                highScoreText.text = Score.ToString();
            }
        }
    }
}
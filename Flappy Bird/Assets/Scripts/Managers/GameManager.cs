using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
    
    public int score { get; set; }

    public void Awake()
    {
        gameOver.SetActive(false);
        
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        
        Application.targetFrameRate = 144;
        
        Pause();
    }

    public void Play()
    {
        _pipeSpawner.pipesSpwaned = 0;
        score = 0;
        scoreText.text = score.ToString();
        
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

        SavingHighScore();
        _dbManager.PostData();
        Pause();
    }

    public void InceaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    
    private void SavingHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }
}

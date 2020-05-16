using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score { get; private set; }
    public static int round { get; private set; }
    public static int highRound { get; private set; }
    public static int highScore { get; private set; }

    public static float timeBetweenRounds = 15;
    public static bool playing;

    [SerializeField] Ball_Spawner ballSpawner;
    [SerializeField] UIManager _UIManager;
    Player_Controller _playerController;
    public static AudioSource _audioSource;

    public static Fireworks fireworks;

    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9); //Ignore player and ragdoll collision
        Physics.IgnoreLayerCollision(8, 10); //Ignore player and ball collision
        highRound = PlayerPrefs.GetInt("HighRound");
        highScore = PlayerPrefs.GetInt("HighScore");
        _UIManager.UpdateScoreText();
        _UIManager.UpdateRoundText();
        _UIManager.UpdateHighRoundText();
        _UIManager.UpdateHighScoreText();
        fireworks = FindObjectOfType<Fireworks>();
        _playerController = FindObjectOfType<Player_Controller>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void SaveHighScore()
    {
        if (round > highRound)
        {
            highRound = round;
            PlayerPrefs.SetInt("HighRound", highRound);
            _UIManager.UpdateHighRoundText();
        }
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            _UIManager.UpdateHighScoreText();
        }
    }

    public void IncreaseScore()
    {
        if (Player_Controller.isPlayerHit || !playing) return;
        score++;
        _UIManager.UpdateScoreText();
        if (score == Ball_Spawner.spawnedBalls)
            EndRound();
    }

    public void StartNewRound()
    {
        round++;
        _UIManager.UpdateRoundText();
        ballSpawner.SetAmountToSpawn();
    }

    public void EndRound()
    {
        RoundCountDown.counting = true;
    }

    public void OnHome()
    {
        RoundCountDown.StopCounting();
        _playerController.ResetPos();
        Player_Controller.canMove = false;
        Ball_Spawner.spawnedBalls = 0;
        fireworks.Activate(false);
    }

    public void OnPlayAgain()
    {
        score = 0;
        round = 0;
        _UIManager.UpdateScoreText();
        _UIManager.UpdateRoundText();
        RoundCountDown.StopCounting();
        _playerController.ResetPos();
        Player_Controller.canMove = true;
    }
}
using System.Collections;
using UnityEngine;

public class UISwitchBehavior : MonoBehaviour
{
    UIManager _UIManager;
    GameManager _gameManager;
    Ball_Spawner _ballSpawner;
    void Start()
    {
        _UIManager = GetComponent<UIManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _ballSpawner = FindObjectOfType<Ball_Spawner>();
    }

    public void OnHome()
    {
        GameManager._audioSource.volume = .5f;
        GameManager.playing = false;
        Time.timeScale = 1;
        RoundCountDown.StopCounting();
        if (_gameManager != null)
            _gameManager.OnHome();
        StopAllCoroutines();
        Ball_Spawner.canSpawn = false;
    }

    public void OnGameplay()
    {
        GameManager._audioSource.volume = .25f;
        if (!GameManager.playing)
        {
            GameManager.playing = true;
            _gameManager.EndRound();
        }
        Time.timeScale = 1;
    }

    public void OnPause()
    {
        if (Player_Controller.isPlayerHit) return;
        Time.timeScale = 0;
    }

    public void OnPlayAgain()
    {
        StopAllCoroutines();
        GameManager._audioSource.volume = .25f;
        GameManager.playing = true;
        _gameManager.OnPlayAgain();
        _gameManager.EndRound();
        Time.timeScale = 1;
    }

    public void OnGameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2);
        AnimationController.animator.ResetTrigger("Jump");
        GameManager.playing = false;
        RoundCountDown.StopCounting();
        Time.timeScale = 0;
        StopAllCoroutines();
        _gameManager.SaveHighScore();
        _ballSpawner.OnGameOver();
        _UIManager.ChangeUI(3);
    }
}
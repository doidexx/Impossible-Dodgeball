using UnityEngine;

public class RoundCountDown : MonoBehaviour
{
    public static bool counting;

    UIManager _UIManager;
    AnimationController animationController;
    GameManager _gameManager;

    static float timer;

    void Start()
    {
        _UIManager = FindObjectOfType<UIManager>();
        animationController = FindObjectOfType<AnimationController>();
        _gameManager = FindObjectOfType<GameManager>();
        timer = GameManager.timeBetweenRounds;
    }

    void Update()
    {
        StartCounting();
    }

    public static void StopCounting()
    {
        counting = false;
        timer = GameManager.timeBetweenRounds;
    }

    public void StartCounting()
    {
        if (!counting) return;
        timer -= Time.deltaTime;
        if (timer > 6)
            Beginning();
        else if (timer > 0)
            Mid(timer);
        else
            End(timer);
    }

    private void Beginning()
    {
        if (GameManager.round != 0)
        {
            GameManager.fireworks.Activate(true);
            _UIManager.EnableCongratulationText(true);
            animationController.StartDancing();
        }
        else
        {
            Player_Controller.canMove = true;
            _UIManager.UpdateTimerText("Ready?!", true);
        }
    }

    private void Mid(float time)
    {
        GameManager.fireworks.Activate(false);
        _UIManager.EnableCongratulationText(false);
        _UIManager.UpdateTimerText(time.ToString("0.00"), true);
        animationController.StopDancing();
    }

    private void End(float time)
    {
        _UIManager.UpdateTimerText(time.ToString("0.00"), false);
        counting = false;
        timer = GameManager.timeBetweenRounds;
        Ball_Spawner.canSpawn = true;
        _gameManager.StartNewRound();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Scores Text")]
    [SerializeField] TextMeshProUGUI[] scoreTexts;
    [SerializeField] TextMeshProUGUI[] roundTexts;
    [SerializeField] TextMeshProUGUI[] highScoreTexts;
    [SerializeField] TextMeshProUGUI[] highRoundTexts;
    [Header("Other Text")]
    [SerializeField] GameObject congratulationTextContainer;
    [SerializeField] TextMeshProUGUI timerText;
    [Header("Canvases")]
    [SerializeField] Canvas Home;
    [SerializeField] Canvas Pause;
    [SerializeField] Canvas Gameplay;
    [SerializeField] Canvas Records;
    [SerializeField] Canvas GameOver;
    [SerializeField] Canvas Balls;
    [SerializeField] Canvas Skins;
    Canvas[] allCanvas = new Canvas[8];
    [Header("UI GameObjects")]
    public GameObject homeScreenBall;
    public GameObject characterPreviewer;
    public GameObject ballPreviewer;

    UISwitchBehavior UI_Switcher;
    Player_Controller _palyerController;

    private void Start()
    {
        UI_Switcher = GetComponent<UISwitchBehavior>();
        _palyerController = FindObjectOfType<Player_Controller>();
        allCanvas[0] = Home;
        allCanvas[1] = Gameplay;
        allCanvas[2] = Pause;
        allCanvas[3] = GameOver;
        allCanvas[4] = Skins;
        allCanvas[5] = Balls;
        allCanvas[6] = Records;
        allCanvas[7] = Gameplay;
        ChangeUI(0);
    }

    public void UpdateScoreText()
    {
        foreach (TextMeshProUGUI scoreText in scoreTexts)
            scoreText.text = GameManager.score.ToString();
    }

    public void UpdateRoundText()
    {
        foreach (TextMeshProUGUI roundText in roundTexts)
            roundText.text = GameManager.round.ToString();
    }

    public void UpdateHighScoreText()
    {
        foreach (TextMeshProUGUI highScoreText in highScoreTexts)
            highScoreText.text = GameManager.highScore.ToString();
    }

    public void UpdateHighRoundText()
    {
        foreach (TextMeshProUGUI highRoundText in highRoundTexts)
            highRoundText.text = GameManager.highRound.ToString();
    }

    public void ChangeUI(int c)
    {
        for (int i = 0; i < allCanvas.Length; i++)
            allCanvas[i].enabled = false;
        SpecificBehaviors(c);
        allCanvas[c].enabled = true;
    }

    public void UI_Jump()
    {
        if (Player_Controller.isGrounded && Player_Controller.canMove)
            _palyerController.HandleJump();
    }

    void SpecificBehaviors(int c)
    {
        homeScreenBall.SetActive(c == 0 ? true : false);
        characterPreviewer.SetActive(c == 4 ? true : false);
        ballPreviewer.SetActive(c == 5 ? true : false);
        switch (c)
        {
            case 0:
                UI_Switcher.OnHome();
                break;
            case 1:
                UI_Switcher.OnGameplay();
                break;
            case 2:
                UI_Switcher.OnPause();
                break;
            case 7:
                UI_Switcher.OnPlayAgain();
                break;
        }
    }

    public void EnableCongratulationText(bool isEnable)
    {
        congratulationTextContainer.SetActive(isEnable);
    }

    public void UpdateTimerText(string text, bool isActive)
    {
        timerText.enabled = isActive;
        timerText.text = text;
    }
}
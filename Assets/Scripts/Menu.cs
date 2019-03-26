using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    GameObject VictoryPanel;
    [SerializeField]
    GameObject losePanel;
    [SerializeField]
    GameObject skins;
    [SerializeField]
    GameObject gameUI;

    WorldScript world;

    void Start()
    {
        world = FindObjectOfType<WorldScript>();
    }

    public void OpenMenu()
    {
        if (Time.timeScale == 1)
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OpenVictory(bool Vic)
    {
        VictoryPanel.SetActive(Vic);
        Time.timeScale = (Vic) ? 0 : 1;
    }

    public void OpenLose(bool los)
    {
        losePanel.SetActive(los);
        Time.timeScale = (los) ? 0 : 1;
    }

    public void PlayAgain()
    {
        world.RoundOne();
    }

    public void NextRound()
    {
        world.Roundtwo();
    }

    public void StartGame()
    {
        world.gameState = 1;
        gameUI.SetActive(true);
        world.RoundOne();
    }

    public void MainScreen()
    {
        world.gameState = 0;
        Time.timeScale = 1;
        gameUI.SetActive(false);
        menuPanel.SetActive(false);
        skins.SetActive(false);
        losePanel.SetActive(false);
        VictoryPanel.SetActive(false);
    }

    public void OpenSkins()
    {
        world.gameState = 2;
        skins.SetActive(true);
        gameUI.SetActive(false);
        world.Skin();
    }
}

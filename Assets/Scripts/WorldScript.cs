using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WorldScript : MonoBehaviour
{
    [SerializeField]
    Image ballFrame;
    [SerializeField]
    Image MainScreen;

    [SerializeField]
    Text timerText;
    [SerializeField]
    Text roundText;

    [SerializeField]
    GameObject gameUI;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject player1;

    [SerializeField]
    Vector3 normalSize;
    [SerializeField]
    Vector3 countSize;

    [SerializeField]
    int initialTime;

    GameObject selectedPlayer;

    int timer;
    int sizeControl;
    int round;
    public int gameState;

    public int selectedSkin;

    //GetInitialPositions.
    BallSpawner ballSpawner;
    Menu menu;

    void Start()
    {
        round = 1;
        roundText.text = "Round " + round;
        gameState = 0;
        menu = FindObjectOfType<Menu>();
        ballSpawner = FindObjectOfType<BallSpawner>();

        Physics.IgnoreLayerCollision(8, 9);
    }

    void FixedUpdate()
    {
        frameAnimation();
    }

    void Update()
    {
        selectedPlayer = (selectedSkin == 0) ? player : player1;
        StateZero();
        CallTheShot();
        timer = initialTime - (int)Time.time;
        if (timer > -1) { timerText.text = timer.ToString(); }
    }

    void frameAnimation ()
    {
        //change check weather or not the size should change.
        var change = false;
        var timerFloat = initialTime - Time.time;
        ballFrame.transform.Rotate(Vector3.forward * 0.1f);

        if (timerFloat == 4.0f || timerFloat == 3.0f || timerFloat == 2.0f || timerFloat == 1.0f)
        {
            sizeControl = (int)timerFloat;
            change = true;
        }

        if (sizeControl == 4 || sizeControl == 3 || sizeControl == 2 || sizeControl == 1)
        {
            if (change && ballFrame.transform.localScale != countSize)
            {
                ballFrame.transform.localScale = Vector3.Lerp(ballFrame.transform.localScale, countSize, 0.8f);
                if (ballFrame.transform.localScale == countSize) { change = false; }
            }

            if (!change) { ballFrame.transform.localScale = Vector3.Lerp(ballFrame.transform.localScale, normalSize, 0.8f); }
        }
    }

    void CallTheShot()
    {
        if (gameState != 0) {
            if (timer < -2 && !selectedPlayer.GetComponent<Players>().Hit) { selectedPlayer.GetComponent<Animator>().SetInteger("state", 2); }

            if (timer <= -6 && gameState == 1) {
                if (!selectedPlayer.GetComponent<Players>().Hit) { menu.OpenVictory(true); }
                if (selectedPlayer.GetComponent<Players>().Hit) { menu.OpenLose(true); }
            }
        }
    }

    public void Roundtwo()
    {
        round++;
        timer = 0;
        menu.OpenVictory(false);
        roundText.text = "Round " + round;
        initialTime = (int)(Time.time + 5);
        selectedPlayer.GetComponent<Players>().RoundReady();
        ballSpawner.howManyBalls = round * 5;
        ballSpawner.RoundReady();
    }

    public void RoundOne()
    {
        round = 1;
        timer = 0;
        menu.OpenLose(false);
        roundText.text = "Round " + round;
        initialTime = (int)(Time.time + 5);
        selectedPlayer.GetComponent<Players>().RoundReady();
        ballSpawner.howManyBalls = round * 5;
        ballSpawner.RoundReady();
    }

    public void StateZero()
    {
        if (gameState == 0)
        {
            MainScreen.gameObject.SetActive(true);
            gameUI.SetActive(false);
        }
        else
        {
            MainScreen.gameObject.SetActive(false);
            gameUI.SetActive(true);
        }
    }

    public void Skin()
    {
        if (gameState == 2)
        {
            MainScreen.gameObject.SetActive(false);
        }
    }
}

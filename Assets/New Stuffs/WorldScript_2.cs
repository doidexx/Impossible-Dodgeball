using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript_2: MonoBehaviour
{
    [Header("Model Managment")]
    [SerializeField]
    GameObject player;
    [SerializeField]
    Material[] playerSkins;
    [SerializeField]
    GameObject ball;
    [SerializeField]
    Material[] ballSkins;

    [Header("World Managment")]
    [SerializeField]
    int round = 0;
    public int Round { get { return round; } }
    [SerializeField]
    float timer = 0;// Serialized for debugging purposes.
    public float Timer { get { return timer; } }

    [Header("Screen Managment")]
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    GameObject[] Screens;

    bool letTimerRun = false;

    private void Start()
    {
        OpenScreen(0);
    }

    private void Update()
    {
        LetTimerRun(letTimerRun);
    }

    void LetTimerRun(bool run)
    {
        timer += Time.deltaTime;
    }

    void ResetTimer(bool reset)
    {
        timer = 0;
    }

    public void OpenScreen(int activate)
    {
        foreach (GameObject s in Screens)
        {
            s.SetActive(false);
        }
        Screens[activate].SetActive(true);
    }
}

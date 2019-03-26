using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    WorldScript world;

    [SerializeField]
    GameObject xbot;
    [SerializeField]
    GameObject ybot;

    [SerializeField]
    Image xbotI;
    [SerializeField]
    Image ybotI;

    public int next;

    void Start()
    {
        world = FindObjectOfType<WorldScript>();
        next = 0;
        Next();
    }

    public void Next()
    {
        next = (next == 0) ? 1 : 0;
        if (next == 0)
        {
            ybotI.enabled = true;
            xbotI.enabled = false;
        }
        else
        {
            ybotI.enabled = false;
            xbotI.enabled = true;
        }
    }

    public void Selected()
    {
        world.selectedSkin = next;
        if (next == 0)
        {
            ybot.SetActive(true);
            xbot.SetActive(false);
        }
        else
        {
            ybot.SetActive(false);
            xbot.SetActive(true);
        }
    }
}

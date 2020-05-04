using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ID.Core;

namespace ID.UI
{
    public class RoundTextUpdater : MonoBehaviour
    {
        string currentRound;

        [SerializeField] bool highScore = false;

        void Update() 
        {
            if (!highScore)
            {
                string roundText = FindObjectOfType<WorldController>().Round.ToString();
                if (currentRound != roundText)
                    currentRound = roundText;
                GetComponent<TextMeshProUGUI>().text = roundText;
            }
            else
                GetComponent<TextMeshProUGUI>().text = FindObjectOfType<WorldController>().highRound.ToString();
        }
    }
}


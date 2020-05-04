using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ID.Core;

namespace ID.UI
{
    public class DodgedTextUpdater : MonoBehaviour
    {
        string currentAmount;

        [SerializeField] bool highScore = false;

        void Update()
        {
            if (!highScore)
            {
                string dodgedText = FindObjectOfType<WorldController>().BallsDodged.ToString();

                if (currentAmount != dodgedText)
                    currentAmount = dodgedText;

                GetComponent<TextMeshProUGUI>().text = dodgedText;
            }
            
            else
                GetComponent<TextMeshProUGUI>().text = FindObjectOfType<WorldController>().highScore.ToString();
        }
    }
}


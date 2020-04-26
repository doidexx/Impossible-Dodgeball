using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
                {
                    IconAnimator IconAnimator = GetComponentInParent<IconAnimator>();
                    if (IconAnimator != null)
                        GetComponentInParent<IconAnimator>().StartAniamtion();
                    currentRound = roundText;
                }
                GetComponent<Text>().text = roundText;
            }
            else
            {
                GetComponent<Text>().text = FindObjectOfType<WorldController>().highRound.ToString();
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
                {
                    IconAnimator IconAnimator = GetComponentInParent<IconAnimator>();
                    if (IconAnimator != null)
                        GetComponentInParent<IconAnimator>().StartAniamtion();
                    currentAmount = dodgedText;
                }
                GetComponent<Text>().text = dodgedText;
            }
            else
            {
                GetComponent<Text>().text = FindObjectOfType<WorldController>().highScore.ToString();
            }
        }
    }
}


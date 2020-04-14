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

        void Update()
        {
            string dodgedText = FindObjectOfType<World_3>().BallsDodged.ToString();
            if (currentAmount != dodgedText)
            {
                IconAnimator IconAnimator = GetComponentInParent<IconAnimator>();
                if (IconAnimator != null)
                    GetComponentInParent<IconAnimator>().StartAniamtion();
                currentAmount = dodgedText;
            }
            GetComponent<Text>().text = dodgedText;
        }
    }
}


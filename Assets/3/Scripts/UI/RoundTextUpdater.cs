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

        void Update() 
        {
            string roundText = FindObjectOfType<World_3>().Round.ToString();
            if (currentRound != roundText)
            {
                IconAnimator IconAnimator = GetComponentInParent<IconAnimator>();
                if (IconAnimator != null)
                    GetComponentInParent<IconAnimator>().StartAniamtion();
                currentRound = roundText;
            }
            GetComponent<Text>().text = roundText;
        }
    }
}


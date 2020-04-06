using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ID.Core;

namespace ID.UI
{
    public class RoundTextUpdater : MonoBehaviour
    {
        void Update() 
        {
            var roundText = FindObjectOfType<World_3>().Round.ToString();
            GetComponent<Text>().text = roundText;
        }
    }
}


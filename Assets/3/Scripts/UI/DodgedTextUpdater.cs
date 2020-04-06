using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ID.Core;

namespace ID.UI
{
    public class DodgedTextUpdater : MonoBehaviour
    {
        void Update() 
        {
            var dodgedText = FindObjectOfType<World_3>().BallsDodged.ToString();
            GetComponent<Text>().text = dodgedText;
        }
    }
}


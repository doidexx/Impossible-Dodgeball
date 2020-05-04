using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Fireworks : MonoBehaviour
{
    [SerializeField] VisualEffect visualEffect;

    bool isPlaying = false;

    public void Activate(bool a)
    {
        if (a)
        {
            if (!isPlaying)
            {
                visualEffect.Play();
                isPlaying = true;
            }
        }

        else
        {
            visualEffect.Stop();
            isPlaying = false;
        }
    }
}

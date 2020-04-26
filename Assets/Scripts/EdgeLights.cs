using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeLights : MonoBehaviour
{
    [SerializeField] [Range(-5f, 5f)] float minBrightness, maxBrightness;
    [SerializeField] [Range(0f, 2f)] float smoothness;
    float intensity = 0f;
    float targetIntensity = -3f;

    void Update()
    {
        if (intensity >= maxBrightness)
            targetIntensity = minBrightness;
        else if (intensity <= minBrightness)
            targetIntensity = maxBrightness;

        intensity = Mathf.MoveTowards(intensity, targetIntensity, smoothness * Time.deltaTime);

        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red * intensity);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ID.UI
{
    public class BallPreviewBehavior : MonoBehaviour
    {
        [Header("Positioning Settings")]
        [SerializeField] float leftPoint = -1.22f;
        [SerializeField] float rightPoint = 1.22f;
        [SerializeField] float smooth = 2f;

        Vector3 positionA, positionB, newPosition;

        void Start()
        {
            positionA = new Vector3(leftPoint, 0, transform.position.z);
            positionB = new Vector3(rightPoint, 0, transform.position.z);
            newPosition = positionA;
        }

        void Update()
        {
            if (transform.localPosition == positionA)
                newPosition = positionB;
            if (transform.localPosition == positionB)
                newPosition = positionA;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, newPosition, smooth * Time.deltaTime);
        }
    }
}


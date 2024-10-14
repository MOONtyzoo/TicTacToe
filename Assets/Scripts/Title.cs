using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public float hoverAmplitude;
    public float hoverRate;
    public float rotationAmplitude;
    public float rotationRate;

    public Vector2 basePosition;

    void Update()
    {
        Vector2 hoverOffset = new Vector2(0.0f, hoverAmplitude*(float)Math.Cos(Time.time*hoverRate));
        transform.localPosition = basePosition + hoverOffset;

        float angleOffset = rotationAmplitude*(float)Math.Sin(Time.time*rotationRate);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, angleOffset); 
    }
}

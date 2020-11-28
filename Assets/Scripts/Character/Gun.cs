using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Gun
{
    [Header("Beam type")]
    public TrashType beamType;
    public float force;

    [Header("Visuals")]
    [Range(0.1f, 0.5f)]
    public float width = 0.2f;
    [Range(10, 100)]
    public float distortion = 25;
    [Range(0, 5)]
    public float speed = 0.8f;
    [Range(0, 5)]
    public float frequency = 0.5f;
    [Range(0.1f, 1f)]
    public float noiseScale = 0.2f;
    public Color color;

}

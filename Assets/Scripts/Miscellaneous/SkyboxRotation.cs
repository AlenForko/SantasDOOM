using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    private readonly float _rotationSpeed = 1.2f;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * _rotationSpeed);
    }
}

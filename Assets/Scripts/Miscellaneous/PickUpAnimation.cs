using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAnimation : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;

    public float maxY;
    public float minY;

    private float currentY;

    private Vector3 _initialPos;

    private void Start()
    {
        currentY = maxY;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));

        if (maxY - transform.localPosition.y < 0.1f)
        {
            currentY = minY;
        }

        if (transform.localPosition.y - minY < 0.1f)
        {
            currentY = maxY;
        }
        transform.position = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, currentY, Time.deltaTime * speed),
            transform.localPosition.z);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayAnimation : MonoBehaviour
{
    public Rigidbody sleighBody;

    public float speed = 5f;
    private void FixedUpdate()
    {
        sleighBody.AddForce(Vector3.left * speed, ForceMode.Acceleration);
            if (sleighBody.transform.position.x < -100f) Destroy(gameObject);
    }
}

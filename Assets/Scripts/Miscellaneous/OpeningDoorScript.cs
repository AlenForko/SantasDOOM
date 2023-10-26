using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoorScript : MonoBehaviour
{
    public bool keyRequired;
    public Animator leftAnimator;
    public Animator rightAnimator;

    public bool reqKey1, reqKey2, reqKey3;

    void OpenGate()
    {
        leftAnimator.SetBool("Open", true);
        rightAnimator.SetBool("Open", true);
        leftAnimator.GetComponentInChildren<BoxCollider>().enabled = false;
        rightAnimator.GetComponentInChildren<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (keyRequired)
            {
                if (reqKey1 && collision.gameObject.GetComponent<Inventory>().hasKey1)
                {
                    //open door
                    OpenGate();
                }
                
                if (reqKey2 && collision.gameObject.GetComponent<Inventory>().hasKey2)
                {
                    OpenGate();
                    //open door
                }
                
                if (reqKey3 && collision.gameObject.GetComponent<Inventory>().hasKey3)
                {
                    //open door
                    OpenGate();
                }
            }
        }
    }
}

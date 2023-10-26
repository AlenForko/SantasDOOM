using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.VFX;

public class CharacterRotation : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Vector3Int axis = new Vector3Int(-1, 1, 0);
    public float maxXRotation = 45f;
    public float minXRotation = -45f;

    Vector3 direction;
    Vector3 localEuler = Vector3.zero;
    Vector3 cameraRotation;
    Vector3 bodyRotation;

    public Vector3 RotationEuler
    {
        get {
            return localEuler;
            }
    }

    private void Start()
    {
        localEuler = new Vector3(transform.localEulerAngles.x, transform.parent.localEulerAngles.y, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(direction,Vector3.zero) > 0.00001f)
        {
            localEuler += direction * rotationSpeed; //Vector3.Lerp(localEuler,localEuler+direction, Time.fixedDeltaTime*rotationSpeed);
            localEuler.x = Mathf.Clamp(localEuler.x, minXRotation, maxXRotation);
            cameraRotation = new Vector3(localEuler.x, 0, 0);
            bodyRotation = new Vector3(0, localEuler.y, 0);
            transform.localRotation = Quaternion.Euler(cameraRotation);
            GetComponentInParent<Rigidbody>().MoveRotation(Quaternion.Euler(bodyRotation));
        }
        direction /= 2f;
    }

    public void MouseAxisChange(Vector2 mouseAxis)
    {
        mouseAxis.Normalize();
        Vector3 newDirection = new Vector3(mouseAxis.y, mouseAxis.x, 0);
        newDirection.Normalize();
        newDirection.Scale(axis);
        direction += newDirection;
    }
}

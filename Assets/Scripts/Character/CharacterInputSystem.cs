using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AxisChange: UnityEvent<Vector2>
{

}

[System.Serializable]
public class Axis3DChange : UnityEvent<Vector3>
{

}

public class CharacterInputSystem : MonoBehaviour
{
    public float mouseSensitivity = 0.1f;
    public AxisChange mouseAxisChange;
    public Axis3DChange movementAxisChange;

    public UnityEvent onFireDown;
    public UnityEvent onFire;
    public UnityEvent onFireUp;

    public UnityEvent<int> numericPress;
    public UnityEvent<float> mouseScroll;

    Vector2 mouseAxis = Vector2.zero;
    Vector3 movementAxis = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            mouseAxis.x = Input.GetAxis("Mouse X");
            mouseAxis.y = Input.GetAxis("Mouse Y");
            if (mouseAxis.x > mouseSensitivity || mouseAxis.y > mouseSensitivity || mouseAxis.x < -mouseSensitivity || mouseAxis.y < -mouseSensitivity)
            {
                mouseAxisChange.Invoke(mouseAxis);
            }
            else
            {
                mouseAxisChange.Invoke(Vector2.zero);
            }

            movementAxis.x = Input.GetAxis("Horizontal");
            movementAxis.z = Input.GetAxis("Vertical");
            movementAxis.y = Input.GetAxis("Jump");
            if (movementAxis.x != 0 || movementAxis.y != 0 || movementAxis.z != 0)
            {
                movementAxisChange.Invoke(movementAxis);
            }
            else
            {
                movementAxisChange.Invoke(Vector3.zero);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                onFireDown.Invoke();
            }

            if (Input.GetButton("Fire1"))
            {
                onFire.Invoke();
            }

            if (Input.GetButtonUp("Fire1"))
            {
                onFireUp.Invoke();
            }

            if (Input.inputString != "")
            {
                int number;
                bool is_a_number = int.TryParse(Input.inputString, out number);
                if (is_a_number && number >= 0 && number < 10)
                {
                    numericPress.Invoke(number);
                }
            }

            if (!Input.mouseScrollDelta.y.Equals(0))
            {
                mouseScroll.Invoke(Input.mouseScrollDelta.y);
            }
        }

    }
}

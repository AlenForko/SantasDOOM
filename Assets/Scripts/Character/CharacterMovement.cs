using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=10f;
    public float groundCheckDistance;
    public LayerMask groundLayers;
    public float timeFromGround = 0.5f;
    public WeaponControlSystem weaponSystem;
    public WalkingAudioController walkingAudioController;

    Vector3 currentAxis = Vector3.zero;
    Vector3 currentPosition;
    Vector3 nextPosition;
    float currentTimeFromGround;
    Rigidbody rb;

    private void Start()
    {
        rb = transform.parent.gameObject.GetComponent<Rigidbody>();
        currentTimeFromGround = timeFromGround;
        currentPosition =nextPosition= transform.parent.position;
    }

    public void CharacterMoved(Vector3 movementAxisChange)
    {
        currentAxis = movementAxisChange * speed;
    }

    private void FixedUpdate()
    {
        if(!Physics.Raycast(currentPosition, Vector3.down, groundCheckDistance, groundLayers))
        {
            if (currentAxis.magnitude > 1f)
            {
                currentAxis /= 2f;
            }
        }
        
        currentPosition = transform.parent.position;
        if (Vector3.Distance(currentAxis, Vector3.zero) > 0.0001f)
        {
            nextPosition = Vector3.zero;
            nextPosition += currentAxis.z * transform.parent.forward;
            nextPosition += currentAxis.x * transform.parent.right;
            nextPosition.y = rb.velocity.y;
            rb.velocity = nextPosition;
            weaponSystem.CurrentWeapon.WalkingSet(true);
            
        }
        currentAxis /= 2f;

        if(currentAxis.magnitude < 0.1f)
        {
            currentAxis = Vector3.zero;
            weaponSystem.CurrentWeapon.WalkingSet(false);
        }

        walkingAudioController.Walking(currentAxis.magnitude);
    }

}

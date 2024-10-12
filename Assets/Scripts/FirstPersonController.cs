using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FirstPersonController : MonoBehaviour
{
    public CharacterController controller;
    public float groundAcceleration;
    public float airAcceleration;
    public float gravity;
    public float maxSpeed;
    public float maxFallSpeed;
    public float jumpHeight;
    public Vector3 velocity = Vector3.zero;

    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;

    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        //Acceleration & deceleration
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (grounded) velocity.x += groundAcceleration * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
            else velocity.x += airAcceleration * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
        }
        else if (grounded)
        {
            //Make sure we don't overshoot when doing deceleration 
            if (Mathf.Sign(velocity.x - groundAcceleration * Mathf.Sign(velocity.x)) != Mathf.Sign(velocity.x)) velocity.x = 0f;
            else velocity.x -= groundAcceleration * Mathf.Sign(velocity.x);
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (grounded) velocity.z += groundAcceleration * Mathf.Sign(Input.GetAxisRaw("Vertical"));
            else velocity.z += airAcceleration * Mathf.Sign(Input.GetAxisRaw("Vertical"));
        }
        else if (grounded)
        {
            //Make sure we don't overshoot when doing deceleration 
            if (Mathf.Sign(velocity.z - groundAcceleration * Mathf.Sign(velocity.z)) != Mathf.Sign(velocity.z)) velocity.z = 0f;
            else velocity.z -= groundAcceleration * Mathf.Sign(velocity.z);
        }


        if (!grounded) velocity.y += gravity * -9.81f * Time.deltaTime;
        if (grounded) velocity.y = 0f;

        if (Input.GetButton("Jump") && grounded) velocity.y = jumpHeight;

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -maxFallSpeed, 999);
        velocity.z = Mathf.Clamp(velocity.z, -maxSpeed, maxSpeed);

        //Apply the rotation to the velocity
        Vector3 move = transform.rotation * velocity;

        controller.Move(move * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float gravity;
    public float maxSpeed;
    public float maxFallSpeed;
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

        float moveX = Input.GetAxisRaw("Horizontal") * speed;
        float moveY = Input.GetAxisRaw("Vertical") * speed;

        Vector3 moveVector = transform.right * moveX + transform.forward * moveY;

        if(!grounded) moveVector.y -= gravity;



        moveVector.x = Mathf.Clamp(moveVector.x, -maxSpeed, maxSpeed);
        moveVector.y = Mathf.Clamp(moveVector.y, -maxFallSpeed, 999);
        moveVector.z = Mathf.Clamp(moveVector.z, -maxSpeed, maxSpeed);

        velocity = moveVector;

        controller.Move(moveVector * Time.deltaTime);
    }
}

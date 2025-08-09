using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float gravity = -9.8f;
    public float moveSpeed = 12f;
    public float jumpHeight = 3f;

    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundCheckMask;

    private Vector3 velocity;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundCheckMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new(horizontal, 0, vertical);

        if (direction.magnitude >= 0.1)
        {
            float moveAngle = playerCamera.eulerAngles.y + Mathf.Rad2Deg * (float)Math.Atan2(direction.x, direction.z);
            Vector3 moveDirection = Quaternion.Euler(0f, moveAngle, 0f) * Vector3.forward;

            characterController.Move(moveSpeed * Time.deltaTime * moveDirection.normalized);
        }

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2 * gravity * jumpHeight);
        }
        
        characterController.Move(velocity * Time.deltaTime);
    }
}

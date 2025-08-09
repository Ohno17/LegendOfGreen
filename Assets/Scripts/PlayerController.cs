using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector3 gravity = new(0, -10, 0);
    public float moveSpeed = 34;
    public float jumpStrength = 28;
    public float velocityDampening = 0.8f;

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
        velocity *= velocityDampening;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.5f, groundCheckMask);
        Debug.Log(isGrounded);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new(horizontal, 0, vertical);

        if (direction.magnitude >= 0.1)
        {
            float moveAngle = playerCamera.eulerAngles.y + Mathf.Rad2Deg * (float)Math.Atan2(direction.x, direction.z);
            Vector3 moveDirection = Quaternion.Euler(0f, moveAngle, 0f) * Vector3.forward;

            velocity += moveSpeed * Time.deltaTime * moveDirection.normalized;
        }

        velocity += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2 * Physics.gravity.y * jumpStrength);
        }
        
        characterController.Move(velocity * Time.deltaTime);
        Debug.DrawRay(gameObject.transform.position, velocity);
    }
}

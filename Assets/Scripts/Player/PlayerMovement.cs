using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private CharacterController controller;
    private Transform groundCheck;
    private float groundDistance = 0.4f;
    public bool isGrounded;
    private Vector3 velocity;

    [Header("Assignables")]
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private float jumpHeight = 6f;
    [SerializeField] private float gravity = -120;
    [SerializeField] private float speed = 3f;

    [Header("Layer Mask")]
    [SerializeField] private LayerMask groundMask;

    [Header("Audio")]
    [SerializeField] private AudioClip footStepSound;
    [SerializeField] private float footStepDelay;
    private float nextFootstep = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * (speed * sprintMultiplier) * Time.deltaTime);
        }
        else //SPRINT
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        { 
            velocity.y = jumpHeight;
        }

	if (!isGrounded)
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);

        PlaySound();
    }


    private void PlaySound()
    {
        //Sound Effects
        if (footStepSound == null) return;

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) || !isGrounded) return;

            nextFootstep -= Time.deltaTime;
        
        if (nextFootstep > 0) return;
            
            GetComponent<AudioSource>().PlayOneShot(footStepSound, 0.7f);
            nextFootstep += footStepDelay;
            
        
    }
}


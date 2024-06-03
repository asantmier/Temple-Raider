using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float gravity = -9.81f;
    public float jumpPower;
    public float runMult;
    public Transform groundCheck;
    public float groundDistance = .15f;
    public AudioClip[] stepsStone;

    private CharacterController cc;
    private AudioSource audioSource;
    private float velocity;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        // Lock cursor to screen
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out how the player is moving forward/back/left/right
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector3 dir = transform.forward * inputV + transform.right * inputH;
        Vector3 moveVec = dir * moveSpeed;
        // And increase speed if sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVec *= runMult;
        }

        // Manually check if grounded since the CharacterController method is weird
        grounded = Physics.Raycast(groundCheck.position, Vector3.down, groundDistance, LayerMask.GetMask("Walkable"));
        // Reset velocity so it doesn't go too high. We have to keep downward force for ramps
        if (grounded && velocity < -98)
        {
            velocity = 0f;
        }
        // Add velocity for jumps
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity = jumpPower;
        }
        // Apply gravity
        velocity += gravity * Time.deltaTime;

        // Execute movement
        cc.Move((moveVec + velocity * Vector3.up) * Time.deltaTime);

        if (dir != Vector3.zero)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = stepsStone[Random.Range(0, stepsStone.Length)];
                audioSource.Play();
            }
        }
    }
}

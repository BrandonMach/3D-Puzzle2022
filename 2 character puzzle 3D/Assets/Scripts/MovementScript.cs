using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private float ySpeed;

    float horizontalInput;
    float verticalInput;

    private CharacterController characterController;
    public bool isActivePlayer;
    private float originalStepOffset;

    public CharacterController GetCharacterController
    {
        get { return characterController; }
    }
    public bool IsActivePlayer
    {
        get { return isActivePlayer; }
        set { isActivePlayer = value; }
    }


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset - 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();



        ySpeed += Physics.gravity.y * Time.deltaTime;

        GroundCheck();
        
        



        Vector3 velocity = movementDirection * magnitude; // velocity Y is 0 from movemnetDirecton
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void Movement()
    {
        if (isActivePlayer)//Cant move if object is not active player
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
    }

    public void GroundCheck()
    {
        if (characterController.isGrounded)
        {
            ySpeed = -0.5f;

            characterController.stepOffset = originalStepOffset;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }

    }
    
}

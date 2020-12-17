using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{   
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    public CharacterController CharacterController;
    public float SPRINTING_SPEED = 10;
    public float JOGGING_SPEED = 6;
    public float JumpForce = 9.87f;
    public bool sprinting = false;
    public bool swimming = false;

    public float speed = 0;

    private Vector3 jumpForwardMomentum;
    private float gravity = 20f;
    private float verticalSpeed = 0;
    private PlayerStatsManager PlayerStats;

    private void Move()
    {
        sprinting = Input.GetKey(KeyCode.LeftShift);
        bool JumpKeyDown = Input.GetKey(KeyCode.Space);

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        verticalSpeed -= gravity * Time.deltaTime;


       if(CharacterController.isGrounded)
        if (sprinting && !swimming && PlayerStats.canSprint)
        {
            speed = SPRINTING_SPEED;
            PlayerStats.EmptySprint(Time.deltaTime);
            if (PlayerStats.CurrentSprintCharge <= 0)
                PlayerStats.canSprint = false;
            
        }
        else
        {
            
            speed = JOGGING_SPEED;
            PlayerStats.RechargeSprint();
            if (!PlayerStats.canSprint)
                if (PlayerStats.CurrentSprintCharge >= PlayerStats.sprintDuration)
                    PlayerStats.canSprint = true;
        }


        if (CharacterController.isGrounded && JumpKeyDown)
        {
            verticalSpeed += gravity * JumpForce;
            jumpForwardMomentum = speed * Time.deltaTime * (transform.forward * verticalMove + horizontalMove * transform.right);
        }

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        Vector3 jumpMove = new Vector3(0, 0, 0);
        Vector3 move;
        if (CharacterController.isGrounded)
        {
            move = transform.forward * verticalMove + horizontalMove * transform.right;
            CharacterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
            if(jumpForwardMomentum != Vector3.zero)
                jumpForwardMomentum = Vector3.zero;
        }
        else
        {
            move = transform.forward * verticalMove + horizontalMove * transform.right;
            //Stéphane: ( ͡° ͜ʖ ͡°)ᕤ JE fais bugger le code hihihih.
            //Simon: (ง ͠° ͟ل͜ ͡°)ง Et moi j'le bat à mort ton code, héhéhé!
            jumpForwardMomentum += move * speed * Time.deltaTime
            CharacterController.Move(gravityMove * Time.deltaTime + jumpForwardMomentum);

        }

        
    }

    private void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");


        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation* mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);

    }

    void Update()
    {
        Move();
        Rotate();
    }

    private void Awake()
    {
        PlayerStats = this.GetComponent<PlayerStatsManager>();
        
    }
}

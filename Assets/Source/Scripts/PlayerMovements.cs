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

    //private Vector3 //jumpForwardMomentum;
    private float gravity = 20f;
    private float verticalSpeed = 0;
    private PlayerStatsManager PlayerStats;
    private Animator animator;

    private void Move()
    {
        sprinting = Input.GetKey(KeyCode.LeftShift);
        bool JumpKeyDown = Input.GetKey(KeyCode.Space);

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");




        if (CharacterController.isGrounded)
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
        else
            verticalSpeed -= gravity * Time.deltaTime;

        if (CharacterController.isGrounded && JumpKeyDown)
        {
            verticalSpeed += gravity * JumpForce;
            //jumpForwardMomentum = speed * Time.deltaTime * (cameraHolder.transform.forward * verticalMove + horizontalMove * cameraHolder.transform.right);
        }
       
            //jumpForwardMomentum = Vector3.zero;

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        Vector3 jumpMove = new Vector3(0, 0, 0);
        Vector3 move;
        if (CharacterController.isGrounded)
        {
            float rotation = transform.localEulerAngles.y;
            if(verticalMove < 0)
            {
                if (horizontalMove != 0)
                {
                    rotation = (cameraHolder.transform.localEulerAngles.y) + horizontalMove * -45 - 180;
                }
                else
                    rotation = (cameraHolder.transform.localEulerAngles.y) - 180;
            }
            else if(verticalMove > 0)
            {
                if (horizontalMove != 0)
                {
                    rotation = (cameraHolder.transform.localEulerAngles.y) + horizontalMove * 45;
                }
                else
                    rotation = (cameraHolder.transform.localEulerAngles.y);
            }
            else if( horizontalMove != 0)
                rotation = (cameraHolder.transform.localEulerAngles.y) + horizontalMove * 90;
           








            move = cameraHolder.transform.forward * verticalMove + horizontalMove * cameraHolder.transform.right;
            transform.localRotation = Quaternion.Euler(new Vector3 (0, rotation, 0));
            CharacterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
            /*if(//jumpForwardMomentum != Vector3.zero)
                //jumpForwardMomentum = Vector3.zero;*/
        }
        else
        {
            Debug.Log(transform.forward);
            move = speed*(cameraHolder.transform.forward * verticalMove + horizontalMove * cameraHolder.transform.right);
            CharacterController.Move(gravityMove * Time.deltaTime + (move * Time.deltaTime)); //jumpForwardMomentum);

        }
        animator.SetBool("Jumping", !CharacterController.isGrounded);
        animator.SetBool("isSprinting", sprinting && PlayerStats.canSprint);
        animator.SetFloat("CurrentSpeed", (speed * Time.deltaTime * move).magnitude);
        cameraHolder.transform.position = this.transform.position;
    }

    private void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        float horizontalMove = Input.GetAxis("Horizontal") * 90;
        float verticalMove = Input.GetAxis("Vertical") * 90 ;


        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0 , 0);
        cameraHolder.Rotate(0, horizontalRotation * mouseSensitivity, 0);


        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        if (currentRotation.y > 180) currentRotation.y -= 360;
        currentRotation.z = 0;
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
        animator = this.GetComponent<Animator>();

        

    }
}

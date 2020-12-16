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

    private float gravity = 20f;
    private float verticalSpeed = 0;


    private void Move()
    {
        sprinting = Input.GetKey(KeyCode.LeftShift);
        bool JumpKeyDown = Input.GetKey(KeyCode.Space);

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (CharacterController.isGrounded)
            verticalSpeed = 0;
        else
            verticalSpeed -= gravity * Time.deltaTime;

        if (sprinting && !swimming)
            speed = SPRINTING_SPEED;
        else
            speed = JOGGING_SPEED;


        if (CharacterController.isGrounded && JumpKeyDown)
            verticalSpeed += gravity * JumpForce;

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        Vector3 jumpMove = new Vector3(0, 0, 0);
        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;

        CharacterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
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
}

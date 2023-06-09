using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charController;
    private CharacterAnimation playerAnimation;

    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreePerSecond = 180f;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        playerAnimation = GetComponent<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        else
        {
            charController.Move(Vector3.zero); 
        }
    }

    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);

        }
        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);

        }
        if(rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreePerSecond * Time.deltaTime);
        }


    }
    void AnimateWalk()
    {
        if(charController.velocity.sqrMagnitude != 0)
        {
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
    }
}

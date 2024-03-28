using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    public float movement_Speed = 3f;
    public float gravity = 9.8f;
    public float rotation_Speed = 0.15f;
    public float rotateDegreesPerSecond = 180f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
    }

    void Movement()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
        else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection * movement_Speed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        Vector3 rotation_Direction = Vector3.zero;

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.left);
        }
        else if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotation_Direction = transform.TransformDirection(Vector3.right);
        }

        if (rotation_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotation_Direction),
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }
}

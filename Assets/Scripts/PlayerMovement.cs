using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float Speed = 10f;
    public Rigidbody rb;

    public bool playerIslive = true;

    public Joystick joystick;

    public CameraMovement camScript;
    bool isThisMobile;

    private void Start()
    {
        camScript.checkPlatform();
        isThisMobile = camScript.isMobile;
    }


    private void FixedUpdate()
    {
        if (playerIslive)
        {
            if (isThisMobile)
            {
                float x = joystick.Horizontal;
                float z = joystick.Vertical;

                Vector3 Move = transform.right * x + transform.forward * z;

                controller.Move(Move * Speed * Time.deltaTime);
            }

            else
            {
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 Move = transform.right * x + transform.forward * z;

                controller.Move(Move * Speed * Time.deltaTime);
            }

        }
    }
}
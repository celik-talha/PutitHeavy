using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseSens = 5f;
    public GameObject Player;

    public bool camIsLive = true;

    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseSens = PlayerPrefs.GetFloat("MOUSESENS",5f);
    }

    void FixedUpdate()
    {
        if (camIsLive)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSens;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            Player.transform.Rotate(Vector3.up * mouseX);
        }
    }
}

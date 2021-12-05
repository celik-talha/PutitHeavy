using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseSens;
    public GameObject Player;

    public bool camIsLive = true;

    float yRotation = 0f;

    public bool isMobile = false;

    float deltaX = 0f;
    float deltaY = 0f;
    Vector2 origRoot = Vector2.zero;

    Vector2 firstpoint, secondpoint;
    float xAngle, yAngle, xAngTemp, yAngTemp;

    void Start()
    {
        checkPlatform();
        mouseSens = PlayerPrefs.GetFloat("MOUSESENS", 5f);
        if (isMobile)
        {
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void FixedUpdate()
    {
        if (camIsLive)
        {
            if (isMobile)
            {
                foreach (var touchA in Input.touches)
                {
                    Touch newTouch = touchA;
                    if (newTouch.position.x > Screen.width / 3f)
                    {
                        if (newTouch.phase == TouchPhase.Began)
                        {
                            origRoot = newTouch.position;
                        }
                        else if (newTouch.phase == TouchPhase.Moved)
                        {
                            deltaX = (origRoot.x - newTouch.position.x) / (-5f * mouseSens);
                            deltaY = deltaY + (origRoot.y - newTouch.position.y) / (5f * mouseSens);
                            Debug.Log(deltaX + "   " + deltaY);
                            transform.localRotation = Quaternion.Euler(deltaY, 0f, 0f);
                            Player.transform.Rotate(Vector3.up * deltaX);
                            origRoot = newTouch.position;
                        }
                        else if (newTouch.phase == TouchPhase.Ended)
                        {
                            Debug.Log("CCCCCCCCCCC");
                        }
                    }
                }
            }
            else
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSens;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSens;

                yRotation -= mouseY;
                yRotation = Mathf.Clamp(yRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
                Player.transform.Rotate(Vector3.up * mouseX);
            }
        }
    }
    public void checkPlatform()
    {
        if (Application.platform==RuntimePlatform.IPhonePlayer||Application.platform==RuntimePlatform.Android)
        {
            isMobile = true;
        }
        else if (Application.platform==RuntimePlatform.OSXEditor)
        {
            isMobile = false;
        }
        else
        {
            isMobile = false;
        }
        Debug.Log(Application.platform);
    }
    
}

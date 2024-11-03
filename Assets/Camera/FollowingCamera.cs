using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float panSpeed = 10f;

    bool cameraToggle = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            cameraToggle = !cameraToggle;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Vector3.Lerp is a linear interpolation between two vectors
        //transform.position = smoothedPosition;
        if (cameraToggle)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Vector3.Lerp is a linear interpolation between two vectors
            transform.position = smoothedPosition;
        }
        else
        {
            // if the mouse is outside the screen, the camera will pan accordingly

            Vector3 cameraPos = transform.position;
            Vector3 mousePosition = Input.mousePosition;

            if (mousePosition.x < 0)
            {
                cameraPos.x -= 1 * Time.deltaTime* panSpeed;
            }
            if (mousePosition.x > Screen.width)
            {
                cameraPos.x += 1 * Time.deltaTime * panSpeed;
            }
            if (mousePosition.y < 0)
            {
                cameraPos.z -= 1 * Time.deltaTime * panSpeed;
            }
            if (mousePosition.y > Screen.height)
            {
                cameraPos.z += 1 * Time.deltaTime * panSpeed;
            }
            transform.position = cameraPos;

        }

    }
}

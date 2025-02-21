using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float camX, camY;
    public float camSensitivity = 7f;
    public float cameraDistanc = 10f;

    //camera min and max hight restrictions
    public float min, max;
    //player reference
    public Transform targetToFollow;
    //camera Rotate
    Vector3 camRotation;
    Vector3 currentVel;
    public float smoothRotateTime = 0.10f;
    //public FixedJoystick camStick;


    // Update is called once per frame
    void LateUpdate()
    {
        camY += Input.GetAxis("Mouse X"); //get inputs
        camX -= Input.GetAxis("Mouse Y"); //get inputs
                                          //camY += camStick.Horizontal;
                                          //camX -= camStick.Vertical;

        //clamp the camera
        camX = Mathf.Clamp(camX, min, max);
        camRotation = Vector3.SmoothDamp(camRotation, new Vector3(camX, camY), ref currentVel, smoothRotateTime);
        transform.eulerAngles = camRotation; //rotate camera

        //follow player/targetToFollow
        transform.position = targetToFollow.position - transform.forward * cameraDistanc;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraLookAt : MonoBehaviour
{
    public Transform ball;        // This creates the slot in Inspector
    public Vector3 offset = new Vector3(0, 5, -10);

    void LateUpdate()
    {
        transform.position = ball.position + offset;
        // transform.LookAt(ball); // optional if you want the camera to always look at the ball
    }
}

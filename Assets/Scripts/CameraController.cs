using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.04f;
    public Vector3 right;
    public Vector3 left;
    public Vector3 center;
    public Vector3 up;
    public Vector3 down;
    private Vector3 desiredPosition;
    private float camerashift;
    public float offset2;
    public float temp;
    // Update is called once per frame
    void FixedUpdate()
    {
        right = new Vector3(4f, 0f, -10f);
        left = new Vector3(-4f, 0f, -10f);
        center = new Vector3(0f, 0f, -10f);
        up = new Vector3(0f, 4f, -10f);
        down = new Vector3(0f, -4f, -10f);
        temp = offset2;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal == 1f)
        {
            desiredPosition = target.position + right;
        }else if(moveHorizontal == -1f)
        {
            desiredPosition = target.position + left;
        }
        else
        {
            desiredPosition = target.position + center;
        }
        if(moveVertical == 1f)
        {
            desiredPosition = target.position + up;
        }else if (moveVertical == -1f)
        {
            desiredPosition = target.position + down;
        }


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private float camerashift;

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal == 1f)
        {
            camerashift = 1f;
        }else if(moveHorizontal == -1)
        {
            camerashift = -1f;
        }
        if(offset.x < 0 && camerashift == -1f)
        {
            offset = new Vector3(offset.x, offset.y, offset.z);
        }else if (offset.x < 0 && camerashift == 1f)
        {
            offset = new Vector3((-1)*offset.x, offset.y, offset.z);
        }
        else if (offset.x > 0 && camerashift == 1f)
        {
            offset = new Vector3(offset.x, offset.y, offset.z);
        }
        else if (offset.x > 0 && camerashift == -1f)
        {
            offset = new Vector3((-1) * offset.x, offset.y, offset.z);
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }



}


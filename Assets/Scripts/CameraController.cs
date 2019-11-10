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
    private Animator anim;
    private Vector3 desiredPosition;
    private float camerashift;
    public float temp = 1f;
    // Update is called once per frame
    void FixedUpdate()
    {

        right = new Vector3(0.5f, 0f, -10f);
        left = new Vector3(-0.5f, 0f, -10f);
        center = new Vector3(0f, 0f, -10f);
        up = new Vector3(0f, 1f, -10f);
        down = new Vector3(0f, -1f, -10f);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        desiredPosition = target.position + center;
        if (moveHorizontal >=0.5f)
        {
            temp = 1f;
            //desiredPosition = target.position + right;
            desiredPosition = target.position + center;
        }
        else if(moveHorizontal <= -0.5f)
        {
            temp = -1f;
            //desiredPosition = target.position + left;
            desiredPosition = target.position + center;
        }
        else
        {
            whenStationary(moveHorizontal);

        }
        if (moveVertical == 1f)
        {
            whenStationary(moveHorizontal);
            desiredPosition += up;
            
        }else if (moveVertical == -1f)
        {
            whenStationary(moveHorizontal);
            desiredPosition += down;
            
        }


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private void whenStationary(float moveHorizontal)
    {
        if (moveHorizontal == 0f)
        {
            if (temp == 1f)
            {
                desiredPosition = target.position + right;
            }
            else if (temp == -1f)
            {
                desiredPosition = target.position + left;
            }
            //desiredPosition = target.position + center;
        }
    }



}

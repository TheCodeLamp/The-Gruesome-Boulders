using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MplayerMove : MonoBehaviour
{
    [Header("Input Variables")]
    [Range(0.2f, 0.3f)]
    public float moveSpeed;

    public float jumpStrength;
    
    [HideInInspector]
    public int moveDirX, moveDirY;
    public CameraM camScript;

    private float horizontalAxis;
    private float jumpAxis;
    private Vector3 deltaMove = new Vector3();
    private Collider2D playercol;

    private void FixedUpdate()
    {
        MoveInput();
    }

    void MoveInput()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
      
        if (horizontalAxis > 0)
        {
            moveDirX = 1;
        }
        else if (horizontalAxis < 0)
        {
            moveDirX = -1;
        }
        else
        {
            moveDirX = 0;
        }
        
        deltaMove.x = moveDirX * moveSpeed;

        jumpAxis = Input.GetAxis("Jump");

        if(jumpAxis > 0)
        {
            moveDirY = 1;
        }
        else
        {
            moveDirY = 0;
        }

        deltaMove.y = moveDirY * jumpStrength;
        
        //Apply Changes
        transform.position += deltaMove;
        camScript.UpdateCameraPos();
    }
}
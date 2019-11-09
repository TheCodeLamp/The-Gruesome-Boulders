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
    private Vector3 deltaMove = new Vector3();

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
        
        //Apply Changes
        transform.position += deltaMove;
        camScript.UpdateCameraPos();
    }
}
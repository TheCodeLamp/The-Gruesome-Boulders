using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    [Header("Camera Sensitivity")]
    public int horizontalOffset;
    public float smoothnessX, smoothnessY;
    [Header("Player Reference")]
    public GameObject playerObj;

   
    private float hDiff, vDiff; // Skillnad i x och y-led.
    private Vector3 playerScreenPos; // Spelarens position på skärmen.
    private Camera mainCam; //Referens till kameran som detta script sitter på.
    private MplayerMove playerScript;
    private int cameraOffset;
    

    void FixedUpdate()
    {
        GetScreenPos();
    }

    void GetScreenPos()
    {
        playerScreenPos = mainCam.WorldToScreenPoint(playerObj.transform.position);
    }
    
    public void UpdateCameraPos()
    {
        if(playerScript.moveDirX > 0)
        {
            // Titta åt hö
            cameraOffset = horizontalOffset;
        }
        else if(playerScript.moveDirX < 0)
        {
            // Titta åt vänster
            cameraOffset = -horizontalOffset;

        }
        else
        {
            // cameraOffset = cameraOffset / 4;
            cameraOffset = 0;
        }

        // Horizontal
        float targetPosX = playerObj.transform.position.x + cameraOffset;
        float currentX = transform.position.x;
        currentX += (targetPosX - currentX) * smoothnessX;

        // Vertical
        float targetPosY = playerObj.transform.position.y;
        float currentY = transform.position.y;
        currentY += (targetPosY - currentY) * smoothnessY;
        // x += (target - x) * 0.1;

        transform.position = new Vector3(currentX, currentY, transform.position.z);
  
    }

    private void OnEnable()
    {
        mainCam = GetComponent<Camera>();
        GetScreenPos();
        playerScript = playerObj.GetComponent<MplayerMove>();
        playerScript.camScript = this;
        transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y, -10f);
    }
}

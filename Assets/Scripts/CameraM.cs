using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    [Header("Camera Sensitivity")]
    [Range(0.0f, 1.0f)]
    public float horizontalSens;
    [Range(0.0f, 1.0f)]
    public float verticalSens;
    [Header("Player Reference")]
    public GameObject playerObj;

   
    private float hDiff, vDiff; // Skillnad i x och y-led.
    private Vector3 playerScreenPos; // Spelarens position på skärmen.
    private Camera mainCam; //Referens till kameran som detta script sitter på.

    void FixedUpdate()
    {
        GetScreenPos();
        CheckPlayerMove();
    }

    void GetScreenPos()
    {
        playerScreenPos = mainCam.WorldToScreenPoint(playerObj.transform.position);
    }
    
    void CheckPlayerMove()
    {

    }

    private void OnEnable()
    {
        mainCam = GetComponent<Camera>();
    }
}

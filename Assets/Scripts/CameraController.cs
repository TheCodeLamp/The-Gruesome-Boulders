using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float boostSpeed;
    public GameObject player;
    private float distanceX;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if(moveHorizontal == 1f)
        {
            Vector3 cameraChange = new Vector3(0.01f, 0, 0);
            cam.transform.position += cameraChange;
        }
        else if (moveHorizontal == -1f)
        {
            Vector3 cameraChange = new Vector3(-0.01f, 0, 0);
            cam.transform.position += cameraChange;
        }
    }

    float getDistance()
    {
        distanceX = player.transform.position.x - transform.position.x;
        return distanceX;
    }
    
}

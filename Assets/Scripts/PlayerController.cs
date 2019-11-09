using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input Variables")]
    public float walkSpeed;

    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D p1;
    public float moveX;
    public float direction;
    void Start()
    {
        p1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        if(moveHorizontal > 0)
        {
            moveX = 1f;
            direction = 1f;

        }else if(moveHorizontal < 0)
        {
            moveX = -1f;
            direction = 1f;
        }
        else
        {
            moveX = 0f;
        }
        p1.transform.position = new Vector3(p1.transform.position.x + moveX*speed, p1.transform.position.y, p1.transform.position.z);



    }


}

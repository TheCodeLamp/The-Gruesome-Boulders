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
    public float jumpForce;
    public float jumpCap;
    public float jumpFrame;
    void Start()
    {
        p1 = GetComponent<Rigidbody2D>();
        jumpFrame = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        float jumpValue = Input.GetAxis("Jump");
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
        if(jumpValue > 0 && jumpFrame < jumpCap)
        {
            p1.AddForce(new Vector2(0f, jumpValue * jumpForce));
            jumpFrame++;
        }

        p1.transform.position = new Vector3(p1.transform.position.x + moveX*speed, p1.transform.position.y , p1.transform.position.z);
       
        //p1.GetComponent<BoxCollider2D>().OverlapCollider

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumpFrame = 0f;
    }
    private void OnTriggerExit2D(Collider2D other)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        jumpFrame = 0f;
    }
}

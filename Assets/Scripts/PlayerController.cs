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
    private Animator anim;
    private bool jumped;
    private bool charge;
    public float partsCapacity = 100f;
    private float parts = 0f;
    private float ability1;
    void Start()
    {
        anim = GetComponent<Animator>();
        p1 = GetComponent<Rigidbody2D>();
        jumpFrame = 0f;
        charge = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        float jumpValue = Input.GetAxis("Jump");
        ability1 = Input.GetAxis("Fire1");
        if (ability1 == 1)
        {
            if (parts >= 10f)
            {
                parts -= 10f;

            }
            if (moveHorizontal > 0)
            {
                anim.SetBool("IsRunning", true);
                moveX = 1f;
                direction = 1f;
                var angles = transform.rotation.eulerAngles;
                angles.y = 180;
                p1.transform.rotation = Quaternion.Euler(angles);

            }
            else if (moveHorizontal < 0)
            {
                anim.SetBool("IsRunning", true);
                moveX = -1f;
                direction = 1f;
                var angles = transform.rotation.eulerAngles;
                angles.y = 0;
                p1.transform.rotation = Quaternion.Euler(angles);
            }
            else
            {
                anim.SetBool("IsRunning", false);
                moveX = 0f;
            }
            if (jumpValue > 0 && jumpFrame < jumpCap && !charge && !jumped && !Input.GetKey(KeyCode.LeftShift))
            {
                jumpForce = 350f;
                //anim.SetBool("IsJumping", true);
                p1.AddForce(new Vector2(0f, jumpValue * jumpForce));
                jumpFrame++;
                jumped = true;
                jumpForce = 0f;
            }

            //Här börjar chargejump extra feature
            if (jumpValue == 1f && (Input.GetKey(KeyCode.LeftShift) || charge) && !jumped)
            {
                if (jumpForce < 500)
                {
                    jumpForce += 10f;
                }
                charge = true;

            }

            if (jumpValue == 0f && Input.GetKey(KeyCode.LeftShift) && !jumped)
            {
                jumped = true;
                p1.AddForce(new Vector2(0f, jumpForce));
                jumpForce = 0f;
                charge = false;
            }
            else
            {
                anim.SetBool("IsJumping", false);
            }

            p1.transform.position = new Vector3(p1.transform.position.x + moveX * speed, p1.transform.position.y, p1.transform.position.z);

            //p1.GetComponent<BoxCollider2D>().OverlapCollider


            print(parts);
        }
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                jumpFrame = 0f;
                jumped = false;
            }


        }
        void OnTriggerExit2D(Collider2D other)
        {

        }
        void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("ground"))
            {
                jumpFrame = 0f;
                jumped = false;
            }
            if (collision.gameObject.CompareTag("machine") && Input.GetKey(KeyCode.E))
            {
                if (parts < partsCapacity)
                {
                    parts += 0.5f;

                }
            }

        }
    }
}

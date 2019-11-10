using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input Variables")]
    public float walkSpeed;

    // Start is called before the first frame update

    public Transform firepoint;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;
    public Transform firepoint5;
    public float speed;
    public Rigidbody2D p1;
    public GameObject playerGameObj;
    public float moveX;
    public float direction;
    public float jumpForce;
    public float jumpCap;
    public float jumpFrame;
    private Animator anim;
    private bool jumped;
    private bool charge;
    public float partsCapacity = 100f;
    public float parts = 0f;

    public GameObject scrapPrefab;
    private float ability1;
    public float costAbility1;
    private bool ability1Pressed;
    public GameObject spikesPrefab;
    private float ability2;
    public float costAbility2;
    private bool ability2Pressed;
    public GameObject combustionPrefab;
    public GameObject combustionPrefab2;
    public GameObject combustionPrefab3;
    public GameObject explosionglobalboi;
    private float ability3;
    public float costAbility3;
    private bool ability3Pressed;

    public GameObject rotationAxis; 
    public CircleCollider2D ability3collider;
    public List<CircleCollider2D> objects;
    public CircleCollider2D[] colliders;
    public GameObject explosionBOI;
    public GameObject explosionBOI2;
    public GameObject explosionBOI3;
    //Make sure you attach a Rigidbody in the Inspector of this GameObject
    public Rigidbody m_Rigidbody;
    public Vector3 m_EulerAngleVelocity;
    void Start()
    {
        anim = GetComponent<Animator>();
        p1 = GetComponent<Rigidbody2D>();
        jumpFrame = 0f;
        charge = false;
        combustionPrefab.SetActive(false);
        combustionPrefab2.SetActive(false);
        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, 180, 0);

        //Fetch the Rigidbody from the GameObject with this script attached
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        float jumpValue = Input.GetAxis("Jump");

        //Handles ability1
        ability1 = Input.GetAxis("Fire1");
        if(ability1 == 1f)
        {
            ability1Pressed = true;
        }
        if (ability1 == 0f)
        {
            if (parts >= costAbility1 && ability1Pressed)
            {
                parts -= costAbility1;
                Instantiate(scrapPrefab, firepoint.position, firepoint.rotation);
            }
            ability1Pressed = false;
        }
        //Handles ability2
        ability2 = Input.GetAxis("Fire2");
        if (ability2 == 1f && !jumped)
        {
            ability2Pressed = true;
        }
        if (ability2 == 0f)
        {
            if (parts >= costAbility2 && ability2Pressed)
            {
                parts -= costAbility2;
                Instantiate(spikesPrefab, firepoint4.position, firepoint4.rotation);
            }
            ability2Pressed = false;
        }

        //Handles ability3
        ability3 = Input.GetAxis("Fire3");
        if (ability3 == 1f)
        {
            ability3Pressed = true;
        }
        if (ability3 == 0f)
        {
            if (parts >= costAbility3 && ability3Pressed)
            {
                parts -= costAbility3;
                print("pangpang");
                combustionPrefab.SetActive(true);


                //(Instantiate(explosionobject, firepoint5.position, firepoint5.rotation) as GameObject).transform.parent = playerGameObj.transform;
            }
            ability3Pressed = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            combustionPrefab.SetActive(false);
            combustionPrefab2.SetActive(true);
            combustionPrefab3.SetActive(true);
            print("pooooof");

        }
        if(Input.GetKeyUp(KeyCode.O))
        {
            combustionPrefab2.SetActive(false);
            combustionPrefab3.SetActive(false);
        }
       
        if (Input.GetKeyDown(KeyCode.P))
        {
            explosionBOI.SetActive(true);

            if (direction == 1f)
            {
                explosionBOI.transform.position = new Vector3(p1.transform.position.x -
            direction * Mathf.Abs(p1.transform.position.x - explosionBOI.transform.position.x),
                explosionBOI.transform.position.y, explosionBOI.transform.position.z);
            }
            if (direction == -1f)
            {
                explosionBOI.transform.position = new Vector3(p1.transform.position.x +
            direction * Mathf.Abs(p1.transform.position.x - explosionBOI.transform.position.x),
                explosionBOI.transform.position.y, explosionBOI.transform.position.z);
            }

        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            explosionBOI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            explosionBOI.SetActive(false);
            explosionBOI2.SetActive(true);
            explosionBOI3.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            explosionBOI2.SetActive(false);
            explosionBOI3.SetActive(false);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            explosionglobalboi.transform.RotateAround(p1.transform.position, Vector3.forward, -200f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.R))
        {
            explosionglobalboi.transform.RotateAround(p1.transform.position, Vector3.forward, 200f * Time.deltaTime);
        }

        if (moveHorizontal > 0f)
        {
            anim.SetBool("IsRunning", true);
            moveX = 1f;
            direction = 1f;
            var angles = transform.rotation.eulerAngles;
            angles.y = 180;
            p1.transform.rotation = Quaternion.Euler(angles);


        }
        else if(moveHorizontal < 0f)
        {
            anim.SetBool("IsRunning", true);
            moveX = -1f;
            direction = -1f;
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
            jumpForce = 3500f;
            anim.SetBool("IsJumping", true);
            p1.AddForce(new Vector2(0f, jumpValue * jumpForce));
            jumpFrame++;
            jumped = true;
            jumpForce = 0f;

        }

        //Här börjar chargejump extra feature
        if(jumpValue == 1f && (Input.GetKey(KeyCode.LeftShift) || charge) && !jumped)
        {
            anim.SetBool("IsJumping", true);
            if (jumpForce < 5000)
            {
                jumpForce+=100f;
            }
            charge = true;

        }

        if(jumpValue == 0f && Input.GetKey(KeyCode.LeftShift) && !jumped)
        {
            anim.SetBool("IsJumping", true);
            jumped = true;
            p1.AddForce(new Vector2(0f, jumpForce));
            jumpForce = 0f;
            charge = false;
        }

        p1.transform.position = new Vector3(p1.transform.position.x + moveX*speed, p1.transform.position.y , p1.transform.position.z);

        //p1.GetComponent<BoxCollider2D>().OverlapCollider



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            resetJump();
        }


    }
    public void resetJump()
    {
        anim.SetBool("IsJumping", false);
        jumpFrame = 0f;
        jumped = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {

            resetJump();
        }
        if (collision.gameObject.CompareTag("machine") && Input.GetKey(KeyCode.E))
        {
            if(parts < partsCapacity)
            {
                parts+=0.5f;

            }
        }

    }

    public void explode()
    {
        explosionBOI.SetActive(false);
        explosionBOI2.SetActive(true);

    }




}

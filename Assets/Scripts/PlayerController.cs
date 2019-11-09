﻿using System.Collections;
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
    public Rigidbody p2;
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
    public GameObject explosionobject;
    private float ability3;
    public float costAbility3;
    private bool ability3Pressed;

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
        if (ability2 == 1f)
        {
            ability2Pressed = true;
        }
        if (ability2 == 0f)
        {
            if (parts >= costAbility2 && ability2Pressed)
            {
                parts -= costAbility2;
                Instantiate(spikesPrefab, firepoint2.position, firepoint2.rotation);
                Instantiate(spikesPrefab, firepoint3.position, firepoint3.rotation);
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
                Instantiate(explosionobject, firepoint5.position, firepoint5.rotation);
            }
            ability3Pressed = false;
        }

        if (moveHorizontal > 0)
        {
            anim.SetBool("IsRunning", true);
            moveX = 1f;
            direction = 1f;
            var angles = transform.rotation.eulerAngles;
            angles.y = 180;
            p1.transform.rotation = Quaternion.Euler(angles);

        }else if(moveHorizontal < 0)
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
        if(jumpValue > 0 && jumpFrame < jumpCap && !charge && !jumped && !Input.GetKey(KeyCode.LeftShift))
        {
            jumpForce = 350f;
            anim.SetBool("IsJumping", true);
            p1.AddForce(new Vector2(0f, jumpValue * jumpForce));
            jumpFrame++;
            jumped = true;
            jumpForce = 0f;
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }

        //Här börjar chargejump extra feature
        if(jumpValue == 1f && (Input.GetKey(KeyCode.LeftShift) || charge) && !jumped)
        {
            anim.SetBool("IsJumping", true);
            if (jumpForce < 500)
            {
                jumpForce+=10f;
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
        else
        {
            anim.SetBool("IsJumping", false);
        }

        p1.transform.position = new Vector3(p1.transform.position.x + moveX*speed, p1.transform.position.y , p1.transform.position.z);

        //p1.GetComponent<BoxCollider2D>().OverlapCollider



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpFrame = 0f;
            jumped = false;
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpFrame = 0f;
            jumped = false;
        }
        if (collision.gameObject.CompareTag("machine") && Input.GetKey(KeyCode.E))
        {
            if(parts < partsCapacity)
            {
                parts+=0.5f;

            }
        }

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDetectScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController pc;
    public BoxCollider2D theBox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            pc.resetJump();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            pc.resetJump();
        }
    }
}

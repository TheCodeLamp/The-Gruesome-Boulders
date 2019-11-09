﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesScript : MonoBehaviour
{
    public GameObject spikes;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spikes.GetComponent<Rigidbody2D>().velocity = transform.up * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ground")){
            Destroy(spikes);
        }   
        if(collision.gameObject.CompareTag("machine")){
            Destroy(spikes);
        }
        
    }
}

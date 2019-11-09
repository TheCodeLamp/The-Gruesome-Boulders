using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraptScript : MonoBehaviour
{

    public Rigidbody2D scrap;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrap.velocity = transform.right * speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraptScript : MonoBehaviour
{

    public GameObject scrap;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scrap.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scrap.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(scrap);
    }
}

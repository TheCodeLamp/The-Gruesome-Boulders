using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public GameObject explosionobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(explosionobject, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(explosionobject);
            

      
        }
        if (Input.GetButtonDown("Submit"))
        {
            explosionobject.GetComponent<PointEffector2D>().forceMagnitude *= -1f;
        }

    }
}

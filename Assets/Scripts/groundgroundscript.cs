using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundgroundscript : MonoBehaviour
{
    // Start is called before the first frame update  
    public PlayerController pc2;
    public BoxCollider2D theBox2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pc2 = collision.gameObject.GetComponentInParent<PlayerController>();
            pc2.resetJump();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}

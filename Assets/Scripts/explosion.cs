using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{

    // Start is called before the first frame update
    public float horizontal;
    public float dir;
    public GameObject player;
    public GameObject thiseOne;
    void Start()
    {
        thiseOne.SetActive(false);
        dir = -1f;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if(horizontal == 1f)
        {
            dir = 1f;
        }
        if(horizontal == -1f)
        {
            dir = -1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && dir == -1f)
        {
            collision.gameObject.transform.position = new Vector3(player.transform.position.x + (player.transform.position.x - collision.gameObject.transform.position.x),
                collision.gameObject.transform.position.y, collision.gameObject.transform.position.y);
        }else if (Input.GetKeyDown(KeyCode.LeftArrow) && dir == 1f)
        {
            collision.gameObject.transform.position = new Vector3(player.transform.position.x - (player.transform.position.x - collision.gameObject.transform.position.x),
                collision.gameObject.transform.position.y, collision.gameObject.transform.position.y);
        }
    }
}

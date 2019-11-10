using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Patrol : MonoBehaviour
{
    public float startWaitTime;
    private float waitTime;
    public float speed;
    public Transform[] moveSpots;
    public int randomSpot;
    public GameObject target;
    public Collider2D finded;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Found");
            finded.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
   

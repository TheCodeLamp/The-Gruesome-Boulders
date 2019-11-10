using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{

    public GameObject target;
    private BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("NextLevel");
        NextLevel();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Dead()
    {
        Debug.Log("Dead");
        Application.Quit();
    }

}

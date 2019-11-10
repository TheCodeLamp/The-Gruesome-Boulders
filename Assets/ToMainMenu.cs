using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    private float startTime;
    
    private void Awake()
    {
        startTime = Time.time;
    }

    private void OnGUI()
    {
        
        Event e = Event.current;
        if (e.isKey && Time.time - startTime > 5)
        {
            SceneManager.LoadScene(0);
        }
    }
}

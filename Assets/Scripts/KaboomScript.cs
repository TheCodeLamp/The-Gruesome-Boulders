using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaboomScript : MonoBehaviour
{
    private float kaboomTime;

    private void FixedUpdate()
    {
        if(Time.time - kaboomTime > .8f)
        {
            RemoveKaboom();
        }
    }

    void RemoveKaboom()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        kaboomTime = Time.time;
    }
}

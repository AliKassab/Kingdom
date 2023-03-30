using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject Tower;
    [SerializeField] bool isPlaceable = false;
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(Tower, transform.position, Quaternion.identity);
            isPlaceable= false;
        };
        
    }
}

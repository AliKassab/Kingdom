using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;

    [SerializeField] bool isPlaceable = false;
    public bool Isplaceable
    { get { return isPlaceable; } }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = tower.CreateTower(tower, transform.position);
            isPlaceable= !isPlaced;
        };
        
    }
}

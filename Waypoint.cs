using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }
    

    void OnMouseDown()
    {
        if(isPlaceable)
        {
        bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
        // Instantiate(towerPrefab, transform.position, Quaternion.identity)
        // without this line, you can place multiple ballista on the same waypoint. this line makes it so you can only place one:
        isPlaceable = !isPlaced;
        }
    }
}

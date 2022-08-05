using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
        // get method to get similar to  
        //  public bool GetisPlaceable()
        // {
        //     return isPlaceable;
        // }
        // but just cleaner
    }
    void OnMouseDown()
    {
        int num = Random.Range(0, 2);
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }

}

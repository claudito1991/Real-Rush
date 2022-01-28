using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    [SerializeField] Tower tower;
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            bool isPlaced = tower.CreateTower(towerPrefab, transform.position, transform.rotation);
            //Instantiate(tower, transform.position,tower.transform.rotation);
            Debug.Log(transform.name);
            isPlaceable = !isPlaced; //para que no pueda volver a poner una torre si hay una torre puesta
        }
        
    }
}

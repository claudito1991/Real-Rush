using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    [SerializeField] GameObject tower;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            Instantiate(tower, transform.position,tower.transform.rotation);
            Debug.Log(transform.name);
            isPlaceable = false; //para que no pueda volver a poner una torre si hay una torre puesta
        }
        
    }
}

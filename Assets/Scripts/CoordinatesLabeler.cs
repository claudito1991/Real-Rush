using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinatesLabeler : MonoBehaviour
{
    [SerializeField] Color colorAvailable = Color.white;
    [SerializeField] Color colorBlocked = Color.gray;
    TextMeshPro text;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;
    
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            ObjectRename();
        }
        ColorCoordinates();
        ToogleLabels();
    }

    private void ToogleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            text.enabled = !text.IsActive();
        }

 
    }

    private void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            text.color = colorAvailable;
            text.faceColor = colorAvailable;
        }

        else
        {
            text.color = colorBlocked;
            text.faceColor = colorBlocked;
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        text.text = coordinates.x + "," + coordinates.y;
    }

    void ObjectRename()
    {
        transform.parent.name = coordinates.ToString();
    }
}

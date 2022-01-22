using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinatesLabeler : MonoBehaviour
{
    TextMeshPro text;
    Vector2Int coordinates = new Vector2Int();
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            ObjectRename();
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

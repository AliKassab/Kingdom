using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent< TextMeshPro >();
    }

    // Update is called once per frame
    void Update()
    {
       // if (!Application.isPlaying)
       // {
            DisplayCoordinates();
            UpdateName();
      //  }
    }

    private void UpdateName()
    {
        transform.parent.name = label.text;
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = "(" + coordinates.x + "," + coordinates.y + ")";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color availablecolor = Color.white;
    [SerializeField] Color blockedcolor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    Waypoint waypoint;

    private void Awake()
    {
        label = GetComponent< TextMeshPro >();
        label.enabled= false;
        waypoint = GetComponentInParent< Waypoint >();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCoordinates();
        UpdateName();

        ChangeLabelColour();
        ToggleCoordinates();

    }

    private void ToggleCoordinates()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            label.enabled = !label.IsActive();

        }
    }

    private void ChangeLabelColour()
    {
        if (waypoint.Isplaceable)
        {
            label.color = availablecolor;
        }
        else
        {
            label.color = blockedcolor;
        }
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

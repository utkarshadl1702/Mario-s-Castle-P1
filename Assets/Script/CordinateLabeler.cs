using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
public class CordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    TextMeshPro label;
    Vector2Int cordinates = new Vector2Int();
    WayPoint wayPoint;
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = true;
        wayPoint = GetComponentInParent<WayPoint>();
        DisplayCordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {

            DisplayCordinates();
            UpdateObjectName();
        }

        ColorCordinates();
        ToggleLabel();
    }

    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void ColorCordinates()
    {
        if (wayPoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }
    void DisplayCordinates()
    {
        cordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        cordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = cordinates.x + "," + cordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = "Tile  " + cordinates.ToString();

    }
}

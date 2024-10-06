using System;
using UnityEngine;

public class BrickMovingScript : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    // A scrip that moves the brick when clicked on and mouse is dragged around following th mouse cursor
    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        isDragging = true;
    }
    
    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }
 }

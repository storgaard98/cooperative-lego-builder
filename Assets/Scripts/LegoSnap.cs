using System;
using UnityEngine;

public class LegoSnap : MonoBehaviour
{

    public float snapThreshold = 0.2f;
    public Vector2Int brickSize = new Vector2Int(2, 4);
    public float cylinderSpacing = 0.03f;
    
    private Transform closestBrick = null;

    // Update is called once per frame
    private void OnMouseUp()
    {
        TrySnapToNearestBrick();
    }

    void TrySnapToNearestBrick()
    {
        // Initializing closestBrick and setting an arbitrary large value for the minimum distance
        closestBrick = null;
        float minDistance = Mathf.Infinity;  // We start with an infinitely large distance

        // Find the closest brick only
        LegoSnap[] allBricks = FindObjectsOfType<LegoSnap>();

        foreach (var otherBrick in allBricks)
        {
            if (otherBrick == this) continue;  // Skip comparing with itself

            float distance = Vector3.Distance(transform.position, otherBrick.transform.position);

            if (distance < minDistance)
            {
                closestBrick = otherBrick.transform;  // Update closest brick
                minDistance = distance;  // Update the minimum distance
            }
        }

        // If a closest brick was found, snap to it
        if (closestBrick != null)
        {
            SnapToBrick();
        }
    }

    void SnapToBrick()
    {
        // Calculate the snap position based on the closest brick
        Vector3 targetPosition = CalculateSnapPosition(transform.position, closestBrick);

        // Snap the current brick to the calculated position
        transform.position = targetPosition;

        // Align rotation with the closest brick
        transform.rotation = closestBrick.rotation;

        // Check if either brick is already part of a LegoGroup
        Transform existingGroup = closestBrick.parent != null ? closestBrick.parent : transform.parent;

        if (existingGroup == null)
        {
            Debug.Log("Du kom her ind.");
            // Neither brick is part of a group, so create a new LegoGroup
            GameObject combinedGroup = new GameObject("LegoGroup");
            combinedGroup.transform.position = closestBrick.position;
            combinedGroup.transform.rotation = closestBrick.rotation;

            AddToParentGroup(combinedGroup.transform);
        }
        else
        {
            AddToParentGroup(existingGroup);
        }
    }

    void AddToParentGroup(Transform parentGroup)
    {
        // Set the parent group for both bricks
        Debug.Log("the CloestBrick: " + closestBrick.transform.name + " This Brick: " + transform.name);
        Debug.Log("paretnGroup: " + parentGroup.name);
        closestBrick.SetParent(parentGroup);
        transform.SetParent(parentGroup);
    }


    Vector3 CalculateSnapPosition(Vector3 currentPosition, Transform otherBrick)
    {
        // Offset position relative to the center of the other brick
        Vector3 relativePosition = currentPosition - otherBrick.position;

        // Calculate the cylinder grid position for the other brick
        Vector2Int otherBrickSize = otherBrick.GetComponent<LegoSnap>().brickSize;
        Vector3 nearestCylinderPosition = FindNearestCylinderPosition(relativePosition, otherBrickSize);
        
        
        // Return the global position to snap to
        return otherBrick.position + nearestCylinderPosition;
    }

    Vector3 FindNearestCylinderPosition(Vector3 relativePosition, Vector2Int otherBrickSize)
    {
        // Calculate grid positions along X and Z axes based on cylinder spacing
        float halfWidth = (otherBrickSize.x - 1) / 2f * cylinderSpacing;
        float halfLength = (otherBrickSize.y - 1) / 2f * cylinderSpacing;

        // Round the relative position to the nearest cylinder grid point
        float closestX = Mathf.Round(relativePosition.x / cylinderSpacing) * cylinderSpacing;
        float closestZ = Mathf.Round(relativePosition.z / cylinderSpacing) * cylinderSpacing;

        // Clamp values to stay within the bounds of the other brick's grid
        closestX = Mathf.Clamp(closestX, -halfWidth, halfWidth);
        closestZ = Mathf.Clamp(closestZ, -halfLength, halfLength);

        return new Vector3(closestX, 0, closestZ);
    }
}

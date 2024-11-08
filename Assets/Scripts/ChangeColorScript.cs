using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform rightPointingFinger;
    
    
    public Color activeColor = Color.red;  // Default color
    
    public void SetBlueColor()
    {
        activeColor = Color.blue;
        Debug.LogWarning("Color changed to blue");
    }
    
    public void SetRedColor()
    {
        activeColor = Color.red;
        Debug.LogWarning("Color changed to red");
    }
    
    public void SetGreenColor()
    {
        activeColor = Color.green;
        Debug.LogWarning("Color changed to green");
    }
    
    public void SetYellowColor()
    {
        activeColor = Color.yellow;
        Debug.LogWarning("Color changed to yellow");
    }
    
    // Update is called once per frame
    void Update()
    {
        // Cast a ray from the right pointing finger's position forward
        Ray ray = new Ray(rightPointingFinger.position, rightPointingFinger.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Check if the object hit has a Brick component
            GameObject brick = hit.collider.GetComponent<GameObject>();
            if (brick != null)
            {   
                Debug.LogWarning("Brick hit");
                // Change the brick's color to the active color
                brick.GetComponent<Renderer>().material.color = activeColor;
            }
        }

    }
}

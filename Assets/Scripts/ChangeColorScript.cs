using UnityEngine;

public class ChangeColorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform rightPointingFinger;
    
    
    private Color activeColor = Color.red;  // Default color
    
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
        // Set up a ray from the rightPointingFinger's position and direction
        Ray ray = new Ray(rightPointingFinger.position, rightPointingFinger.forward);
        RaycastHit hit;
        // Perform the raycast and check if it hits something
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("Brick"))
            {
                Debug.Log("Hit object contains 'BRICK' in its name: " + hit.collider.name);
                Renderer renderer = hit.collider.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Debug.Log("Renderer found on the hit object. Changing color to activeColor." + activeColor);
                    renderer.material.color = activeColor;
                }
            }
        }
    }
}

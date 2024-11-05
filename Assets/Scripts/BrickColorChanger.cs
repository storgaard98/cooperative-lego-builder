using System;
using UnityEngine;

public class BrickColorChanger : MonoBehaviour
{
        [SerializeField] private Material brickMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(brickMaterial == null)
        {
            Debug.LogWarning("Brick material is not set");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Collided with: " + other.transform.name);
        if (other.transform.name.Contains("Brick"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = brickMaterial;
            }
        }
    }
}

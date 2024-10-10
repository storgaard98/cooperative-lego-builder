using System.Runtime.CompilerServices;
using UnityEngine;

public class LegoBrickScript : MonoBehaviour
{

    public LayerMask snapLayer;

    public float snapForce = 100f;

    public float snapDistance = 0.1f;
    
    private Rigidbody rb;

    private Collider snapZoneCollider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        snapZoneCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (1<<other.gameObject.layer == snapLayer.value)
        {
            Debug.Log("you should snap now!");
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance >= snapDistance)
            {
                Debug.Log("Within Distance");
                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("snapping");

                    Vector3 direction = other.transform.position - transform.position;
                    rb.AddForce(direction.normalized * snapForce * Time.deltaTime);
                }
                
            }
        }
    }
}

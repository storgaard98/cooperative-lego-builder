using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FollowtHandWithRoation : MonoBehaviour
{
    [SerializeField] GameObject HandToFollow;
    [SerializeField] private GameObject visuals;
    void Start()
    {
     
    }

    void Update()
    {
        // Update position

        var position = HandToFollow.transform.position;
        transform.position = new Vector3(position.x, (position.y + 0.025f), (position.z - 0.025f));
        //Debug.LogWarning("Wrist position: " + position);
        //Debug.LogWarning("Wrist rotation: " + HandToFollow.transform.rotation);
        
        // Check if wrist is up or down
        var wristX = HandToFollow.transform.rotation.x;
        var wristY = HandToFollow.transform.rotation.y;
        var wristZ = HandToFollow.transform.rotation.z;
        
        //Debug.LogWarning("Wrist, y: " + wristX);
        //Debug.LogWarning("Wrist, x: " + wristY);
        //Debug.LogWarning("Wrist, z: " + wristZ);
        
        // Check if wrist is up or down
        var wristUp = -0.03;
        var wristMid = -0.58;
        var wristDown = -0.8;
        
        if (wristZ > wristMid)
        {
            Debug.LogWarning("Wrist is up");
            visuals.SetActive(true);
        }
        else if (wristZ < wristMid && wristZ > wristDown)
        {
            Debug.LogWarning("Wrist is mid");
        }
        else
        {
            Debug.LogWarning("Wrist is down");
            visuals.SetActive(false);
        }


        // Update rotation
        //var rotation = HandToFollow.transform.rotation;
        // transform.rotation = rotation;
    }
}
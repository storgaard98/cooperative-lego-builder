using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FollowtHandWithRoation : MonoBehaviour
{
    [SerializeField] private GameObject handToFollow;
    void Start()
    {
     
    }

    void Update()
    {
        // Update position
        var position = handToFollow.transform.position;
        transform.position = new Vector3(position.x, (position.y + 0.025f), (position.z - 0.025f));
    }
}
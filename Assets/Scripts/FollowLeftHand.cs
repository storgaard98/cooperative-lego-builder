using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FollowLeftHand : MonoBehaviour
{
    [SerializeField] private GameObject handToFollow;
    [SerializeField] private float offSetY;
    [SerializeField] private float offSetZ;

    [SerializeField] private Camera targetCamera;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(
            handToFollow.transform.position.x, 
            (handToFollow.transform.position.y + offSetY),
            (handToFollow.transform.position.z + offSetZ));
        
        transform.LookAt(targetCamera.transform, Vector3.up);
        transform.Rotate(0, 180, 0);
    }
}
using UnityEngine;

public class VRVigReferences : MonoBehaviour
{
    public static VRVigReferences singleton;
    
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    
    private void Awake()
    {
        singleton = this;
    }
}

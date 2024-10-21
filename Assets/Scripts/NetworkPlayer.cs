using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    public Renderer[] meshToDisable;


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            foreach (var item in meshToDisable)
            {
                item.enabled = false;
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if(IsOwner)
        {
        root.position = VRVigReferences.singleton.root.position;
        root.rotation = VRVigReferences.singleton.root.rotation;
        
        head.position = VRVigReferences.singleton.head.position;
        head.rotation = VRVigReferences.singleton.head.rotation;
        
        leftHand.position = VRVigReferences.singleton.leftHand.position;
        leftHand.rotation = VRVigReferences.singleton.leftHand.rotation;
        
        rightHand.position = VRVigReferences.singleton.rightHand.position;
        rightHand.rotation = VRVigReferences.singleton.rightHand.rotation;
        }
    }
}

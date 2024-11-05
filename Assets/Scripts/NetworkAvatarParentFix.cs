using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkAvatarParentFix : MonoBehaviour
{
    public GameObject avatarPrefab;
    public float parentingDelay = 1f;

    public void SpawnAvatar()
    {
        GameObject avatar = Instantiate(avatarPrefab);

        OVRCameraRig vrRIG = FindObjectsOfType<OVRCameraRig>()[0];
        
        vrRIG.transform.position = new Vector3(0, 0, 5); 
        
        StartCoroutine(DelayParenting(avatar, vrRIG.gameObject));
    }
    
    IEnumerator DelayParenting(GameObject avatar, GameObject vrRIG)
    {
        yield return new WaitForSeconds(parentingDelay);
        avatar.transform.SetParent(vrRIG.transform);
    }
}

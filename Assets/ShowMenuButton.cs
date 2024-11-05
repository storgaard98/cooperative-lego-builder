using UnityEngine;
using UnityEngine.Serialization;

public class ShowMenuButton : MonoBehaviour
{
    [SerializeField] GameObject handToFollow;
    [SerializeField] private GameObject menuButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if wrist is up or down
        var wristZ = handToFollow.transform.rotation.z;
        
        // Check if wrist is up or down
        var wristUp = -0.03;
        var wristMid = -0.58;
        var wristDown = -0.8;
        
        if (wristZ > wristMid)
        {
            menuButton.SetActive(true);
        }
        else if (wristZ < wristMid && wristZ > wristDown)
        {
        }
        else
        {
            menuButton.SetActive(false);
        }
    }
}

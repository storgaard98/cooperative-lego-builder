using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class NewScriptableObjectScript : ScriptableObject
{

    public void prefaf()
    {
        Instantiate(GameObject.Find("prefab"));
    }
    
}

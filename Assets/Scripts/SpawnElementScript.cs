using System;
using UnityEngine;
using System.Collections.Generic;

public class SpawnElementScript : MonoBehaviour
{
    [System.Serializable]
    public class SpawnInfo
    {
        public GameObject prefab;       // Object to spawn
        public Vector3 spawnPosition;   // Spawn position
        public String brickId;
    }
    public List<SpawnInfo> spawnInfosList;

    private Dictionary<String, SpawnInfo> spawnInfos = new Dictionary<String, SpawnInfo>();

    void Start()
    {
        foreach (SpawnInfo spawnInfo in spawnInfosList)
        {
            spawnInfos.Add(spawnInfo.brickId, spawnInfo);
        }
    }
    
    public void Spawn1x2Brick()
    {
        if (spawnInfos.ContainsKey("1x2Brick"))
        {
            Instantiate(spawnInfos["1x2Brick"].prefab, spawnInfos["1x2Brick"].spawnPosition, Quaternion.identity);
        }
    }
    
    public void spawn1x4Brick()
    {
        if (spawnInfos.ContainsKey("1x4Brick"))
        {
            Instantiate(spawnInfos["1x4Brick"].prefab, spawnInfos["1x4Brick"].spawnPosition, Quaternion.identity);
        }
    }

    public void Spawn2x2Brick()
    {
        if (spawnInfos.ContainsKey("2x2Brick"))
        {
            Instantiate(spawnInfos["2x2Brick"].prefab, spawnInfos["2x2Brick"].spawnPosition, Quaternion.identity);
        }
    }

    public void Spawn2x4Brick()
    {
        if (spawnInfos.ContainsKey("2x4Brick"))
        {
            Instantiate(spawnInfos["2x4Brick"].prefab, spawnInfos["2x4Brick"].spawnPosition, Quaternion.identity);
        }
    }
}
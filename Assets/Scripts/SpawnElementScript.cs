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

    void Spawn2x2Brick()
    {
        if (spawnInfos.ContainsKey("2x2Brick"))
        {
            Instantiate(spawnInfos["2x2Brick"].prefab, spawnInfos["2x2Brick"].spawnPosition, Quaternion.identity);
        }
    }

    void Spawn2x4Brick()
    {
        if (spawnInfos.ContainsKey("2x4Brick"))
        {
            Instantiate(spawnInfos["2x4Brick"].prefab, spawnInfos["2x4Brick"].spawnPosition, Quaternion.identity);
        }
    }
}
using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.Netcode;

public class SpawnElementScript : NetworkBehaviour
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
            GameObject brick = Instantiate(spawnInfos["1x2Brick"].prefab, spawnInfos["1x2Brick"].spawnPosition, Quaternion.identity);
            var instanceNetworkObject = brick.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }
    }
    
    public void spawn1x4Brick()
    {
        if (spawnInfos.ContainsKey("1x4Brick"))
        {
            GameObject brick = Instantiate(spawnInfos["1x4Brick"].prefab, spawnInfos["1x4Brick"].spawnPosition, Quaternion.identity);
            var instanceNetworkObject = brick.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }
    }

    public void Spawn2x2Brick()
    {
        if (spawnInfos.ContainsKey("2x2Brick"))
        {
            GameObject brick = Instantiate(spawnInfos["2x2Brick"].prefab, spawnInfos["2x2Brick"].spawnPosition, Quaternion.identity);
            var instanceNetworkObject = brick.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }
    }

    public void Spawn2x4Brick()
    {
        if (spawnInfos.ContainsKey("2x4Brick"))
        {
            GameObject brick = Instantiate(spawnInfos["2x4Brick"].prefab, spawnInfos["2x4Brick"].spawnPosition, Quaternion.identity);
            var instanceNetworkObject = brick.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }
    }
}
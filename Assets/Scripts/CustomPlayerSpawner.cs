using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class CustomPlayerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    private int nextSpawnIndex = 0;

    private List<NetworkObject> spawnedPlayers = new List<NetworkObject>(); // Track spawned players

    private void Start()
    {
        // Register a callback when a client connects
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }

   private void OnClientConnected(ulong clientId)
    {
        // Only the server should handle player spawning
        if (!NetworkManager.Singleton.IsServer)
        {
            return;
        }

        // Find the next available spawn point
        int spawnIndex = nextSpawnIndex;
        nextSpawnIndex = (nextSpawnIndex + 1) % spawnPoints.Length;

        // Start a coroutine to wait for the player to spawn and move it to the correct position
        StartCoroutine(WaitForPlayerToSpawn(clientId, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation));
    }

    private IEnumerator WaitForPlayerToSpawn(ulong clientId, Vector3 newPosition, Quaternion newRotation)
    {
        Debug.Log($"Waiting for player {clientId} to spawn...");

        NetworkObject playerToMove = null;

        // Try to find the player object from the ConnectedClients list
        while (playerToMove == null)
        {
            // Check if the client has a corresponding NetworkObject
            if (NetworkManager.Singleton.ConnectedClients.ContainsKey(clientId))
            {
                playerToMove = NetworkManager.Singleton.ConnectedClients[clientId].PlayerObject;
            }

            // Wait for the next frame if the player is not found yet
            if (playerToMove == null)
            {
                yield return null;
            }
        }

        // Once the player is found, move it to the correct spawn position
        Debug.Log($"Player {clientId} spawned. Moving to position.");
        MovePlayerToPosition(clientId, newPosition, newRotation);
    }

    public void MovePlayerToPosition(ulong clientId, Vector3 newPosition, Quaternion newRotation)
    {
        Debug.Log("The ClientID: " + clientId);

        // Find the player's NetworkObject by clientId
        NetworkObject playerToMove = NetworkManager.Singleton.ConnectedClients[clientId].PlayerObject;

        if (playerToMove != null)
        {
            // Move player on the authoritative side (server)
            if (NetworkManager.Singleton.IsServer)
            {
                // Use the NetworkTransform to move the player
                NetworkTransform networkTransform = playerToMove.GetComponent<NetworkTransform>();

                if (networkTransform != null)
                {
                    // Apply the movement directly to the transform on the server
                    playerToMove.transform.position = newPosition;
                    playerToMove.transform.rotation = newRotation;
                
                    Debug.Log($"Moved player {clientId} to new position: {newPosition}");
                }
                else
                {
                    Debug.LogWarning("NetworkTransform component missing on player!");
                }
            }
            else
            {
                Debug.LogWarning("Attempted to move player on a non-server client!");
            }
        }
        else
        {
            Debug.LogWarning($"No player found with clientId {clientId}");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpiderSpawner : MonoBehaviour
{
    public Tilemap TunnelTilemap;
    public GameObject SpiderPrefabs;
    
    private bool isWaitingtoSpawn = false;
    void Update()
    {
        if (!isWaitingtoSpawn)
        {
            StartCoroutine(SpawnAfterDelay());
        }
    }

    private IEnumerator SpawnAfterDelay()
    {
        isWaitingtoSpawn = true;
        float delay = Random.Range(GameParameters.SpiderMinimumSpawnDelay, GameParameters.SpiderMaximumSpawnDelay);
        yield return new WaitForSeconds(delay);
        Spawn();
        isWaitingtoSpawn = false;
    }

    private void Spawn()
    {
        Vector3 spawnPosition = GetRandomTunnelPosition();
        
        Instantiate(SpiderPrefabs, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomTunnelPosition()
    {
        while (true)
        {
            Vector3 randomWorldPosition = SpawnTools.RandomLocationWorldSpace();
            
            Vector3Int cell = TunnelTilemap.WorldToCell(randomWorldPosition);
            
            if (TunnelTilemap.HasTile(cell)) 
            {
                return TunnelTilemap.GetCellCenterWorld(cell); 
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpiderSpawner : MonoBehaviour
{
    public Sounds Sounds;
    public Game game;
    public GameObject SpiderPrefabs;
    
    private bool isWaitingtoSpawn = false;
    
    void Update()
    {
        if (!game.isGameActive)
            return;
        
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
        Instantiate(SpiderPrefabs, transform.position, Quaternion.identity);
        Sounds.PlaySpiderRunSound();
    }
}

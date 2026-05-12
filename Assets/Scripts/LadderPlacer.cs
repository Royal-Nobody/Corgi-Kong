using UnityEngine;

public class LadderPlacer : MonoBehaviour
{
    public GameObject LadderPrefab;
    public Transform[] SpawnPoints;

    void Start()
    {
        Place();
    }
    
    private void Place()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(LadderPrefab, SpawnPoints[i].position, Quaternion.identity);
        }
    }
}

using UnityEngine;

public class FlySwatterPlacer : MonoBehaviour
{
    public GameObject FlySwatterPrefab;
    public Transform[] SpawnPoints;

    void Start()
    {
        Place();
    }
    
    private void Place()
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Instantiate(FlySwatterPrefab, SpawnPoints[i].position, Quaternion.identity);
        }
    }
}

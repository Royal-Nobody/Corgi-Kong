using UnityEngine;

public class FlySwatterPlacer : MonoBehaviour
{
    public GameObject FlySwatterPrefab;
    
    void Update()
    {
        Place();
    }

    private void Place()
    {
        Instantiate(FlySwatterPrefab, transform.position, transform.rotation);
    }
}

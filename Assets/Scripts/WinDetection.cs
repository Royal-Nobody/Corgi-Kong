using UnityEngine;

public class WinDetection : MonoBehaviour
{
    public GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndTile"))
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
    }
}
using UnityEngine;

public class WinDetection : MonoBehaviour
{
    public Game game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndTile"))
        {
            game.TriggerWinScreen();
        }
    }
}
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Game game;
    
    public void KillPlayer()
    {
        //Play animation of Jon dying
        
        game.TriggerGameOver();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spider"))
        {
            KillPlayer();
        }
    }
}

using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Game game;

    public int livesLeft;
    
    public void KillPlayer()
    {
        //Play animation of Jon dying
        
        game.TriggerGameOver();
    }

    public void HitPlayer()
    {
        if (livesLeft <= 0)
        {
            KillPlayer();
        }
        
        livesLeft--;
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spider"))
        {
            HitPlayer();
        }
    }
}

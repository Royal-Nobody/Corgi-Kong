using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Game game;

    public Text livesText;
    public int livesLeft;

    private void Start()
    {
        UpdateTexts();
    }

    public void KillPlayer()
    {
        game.TriggerGameOver();
    }

    public void HitPlayer()
    {
        livesLeft--;
        
        if (livesLeft <= 0)
        {
            KillPlayer();
        }
        
        game.ClearMap();
        UpdateTexts();
    }
    
    private void UpdateTexts()
    {
        livesText.text = $"Lives: {livesLeft}";
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spider"))
        {
            HitPlayer();
        }
    }
}

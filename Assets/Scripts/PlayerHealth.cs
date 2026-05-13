using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Game game;
    public Animator animator;
    public SoundEffects sounds;
    
    public Text livesText;
    public int livesLeft = GameParameters.PlayerStartingLivesCount;

    private void Start()
    {
        UpdateTexts();
    }

    public void KillPlayer()
    {
        StartCoroutine(DeathAnimation());
        game.TriggerGameOver();
        livesLeft = GameParameters.PlayerStartingLivesCount;
    }

    public void HitPlayer()
    {
        livesLeft--;
     
        sounds.PlayJonSound(SoundEffects.JonSoundType.Die, false);
        
        if (livesLeft <= 0)
        {
            KillPlayer();
        }

        StartCoroutine(DeathAnimation());
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

    IEnumerator DeathAnimation()
    {
        game.isGameActive = false;
        animator.SetBool("PlayerDied", true);

        yield return new WaitForSeconds(1.5f);
        
        game.ClearMap();
        UpdateTexts();
        animator.SetBool("PlayerDied", false);
        game.isGameActive = true;
    }
}

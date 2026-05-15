using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Update = Unity.VisualScripting.Update;

public class PlayerHealth : MonoBehaviour
{
    public Game game;
    public Animator animator;
    public SoundEffects sounds;
    
    public Text livesText;
    public int livesLeft = GameParameters.PlayerStartingLivesCount;

    public bool canGetHit = true;

    private void Start()
    {
        UpdateTexts();
    }

    public void KillPlayer()
    {
        game.TriggerGameOver();
        livesLeft = GameParameters.PlayerStartingLivesCount;
        UpdateTexts();
    }

    public void HitPlayer()
    {
        livesLeft--;
     
        sounds.PlayJonSound(SoundEffects.JonSoundType.Die, false);

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
            if(canGetHit)
            {
                HitPlayer();
            }
        }
    }

    IEnumerator DeathAnimation()
    {
        canGetHit = false;
        game.isGameActive = false;
        animator.SetBool("PlayerDied", true);

        yield return new WaitForSeconds(1.5f);
        
        game.ClearMap();
        UpdateTexts();
        animator.SetBool("PlayerDied", false);
        game.isGameActive = true;
        
        if (livesLeft <= 0)
        {
            KillPlayer();
        }
        canGetHit = true;
    }
}

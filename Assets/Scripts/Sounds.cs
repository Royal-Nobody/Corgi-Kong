using System;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip JonClimbSound;
    public AudioClip JonClimbWithFlySwatterSound;
    public AudioClip JonHitWithFlySwatterSound;
    public AudioClip JonIdleWithFlySwatterSound;
    public AudioClip JonJumpSound;
    public AudioClip JonJumpWithFlySwatterSound;
    public AudioClip JonRunSound;
    public AudioClip JonRunWithFlySwatterSound;
    public AudioClip JonTouchSpiderSound;
    public AudioClip SpiderClimbSound;
    public AudioClip SpiderRunSound;
    
    
    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJonClimbSound()
    {
        audioSource.PlayOneShot(JonClimbSound);
    }
    
    public void PlayJonClimbWithFlySwatterSound()
    {
        audioSource.PlayOneShot(JonClimbWithFlySwatterSound);
    }
    
    public void PlayJonHitWithFlySwatterSound()
    {
        audioSource.PlayOneShot(JonHitWithFlySwatterSound);
    }
    
    public void PlayJonIdleWithFlySwatterSound()
    {
        audioSource.PlayOneShot(JonIdleWithFlySwatterSound);
    }
    
    public void PlayJonJumpSound()
    {
        audioSource.PlayOneShot(JonJumpSound);
    }
    
    public void PlayJonJumpWithFlySwatterSound()
    {
        audioSource.PlayOneShot(JonJumpWithFlySwatterSound);
    }
    
    public void PlayJonRunSound()
    {
        audioSource.PlayOneShot(JonRunSound);
    }
    
    public void PlayJonRunWithFlySwatterSound()
    {
        audioSource.PlayOneShot(JonRunWithFlySwatterSound);
    }
    
    public void PlayJonTouchSpiderSound()
    {
        audioSource.PlayOneShot(JonTouchSpiderSound);
    }
    
    public void PlaySpiderClimbSound()
    {
        audioSource.PlayOneShot(SpiderClimbSound);
    }
    
    public void PlaySpiderRunSound()
    {
        audioSource.PlayOneShot(SpiderRunSound);
    }
}

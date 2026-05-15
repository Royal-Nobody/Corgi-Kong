using System;
using UnityEngine;

public class FlySwatter : MonoBehaviour
{
    public SoundEffects sounds;

    void Start()
    {
        sounds = FindAnyObjectByType<SoundEffects>();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spider"))
        {
            sounds.PlaySpiderClimbSound();
            Destroy(other.gameObject);
        }
    }
}

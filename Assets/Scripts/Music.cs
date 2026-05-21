using System;
using System.Collections;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip gameMusic;
    public AudioClip menuMusic;

    public AudioSource currentSource;
    public AudioSource incomingSource;

    private float fadeDurationInSeconds = 1f;
    private float maximumVolume = 0.4f;

    private void Awake()
    {
        currentSource.loop = true;
        incomingSource.loop = true;
    }

    public void PlayMenuMusic()
    {
        if (currentSource.clip == null)
        {
            currentSource.clip = menuMusic;
            currentSource.Play();
            return;
        }

        if (currentSource.clip == menuMusic)
            return;

        StartCoroutine(CrossFade(menuMusic));
    }

    public void PlayGameMusic()
    {
        if (currentSource.clip == null)
        {
            currentSource.clip = gameMusic;
            currentSource.Play();
            return;
        }

        if (currentSource.clip == gameMusic)
            return;

        StartCoroutine(CrossFade(gameMusic));
    }

    public IEnumerator CrossFade(AudioClip newClip)
    {
        incomingSource.clip = newClip;
        incomingSource.volume = 0f;
        incomingSource.Play();

        float elapsedTimeInSeconds = 0f;
        while (elapsedTimeInSeconds < fadeDurationInSeconds)
        {
            elapsedTimeInSeconds += Time.deltaTime;
            float percentTime = elapsedTimeInSeconds / fadeDurationInSeconds;
            
            currentSource.volume = maximumVolume * (1 - percentTime);
            incomingSource.volume = maximumVolume * percentTime;

            yield return null;
        }
        
        currentSource.Stop();
        currentSource.volume = maximumVolume;
        (currentSource, incomingSource) = (incomingSource, currentSource);
    }
}
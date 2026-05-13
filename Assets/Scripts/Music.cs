using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip ThemeMusic;
    
    public AudioSource MusicSource;
    
    private float maximumVolume = 0.4f;

    public void Awake()
    {
        MusicSource.loop =  true;
    }
    
    public void PlayThemeMusic()
    {
        if (MusicSource.clip == null)
        {
            MusicSource.clip = ThemeMusic;
            MusicSource.Play();
            return;
        }
    }
}

using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public float soundEffectVolume;
    
    public AudioSource jonRunSource;
    public AudioSource jonClimbSource;
    public AudioSource soundSource;
    
    [Header("Sounds")]
    public AudioClip jonRun;
    public AudioClip jonClimb;
    public AudioClip jonJump;
    public AudioClip jonRun_FlySwatter;
    public AudioClip jonClimb_FlySwatter;
    public AudioClip jonJump_FlySwatter;
    public AudioClip jonIdle_FlySwatter;
    public AudioClip jonDie;
    public AudioClip spiderClimb;
    public AudioClip spiderRun;

    public enum JonSoundType
    {
        Run,
        Climb,
        Jump,
        Die,
        Idle
    }

    public void PlaySpiderRunSound()
    {
        soundSource.PlayOneShot(spiderRun);
    }
    
    public void PlaySpiderClimbSound()
    {
        soundSource.PlayOneShot(spiderClimb);
    }
    
    public void PlayJonSound(JonSoundType soundType, bool hasFlySwatter)
    {
        soundSource.volume = soundEffectVolume;
        
        switch (soundType)
        {
            case JonSoundType.Run:
                jonRunSource.volume = soundEffectVolume;
                break;
            case JonSoundType.Climb:
                jonClimbSource.volume = soundEffectVolume;
                break;
            case JonSoundType.Jump:
                if (hasFlySwatter)
                {
                    soundSource.PlayOneShot(jonJump_FlySwatter);
                }
                else
                {
                    soundSource.PlayOneShot(jonJump);
                }
                break;
            case JonSoundType.Die:
                soundSource.PlayOneShot(jonDie);
                break;
            case JonSoundType.Idle:
                soundSource.PlayOneShot(jonIdle_FlySwatter);
                break;
        }
    }

    public void StopRunningSound()
    {
        jonRunSource.volume = 0;
    }

    public void StopClimbingSound()
    {
        jonClimbSource.volume = 0;
    }
}

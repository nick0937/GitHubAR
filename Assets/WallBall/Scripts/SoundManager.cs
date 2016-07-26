using UnityEngine;
using System.Collections;
public enum namea { Clip,name };
[System.Serializable]
public class AudioList
{
    public AudioClip Clip;
    [Range(0, 1)]
    public float Volume;
    public namea a;
}

public class SoundManager : ManagerBase
{
    
    // to add a new sound effecr,
    // just add a new AudioClip variable here
    [Header("AudioSource")]
    public AudioSource effectSource;
    public AudioSource playerAudioSource;
    public AudioSource musicSource;
    public AudioSource tileSource;
    [Header("AudioClip")]
    public AudioList[] List;

    // thsi is the music played when the script awakes
    public void Start()
    {
        PlayMenuMusic();
    }

    // this method may be called from the outside
    // to start the menu music
    public void PlayMenuMusic()
    {
        playSound(musicSource, "MenuMusic", true);
    }

    // this method may be called from the outside
    // to start the game music
    public void PlayMusicGame()
    {
        playSound(musicSource, "GameMusic", true);
    }


    // this method may be called from the outside
    // to start the game over music
    public void PlayGameOverMusic()
    {
        playSound(musicSource, "GameOverMusic", false);
    }
    // this method may be called from the outside
    // to play the ball falling sound once
    public void playFallingSound()
    {
        playSound(playerAudioSource, "Die", false);
    }

    // this method may be called from the outside
    // to play the shatter sound once
    public void playShatterSound()
    {
        playSound(tileSource, "TileOver", false);
    }

    // this method may be called from the outside
    // to play the gem collect sound once
    public void playGemSound()
    {
        playSound(effectSource, "Collect", false);
    }

    // this is the master method which plays the selected sound effect
    // via the corresponding AudioSource
    public bool playSound(AudioSource audioSource, string name, bool isLooping)
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not installed");
            return false;
        }
        else
        {
            if(List.Length == 0)
            {
                Debug.LogError("AudioClip is not installed");
                return false;
            }
            for (int i = 0; i < List.Length; i++)
            {
                if(List[i].Clip == null)
                {
                    Debug.LogError("AudioClip is not installed");
                    return false;
                }
                if (name == List[i].Clip.name)
                {
                    if (!isLooping)
                        audioSource.PlayOneShot(List[i].Clip, List[i].Volume);
                    else
                        audioSource.clip = List[i].Clip;
                        audioSource.volume = List[i].Volume;
                        audioSource.loop = true;
                        audioSource.Play();
                    break;
                }
            }       
            return true;
        }
        // play the effect once

    }
}

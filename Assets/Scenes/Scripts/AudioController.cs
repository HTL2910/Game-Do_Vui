using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public static AudioController Ins;
    [Range(0,1)]
    public float musicVolume;
    [Range(0,1)]
    public float soundVolume;
    
    public AudioSource musicAus;
    public AudioSource soundAus;
    public AudioClip[] backgroundMusics;
    public AudioClip rightSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    private void Awake()
    {
        MakeSingleton();
    }
    void Start()
    {
        PlayBackGroundMusic();
        
    }
    void Update()
    {
        if(musicAus && soundAus)
        {
            musicAus.volume = musicVolume;
            soundAus.volume = soundVolume;
        }
    }
    public void PlayBackGroundMusic()
    {
        if(musicAus && backgroundMusics!=null && backgroundMusics.Length>0)
        {
            int randIdx=Random.Range(0,backgroundMusics.Length);
            if(backgroundMusics[randIdx])
            {
                musicAus.clip=backgroundMusics[randIdx];
                musicAus.Play();
                musicAus.volume=musicVolume;
            }
        }
       
    }
    public void PLaySound(AudioClip sound)
    {   
        if(soundAus && sound)
        {
           soundAus.volume=soundVolume;
           soundAus.PlayOneShot(sound);
        }
    }
    public void StopMusic()
    {
        if(musicAus)
        {
            musicAus.Stop();
        }
    }
    public void PlayRightSound()
    {
        PLaySound(rightSound);
    }
    public void PlayLoseSound()
    {
        PLaySound(loseSound);
    }
    public void PlayWinSound()
    {
        PLaySound(winSound);
    }
    private void MakeSingleton()
    {
        if(Ins==null)
        {
            Ins=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private Sound[] musicSounds, sfxSounds;
    [SerializeField] private AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound temp = Array.Find(musicSounds, x => x.soundName == name);
        musicSource.clip = temp.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound temp = Array.Find(sfxSounds, x => x.soundName == name);
        sfxSource.PlayOneShot(temp.clip);
    }
}
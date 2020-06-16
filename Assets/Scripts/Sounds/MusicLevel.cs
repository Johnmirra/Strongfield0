using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel : MonoBehaviour
{
    AudioSource source;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioClip music5;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        DataBaseMusic data = DataWork.LoadMusic();
        source.volume = data.musicVolume;
        GameEngine.Engine.soundEffectVolume = data.effectsVolume;

        if (GameObject.Find("MusicBox") != null)
            Destroy(GameObject.Find("MusicBox"));
    }

    void PlayNew()
    {
        switch(Random.Range(1,6))
        {
            case 1:
                source.clip = music1;
                source.Play();
                break;
            case 2:
                source.clip = music2;
                source.Play();
                break;
            case 3:
                source.clip = music3;
                source.Play();
                break;
            case 4:
                source.clip = music4;
                source.Play();
                break;
            case 5:
                source.clip = music5;
                source.Play();
                break;
        }
    }
    private void Update()
    {
        if (!source.isPlaying)
            PlayNew();
    }
}

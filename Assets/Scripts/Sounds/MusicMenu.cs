using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    AudioSource _source;

    [Header("Main")]
    public bool main;
    public AudioClip mainMusic;


    void Awake()
    {
        _source = GetComponent<AudioSource>();
        DataBaseMusic data = DataWork.LoadMusic();
        _source.volume = data.musicVolume;
        if(main)
            DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        GameObject musicBox = GameObject.Find("MusicBox");
        if (musicBox != this.gameObject)
            Destroy(this.gameObject);
        if(main)
        {
            _source.clip = mainMusic;
            _source.loop = true;
            _source.Play();
        }
    }


}

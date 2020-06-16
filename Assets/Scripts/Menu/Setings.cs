using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider effectsSlider;
    float musicV;
    float effectsV;

    private void Awake()
    {
        DataBaseMusic data = DataWork.LoadMusic();

        musicSlider.value = data.musicVolume;
        effectsSlider.value = data.effectsVolume;
    }

    public void Push()
    {
        DataWork.SaveMusic(musicV, effectsV);
    }

    private void Update()
    {
        musicV = musicSlider.value;
        effectsV = effectsSlider.value;
        if (GameObject.Find("MusicBox") != null)
            GameObject.Find("MusicBox").GetComponent<AudioSource>().volume = musicV;
    }
}

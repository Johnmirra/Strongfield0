using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = GameEngine.Engine.soundEffectVolume;
    }
}

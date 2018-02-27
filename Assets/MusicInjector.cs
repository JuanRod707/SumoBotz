using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInjector : MonoBehaviour {

    public AudioSource music;

    // Use this for initialization
    void Start () {

        var lastMusic = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        lastMusic.Stop();

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayer : MonoBehaviour {

    private static BGMPlayer bgmplayer;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        if (bgmplayer == null)
        {
            bgmplayer = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);

            audioSource.clip = Resources.Load<AudioClip>("Audio/Main Theme");
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            DestroyObject(gameObject);
        }

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

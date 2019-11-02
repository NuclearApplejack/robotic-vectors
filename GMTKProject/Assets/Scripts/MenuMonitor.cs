using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMonitor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        GetComponent<Animator>().SetTrigger("Play");
    }

    public void Transition()
    {
        GameObject.Find("BGMPlayer").GetComponent<AudioSource>().volume = 0.04f;
        GameObject.Find("Manager").GetComponent<SceneTransitioner>().TransitionWithFade("Level1", Color.black);

    }

    public void PlaySound1()
    {
        GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Audio/blink"));
    }

    public void PlaySound2()
    {
        GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Audio/hack 2"), 0.3f);
    }
}

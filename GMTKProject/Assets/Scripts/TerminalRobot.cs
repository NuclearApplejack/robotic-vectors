using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminalRobot : GeneralRobot
{
    public string nextScene;

    new void Start()
    {
        taskList.Add(new WaitTask(9999f, gameObject));

        base.Start();

        taskBar.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        taskBarText.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public override void OnInfect()
    {
        GetComponent<Animator>().SetTrigger("Hack");
    }

    public void NextLevel()
    {
         generalManager.GetComponent<SceneTransitioner>().TransitionWithFade(nextScene, Color.black);
    }

    public void PlayAudio1()
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/hack"));
    }

    public void PlayAudio2()
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/blink"));
    }
}

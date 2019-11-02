using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRobot : GeneralRobot {

    public float rightDuration = 1f;
    public float leftDuration = 1f;

    bool facingRight = false;

    Animator animator;

    // Use this for initialization
    new void Start () {
        taskList.Add(new PatrolTask(rightDuration, false, gameObject));
        taskList.Add(new WaitTask(1f, gameObject));
        taskList.Add(new PatrolTask(leftDuration, true, gameObject));
        taskList.Add(new WaitTask(1f, gameObject));

        base.Start();

        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	new void Update () {
        if (!isDead)
        {
            base.Update();

            if (currentTask is PatrolTask)
            {
                animator.SetBool("IsMoving", true);
                if (((PatrolTask)currentTask).right)
                {
                    facingRight = true;
                }
                else
                {
                    facingRight = false;
                }
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                animator.SetBool("IsMoving", false);
                audioSource.Stop();
            }

            animator.SetBool("Infected", infected);
            transform.localScale = new Vector3(facingRight ? 1 : -1, transform.localScale.y, 1);
            taskBar.transform.localScale = new Vector3(facingRight ? 1 : -1, transform.localScale.y, 1);
        }

    }


}

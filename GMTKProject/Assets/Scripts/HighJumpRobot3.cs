﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpRobot3 : GeneralRobot
{

    public float rightDuration = 1f;
    public float leftDuration = 1f;

    bool facingRight = false;

    Animator animator;



    // Use this for initialization
    new void Start()
    {
        taskList.Add(new JumpTask(1.55f, true, gameObject, 1700f * transform.localScale.y));
        taskList.Add(new JumpTask(1.55f, false, gameObject, 1700f * transform.localScale.y));



        base.Start();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
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
            else if (currentTask is JumpTask)
            {
                animator.SetBool("IsMoving", true);
                if (((JumpTask)currentTask).right)
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    new void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
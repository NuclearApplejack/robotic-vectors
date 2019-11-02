using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRobot : GeneralRobot
{

    public float rightDuration = 1f;
    public float leftDuration = 1f;

    Animator animator;



    // Use this for initialization
    new void Start()
    {
        taskList.Add(new WaitTask(1f, gameObject));

        base.Start();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    new void Update()
    {
        if (!isDead)
        {
            base.Update();

            animator.SetBool("Infected", infected);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
            taskBar.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRobot : GeneralRobot {

    Animator animator;

    new void Start()
    {
        taskList.Add(new WaitTask(9999f, gameObject));


        base.Start();
        infected = true;
        animator = GetComponent<Animator>();

        taskBar.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        taskBarText.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        animator.SetBool("Infected", infected);
    }
}

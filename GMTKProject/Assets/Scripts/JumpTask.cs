using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTask : GeneralTask
{

    public bool right = false;
    public bool jumped = false;
    public float force = 1300f;

    public JumpTask(float duration, bool right, GameObject parent, float force = 1300f)
    {
        taskName = "JUMP(" + (right ? "right" : "left") + ")";
        this.right = right;
        this.duration = duration;
        parentRobot = parent;
        this.force = force;
    }


    public override void ExecuteTask()
    {

        parentRobot.transform.Translate(new Vector3(parentRobot.GetComponent<GeneralRobot>().patrolSpeed * (right ? 1 : -1) * Time.fixedDeltaTime, 0, 0));
        if (!jumped)
        {
            
            if (parentRobot.GetComponent<GeneralRobot>().grounded)
            {
                jumped = true;
                parentRobot.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force));
            }
        }
    }

    public override void ResetTask()
    {
        jumped = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTask : GeneralTask {

    public bool right = false;

	public PatrolTask(float duration, bool right, GameObject parent)
    {
        taskName = "PATROL(" + (right ? "right" : "left") + ")";
        this.right = right;
        this.duration = duration;
        parentRobot = parent;
    }
	

    public override void ExecuteTask()
    {
        parentRobot.transform.Translate(new Vector3(parentRobot.GetComponent<GeneralRobot>().patrolSpeed * (right ? 1 : -1) * Time.fixedDeltaTime, 0, 0));
    }

    public override void ResetTask()
    {
        
    }
}

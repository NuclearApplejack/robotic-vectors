using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTask : GeneralTask
{
    public WaitTask(float duration, GameObject parent)
    {
        taskName = "WAIT()";
        this.duration = duration;
        parentRobot = parent;
    }

    public override void ExecuteTask()
    {
        
    }

    public override void ResetTask()
    {
        
    }
}

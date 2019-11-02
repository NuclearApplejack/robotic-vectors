using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneralTask {

    public float duration = 0f;
    public bool finished = false;

    public string taskName = "";

    public GameObject parentRobot;

    public abstract void ExecuteTask();

    public abstract void ResetTask();

}

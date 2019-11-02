using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTriggerCollider : MonoBehaviour
{

    TaskViewerManager tvm;
    bool isCollWithPlayer = false;

    // Use this for initialization
    void Start()
    {
        tvm = GameObject.Find("GeneralManager").GetComponent<TaskViewerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            if (collision.transform.parent.gameObject.Equals(tvm.currentlyInfectedRobot))
            {
                if (tvm.prevRobot.Equals(gameObject.transform.parent))
                {
                    if (tvm.touchingRobot == null)
                    {
                        tvm.touchingRobot = gameObject.transform.parent.gameObject;
                    }
                }
                else
                {
                    tvm.touchingRobot = gameObject.transform.parent.gameObject;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            if (collision.transform.parent.gameObject.Equals(tvm.currentlyInfectedRobot))
            {
                tvm.touchingRobot = null;
            }
        }
    }*/


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            if (collision.transform.parent.gameObject.Equals(tvm.currentlyInfectedRobot))
            {
                if (!tvm.touchingRobots.Contains(transform.parent.gameObject))
                {
                    tvm.touchingRobots.Add(transform.parent.gameObject);
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            if (collision.transform.parent.gameObject.Equals(tvm.currentlyInfectedRobot) || collision.transform.parent.gameObject.Equals(tvm.prevRobot))
            {
                if (tvm.touchingRobots.Contains(transform.parent.gameObject))
                {
                    tvm.touchingRobots.Remove(transform.parent.gameObject);
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (tvm.touchingRobots.Contains(transform.parent.gameObject))
        {
            tvm.touchingRobots.Remove(transform.parent.gameObject);
        }
    }

}
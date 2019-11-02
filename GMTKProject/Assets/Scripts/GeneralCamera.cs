using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCamera : MonoBehaviour
{

    GameObject target;
    Vector3 targetLocation;
    GameObject generalManager;

    public bool lockX = false;
    public bool lockY = false;

    public float minX = 0f;
    public float maxX = 0f;

    public float minY = 0f;
    public float maxY = 0f;

    // Use this for initialization
    void Start()
    {
        generalManager = GameObject.Find("GeneralManager");
        target = GameObject.Find("StartingPoint");
        targetLocation = target.transform.position;
        transform.position = targetLocation;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = generalManager.GetComponent<TaskViewerManager>().currentlyInfectedRobot;
        targetLocation = target.transform.position + new Vector3(0, 0.5f, 0);
        transform.position += (targetLocation - transform.position) / 10f;

        if (lockX)
        {
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
            else if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
        }

        if (lockY)
        {
            if (transform.position.y > maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            }
            else if (transform.position.y < minY)
            {
                transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            }
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -100);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskViewerManager : MonoBehaviour {

    public GameObject currentlyInfectedRobot;

    //public GameObject touchingRobot;
    public List<GameObject> touchingRobots = new List<GameObject>();

    public GameObject prevRobot = null;

    GameObject particle;
    float particleTimer = 0.1f;

    // Use this for initialization
    void Start () {
        //Cursor.visible = false;
        currentlyInfectedRobot = GameObject.Find("StartingPoint");
        particle = Resources.Load<GameObject>("Prefabs/HexParticle");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            GameObject.Find("BGMPlayer").GetComponent<AudioSource>().volume = 0.1f;
            GetComponent<SceneTransitioner>().TransitionWithFade("MainMenu", Color.black);
        }

        if (!currentlyInfectedRobot.GetComponent<GeneralRobot>().isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (touchingRobots.Count != 0)
                {
                    if (!touchingRobots[touchingRobots.Count - 1].Equals(prevRobot))
                    {
                        currentlyInfectedRobot.GetComponent<GeneralRobot>().infected = false;
                        touchingRobots[touchingRobots.Count - 1].GetComponent<GeneralRobot>().infected = true;
                        
                        prevRobot = currentlyInfectedRobot;
                        currentlyInfectedRobot = touchingRobots[touchingRobots.Count - 1];

                        touchingRobots[touchingRobots.Count - 1].GetComponent<GeneralRobot>().OnInfect();
                        touchingRobots.Remove(prevRobot);
                        touchingRobots.Remove(currentlyInfectedRobot);
                        touchingRobots.Clear();

                    }
                    else
                    {
                        currentlyInfectedRobot.GetComponent<GeneralRobot>().infected = false;
                        touchingRobots[0].GetComponent<GeneralRobot>().infected = true;

                        prevRobot = currentlyInfectedRobot;
                        currentlyInfectedRobot = touchingRobots[0];

                        touchingRobots[0].GetComponent<GeneralRobot>().OnInfect();
                        touchingRobots.Remove(prevRobot);
                        touchingRobots.Remove(currentlyInfectedRobot);
                        touchingRobots.Clear();

                    }
                }
            }

            if (particleTimer <= 0f)
            {
                particleTimer = 0.1f;
                GameObject newParticle = Instantiate(particle);
                newParticle.transform.position = currentlyInfectedRobot.transform.position + new Vector3(0, 0, 2);
                if (currentlyInfectedRobot.transform.localScale.y < 0f)
                {
                    newParticle.GetComponent<HexParticle>().verticalDirection = -1;
                }
            }
            else
            {
                particleTimer -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<SceneTransitioner>().TransitionWithFade(SceneManager.GetActiveScene().name, Color.black);
        }
    }
}

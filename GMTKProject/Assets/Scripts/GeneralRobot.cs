using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralRobot : MonoBehaviour {

    public List<GeneralTask> taskList = new List<GeneralTask>();

    public GeneralTask currentTask;
    public int currentTaskNum = 0;

    public float currentTaskTimer = 0f;

    public float patrolSpeed = 1f;

    public GameObject taskBar;
    public TextMesh taskBarText;
    public new GameObject camera;
    public GameObject triggerObj;
    public GameObject generalManager;

    public AudioSource audioSource;
    public AudioClip wheels;

    public bool infected = false;

    public bool grounded = false;

    public int startingTask = 0;

    public bool isDead = false;

    // Use this for initialization
    public void Start () {
        currentTask = taskList[startingTask];
        currentTaskNum = startingTask;

        taskBar = Instantiate(Resources.Load<GameObject>("Prefabs/RobotTaskBar"));
        taskBar.transform.parent = gameObject.transform;
        taskBar.transform.localPosition = new Vector3(0f, 2f, -10f);
        taskBarText = taskBar.transform.Find("TaskText").GetComponent<TextMesh>();
        triggerObj = transform.Find("Trigger").gameObject;
        generalManager = GameObject.Find("GeneralManager");

        UpdateCurrentTask();

        camera = GameObject.Find("Main Camera");
        audioSource = Instantiate(Resources.Load<GameObject>("Prefabs/AudioHolder")).GetComponent<AudioSource>();
        audioSource.transform.parent = transform;
        audioSource.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -100);
        audioSource.loop = true;
        wheels = Resources.Load<AudioClip>("Audio/wheels");
        audioSource.clip = wheels;
        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.maxDistance = 40f;
        audioSource.volume = 0.3f;

    }

    // Update is called once per frame
    public void Update()
    {
        

        if (infected)
        {
            taskBarText.color = new Color(234f / 255f, 114f / 255f, 196f / 255f, taskBarText.color.a);
        }
        else
        {
            taskBarText.color = new Color(1, 1, 1, taskBarText.color.a);
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            currentTaskTimer -= Time.fixedDeltaTime;

            if (currentTaskTimer <= 0f)
            {
                if (!infected)
                {
                    currentTaskNum = (currentTaskNum + 1) % taskList.Count;
                }
                UpdateCurrentTask();


            }
        }

        if (!isDead)
        {
            currentTask.ExecuteTask();
        }
    }

    public void UpdateCurrentTask()
    {
        currentTask.ResetTask();
        currentTask = taskList[currentTaskNum];
        currentTaskTimer = currentTask.duration;
        taskBarText.text = currentTask.taskName;
    }

    public virtual void OnInfect()
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/hack 2"), 0.6f);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            GetComponent<Animator>().SetTrigger("Die");
            isDead = true;
            Destroy(taskBar);
            Destroy(taskBarText.gameObject);
            Destroy(triggerObj);
            audioSource.Stop();
            audioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/shock"), 0.7f);
            if (generalManager.GetComponent<TaskViewerManager>().touchingRobots.Contains(gameObject))
            {
                generalManager.GetComponent<TaskViewerManager>().touchingRobots.Remove(gameObject);
            }
        }
    }
}

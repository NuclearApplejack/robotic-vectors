using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexParticle : MonoBehaviour
{

    public int verticalDirection = 1;
    int currAngle = 0;
    float speed = 25f;
    float timer = 0f;

    Vector3 prevPos;
    GameObject particleBlur;

    // Use this for initialization
    void Start()
    {
        
        currAngle = Random.Range(0, 3);
        prevPos = transform.position;
        particleBlur = Resources.Load<GameObject>("Prefabs/HexParticleBlur");
    }

    // Update is called once per frame
    void Update()
    {
        if (speed <= 0f)
        {
            Destroy(gameObject);
            return;
        }
        transform.position += Quaternion.Euler(0, 0, 45 + (45 * currAngle)) * new Vector3(speed * Time.deltaTime * verticalDirection, 0, 0);
        timer += Time.deltaTime;
        if (timer >= 0.1f)
        {
            timer = 0f;
            if (Random.Range(0, 2) == 0)
            {
                if (currAngle == 1)
                {
                    currAngle = Random.Range(0, 2) * 2;
                }
                else
                {
                    currAngle = 1;
                }
            }
        }

        speed -= Time.deltaTime * 25f * Random.Range(1, 4);

        if ((prevPos - transform.position).magnitude > 0.25f)
        {
            Instantiate(particleBlur).transform.position = transform.position;
            prevPos = transform.position;
        }
    }
}

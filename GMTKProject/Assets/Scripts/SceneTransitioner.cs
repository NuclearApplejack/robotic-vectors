using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitioner : MonoBehaviour
{

   GameObject loadingUI;
    float preSceneTimer = 0f;
    string sceneName = "";
    Color color = Color.black;
    Color currColor = new Color(1, 1, 1, 0);
    public bool transitioning = false;

    float initialTimer = 1f;



    void Start()
    {

        loadingUI = GameObject.Find("LoadingUI");



    }

    void Update()
    {

        if (initialTimer > 0f)
        {
            initialTimer -= Time.deltaTime;
            currColor = new Color(color.r, color.g, color.b, Mathf.Min(initialTimer, 0.5f) / 0.5f);
            loadingUI.GetComponent<CanvasGroup>().alpha = currColor.a;
        }
        else
        {
        }

        if (transitioning)
        {
            preSceneTimer += Time.deltaTime;

            currColor = new Color(color.r, color.g, color.b, preSceneTimer / 0.5f);

            loadingUI.GetComponent<CanvasGroup>().alpha = currColor.a;

            if (preSceneTimer >= 0.5f)
            {
                StartCoroutine(LoadScene());
            }
        }
    }

    IEnumerator LoadScene()
    {

        yield return new WaitForSeconds(0.1f);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;
        }

    }

    public void TransitionWithFade(string sceneName, Color color)
    {
        if (!transitioning)
        {
            this.sceneName = sceneName;
            this.color = color;
            transitioning = true;
        }
    }


}

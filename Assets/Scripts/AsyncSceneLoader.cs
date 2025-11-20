using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneLoader : MonoBehaviour
{
    public Progressbar progressbar;
    public string scenename;
    public float fakeDuration;

    private AsyncOperation loaddingOperation;
    private float Starttime;

    public void StarLoadScene()
    {
        gameObject.SetActive(true);
        DontDestroyOnLoad(this);
        Starttime = Time.unscaledDeltaTime;
        loaddingOperation = SceneManager.LoadSceneAsync(scenename);
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (loaddingOperation == null) return;
        float fakeProgress = (Time.unscaledDeltaTime - Starttime) / fakeDuration;
        float finalProgress = Mathf.Min(fakeProgress, loaddingOperation.progress);
        progressbar.SetProgressValue(finalProgress);
        if(loaddingOperation.isDone && finalProgress >= 1)
        {
            FinishLoading();
        }
    }

    private void FinishLoading()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}

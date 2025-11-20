using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    public float visibleDuration;
    public float fadeDuration;
    public CanvasGroup group;    
    private float StartTime;

    public void Show()
    {
        StartTime = Time.time;
        group.alpha = 1f;
        gameObject.SetActive(true);
    }
    public void Update()
    {
        float elapsedTime = Time.time - StartTime;
        if (elapsedTime < visibleDuration) return;

        elapsedTime -= visibleDuration;
        if(elapsedTime < fadeDuration)
        {
            group.alpha = 1f - elapsedTime/fadeDuration;
        }
        else
        {
            Hide();
        }
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

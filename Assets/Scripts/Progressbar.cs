using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform Mask;
    public RectTransform ImageProgress;

    private float maxWidth;
    private float maxHeight;

    private void Awake()
    {
        maxHeight = Mask.rect.height;
        maxWidth = Mask.rect.width;
    }
     public void SetProgressValue(float progress)
    {
        float currentWidth = Mathf.Clamp01(progress)*maxWidth;
        Mask.sizeDelta = new Vector2 (currentWidth, maxHeight);
    }
}

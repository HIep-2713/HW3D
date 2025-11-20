using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public AutoFade leftScatch;
    public AutoFade rightScatch;
    public void ShowleftScatch()
    {
        leftScatch.Show();
    }
    public void ShowrightScatch()
    {
        rightScatch.Show();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissonManager : MonoBehaviour
{
    public GameFlow gameflow;
    public int repuiredKill;
    public Text missionText;

    private int currentKill;
    private void Start()
    {
        StartCoroutine(VeryfiMissions());
    }
    private IEnumerator VeryfiMissions()
    {
        yield return VeryfiZombieKill();
        gameflow.OnMissonCompled();
    }
    private IEnumerator VeryfiZombieKill()
    {
        currentKill = 0;
        missionText.text = $"Kill {repuiredKill} zombies ";
        yield return new WaitUntil(() => currentKill >= repuiredKill);
     }

    public void OnZombieKilled(GameObject zombie)
    {
        currentKill++;
    }

}

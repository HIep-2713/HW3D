using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissonManager : MonoBehaviour
{
    public GameFlow gameflow;
    public int repuiredKill;
    public Text missionText;
    private bool isPlayerExit;
    private int currentKill;
    public Gate gate;
    private void Start()
    {
        StartCoroutine(VeryfiMissions());
    }
    private IEnumerator VeryfiMissions()
    {
        yield return VeryfiZombieKill();
        yield return VeryfiPlayerExit();
        gameflow.OnMissonCompled();
    }
    private IEnumerator VeryfiZombieKill()
    {
        currentKill = 0;
        missionText.text = $"Kill {repuiredKill} zombies ";
        yield return new WaitUntil(() => currentKill >= repuiredKill);
     }
    private IEnumerator VeryfiPlayerExit()
    {
        missionText.text = $"Find Exit Door";
        gate.onPlayerEnter.AddListener(OnPlayerExit);
         yield return new WaitUntil(()=>isPlayerExit);
        gate.onPlayerEnter.RemoveListener(OnPlayerExit);
    }
    private void OnPlayerExit()
    {
        isPlayerExit = true;
    }
    public void OnZombieKilled(GameObject zombie)
    {
        currentKill++;
    }
   
}

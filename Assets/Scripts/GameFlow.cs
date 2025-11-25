using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject GameWin;
    public void OnPlayerDie()
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
        print("PlayerDie");
    }
    public void OnMissonCompled()
    {
        StopGame();
        GameWin.SetActive(true);
    }
    private void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

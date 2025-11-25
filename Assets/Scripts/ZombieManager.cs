using UnityEngine;
using System.Collections.Generic; // N?u b?n mu?n dùng List ?? l?u tr? zombie

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance { get; private set; }
    private int zombiesKilled = 0;
    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;           
        }
    }
    public void NotifyZombieKilled(GameObject killedZombie)
    {
        zombiesKilled++;
        Debug.Log("Zombie b? tiêu di?t! T?ng s? ?ã gi?t: " + zombiesKilled);
    }
    public int GetZombiesKilledCount()
    {
        return zombiesKilled;
    }
}
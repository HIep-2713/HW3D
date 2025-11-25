using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class ZombieSpawn : MonoBehaviour
{
    public GameObject zombiePrefad;
    public float spawnInterval;
    public int spawnQuality;
    public float radius;
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);

    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = new Color(1, 0, 0, 0.1f);
        Handles.DrawSolidDisc(transform.position, Vector3.up, radius);
    }
#endif
    private void Start()
    {
        StartCoroutine(SpawnZombieByTime());
    }
    private IEnumerator SpawnZombieByTime()
    {
        while(spawnQuality>0)
        {
            SpawnZombie();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private void SpawnZombie()
    {
        Instantiate(zombiePrefad, transform.position, transform.rotation);
        spawnQuality--;
    }
}

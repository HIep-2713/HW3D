using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class AutoMaticShooting : Shooting
{
    public Animator ani;
    public int rpm;
    
    public AudioSource FireSound;
   private float interval;
    private float lastshoot;
    public UnityEvent onShoot;
    public RunRayCaster rayCaster;
    private bool isShooting;
    void Start()
    {
        interval = 60 / rpm;
    }

    public void StarShooting()
    {
        isShooting = true;
    }
    public void StopShooting()
    {
        isShooting=false;
    }
    void Update()
    {
        Updatefiring();
    }
    void Updatefiring()
    {
        if (!isShooting) return;
        if (Time.time - lastshoot >= interval)
        {
            Shoot();
            lastshoot = Time.time;
        }
    }
    void Shoot()
    {
        ani.Play("Shoot", layer: -1, normalizedTime: 0);

        if (FireSound != null)
            FireSound.Play();
        if (rayCaster != null)
            rayCaster.PerformRaycastting();

        onShoot.Invoke();
    }

}

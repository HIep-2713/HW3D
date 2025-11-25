using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator ani;
    public int damage;
    public Health Playerhealth;

    public void StartAttack()
    {
        ani.SetBool("IsAttacking", true);
    }
    public void StopAttack()
    {
        ani.SetBool("IsAttacking", false);
    }
    private void Start()
    {
        Playerhealth = Player.Instance.health;
    }
    public void OnAttack(int index)
    {
        Playerhealth.TakeDamage(damage);
        if(index == 1)
        {
            Player.Instance.playerUi.ShowleftScatch();
        }
        else
        {
            Player.Instance.playerUi.ShowrightScatch();
        }
    }
}

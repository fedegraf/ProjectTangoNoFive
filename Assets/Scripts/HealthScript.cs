using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour, IInteractive
{
    public VoidDelegate DeathEvent;
    public VoidDelegatewithFloat LifeChange;
    [SerializeField] private GameObject Fx;
    [SerializeField] private float health = 100;
    
    public float Health { get => health; set => health = value; }

    public void GetDamage(float damage)
    {
        health -= damage;
        LifeChange?.Invoke(health);
        Instantiate(Fx);
        Debug.Log(health);
        if (health <= 0)
        {
            DeathEvent?.Invoke();
        }
    }

    public void GetHitByBullets()
    {
        GetDamage(ScriptableObjects.BulletDamage);
    }
}

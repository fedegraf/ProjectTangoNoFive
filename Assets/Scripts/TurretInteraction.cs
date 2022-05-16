using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretInteraction : MonoBehaviour, IInteractive
{
    [SerializeField] public string ColorTag;
    public void GetHitByBullets()
    {
        TurretHitCommand MyCommand = new TurretHitCommand();
        MyCommand.Execute(gameObject);
    }
}

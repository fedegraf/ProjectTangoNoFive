using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHitCommand : MonoBehaviour, ICommand
{
    private string ColorTag;
    public void Execute(GameObject Commander)
    {
        Commander.GetComponent<TurretStateScript>().Deactivate();
        ColorTag = Commander.GetComponent<TurretInteraction>().ColorTag;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platforms)
        {
            if (platform.GetComponent<MovePlatformTurretScript>().ColorGroup == ColorTag)
            {
                platform.GetComponent<MovePlatformTurretScript>().Move = true;
            }
        }
    }



}

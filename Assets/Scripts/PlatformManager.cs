using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private GameObject[] platforms;

    private void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("Platform");
    }

    public void MovePlatforms(string ColorTag)
    {
        foreach (GameObject platform in platforms)
        {
            if (platform.GetComponent<MoveInteractiveScript>()?.ColorGroup == ColorTag)
            {
                platform.GetComponent<MoveInteractiveScript>().Move = true;
            }
        }
    }
}

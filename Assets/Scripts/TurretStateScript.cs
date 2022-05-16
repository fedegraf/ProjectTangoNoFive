using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStateScript : MonoBehaviour
{
    private bool isActive = true;
    private bool haveToCountdown = false;
    public bool IsActive { get => isActive; }
    private float CurrentTime = 0f;
    private float TimeToReactivate = 5f;

    // Update is called once per frame
    void Update()
    {
        if (haveToCountdown)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= TimeToReactivate)
            {
                isActive = true;
                haveToCountdown = false;
                CurrentTime = 0;
                string ColorTag = GetComponent<TurretInteraction>().ColorTag;
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
    }

    public void Deactivate()
    {
        isActive = false;
        haveToCountdown = true;
    }
}

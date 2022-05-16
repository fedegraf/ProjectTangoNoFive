using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBox : MonoBehaviour, IInteractive
{
    public float TimerCountdown = 7.5f;
    public float CurrentTime = 0f;

    public bool HaveToCountDown = false;

    // Update is called once per frame
    void Update()
    {
        if (HaveToCountDown)
        {
            CurrentTime += Time.deltaTime;
            if (TimerCountdown <= CurrentTime)
            {
                HaveToCountDown = false;
                this.transform.parent.gameObject.SetActive(true);
                CurrentTime = 0f;
            }
        }
    }

    public void GetHitByBullets()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}

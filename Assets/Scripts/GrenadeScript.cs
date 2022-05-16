using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    private float CurrentDelay = 0;

    private void Update()
    {
        CurrentDelay += Time.deltaTime;
        if (CurrentDelay >= ScriptableObjects.GrenadeDelay)
        {
            gameObject.GetComponent<Explode>().Excecute();
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.ChangeRespawnPoint(this.transform);
        }
    }
}

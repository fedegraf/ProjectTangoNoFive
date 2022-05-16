using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<HealthScript>().GetDamage(ScriptableObjects.LaserDamage);
        }
    }
}

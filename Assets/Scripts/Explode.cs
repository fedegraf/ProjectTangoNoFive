using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{ 
    [SerializeField] private float BlastRadius = 10f;
    [SerializeField] private GameObject BlasFx;
    public void Excecute()
    {
        Instantiate(BlasFx, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, BlastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.gameObject.tag == "Player")
            {
                nearbyObject.GetComponent<HealthScript>().GetDamage(ScriptableObjects.BlastDamage);
                nearbyObject.GetComponent<Rigidbody>().AddExplosionForce(ScriptableObjects.BlastDamage,
                    transform.position, BlastRadius, 0.0f, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }
}

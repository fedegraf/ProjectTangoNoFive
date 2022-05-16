using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTorretScript : MonoBehaviour
{
    [SerializeField] private GameObject Head;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Barrell;
    [SerializeField] public float ShootingCooldown = 1.75f;
    public float CurrentCooldown = 0f;
    [SerializeField] public float Shootforce = 400f;
    
    void Update()
    {
        CurrentCooldown += Time.deltaTime;
        
            if (CurrentCooldown >= ShootingCooldown)
            {
                Vector3 shootpoint = new Vector3(Random.Range(-90,120), Random.Range(-45,45));
                Head.transform.LookAt(shootpoint);
                Shoot();
                CurrentCooldown = 0;
            }   
        
    }

    void Shoot()
    {
        GameObject clone = Instantiate(Bullet, Barrell.transform.position, Head.transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(transform.forward * Shootforce, ForceMode.Impulse);
    }
}

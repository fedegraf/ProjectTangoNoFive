using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private bool isActive = true;

    private bool goingFoward = true;
    [SerializeField] private float Lenght;

    private float amountMoved;
    // Start is called before the first frame update
    void Start()
    { 
        amountMoved = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (amountMoved < Lenght)
            {
                if (goingFoward)
                {
                    transform.position += transform.forward * ScriptableObjects.LaserSpeed * Time.deltaTime;
                }           
                else
                {
                    transform.position -= transform.forward * ScriptableObjects.LaserSpeed * Time.deltaTime;
                }
                amountMoved += transform.forward.z * ScriptableObjects.LaserSpeed * Time.deltaTime;
            }
            else
            {
                goingFoward = !goingFoward;
                amountMoved = 0;
            }
        }
    }
}

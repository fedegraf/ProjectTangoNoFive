using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInteractiveScript : MonoBehaviour
{
    private bool move = false;
    [SerializeField] private float Lenght;
    private Vector3 OriginalPos;
    private float amountMoved;
    [SerializeField] private int TypeOfMove;
    // 1: forward || 2: backwards || 3: right || 4: left || 5: up || 6: down 
    [SerializeField] public string ColorGroup;
    Vector3 Direction;
    private int SecondMove;
    private Rigidbody rb;
    public bool Move { get => move; set => move = value; }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        OriginalPos = transform.position;
    }

    public virtual void Update()
    {
        if (move)
        {
            switch (TypeOfMove)
            {
                case 1:
                    Direction = transform.forward * ScriptableObjects.PlatformForce;
                    SecondMove = 2;
                    break;
                case 2:
                    Direction = -transform.forward * ScriptableObjects.PlatformForce;
                    SecondMove = 1;
                    break;
                case 3:
                    Direction = transform.right * ScriptableObjects.PlatformForce;
                    SecondMove = 4;
                    break;
                case 4:
                    Direction = -transform.right * ScriptableObjects.PlatformForce;
                    SecondMove = 3;
                    break;
                case 5:
                    Direction = transform.up * ScriptableObjects.PlatformForce;
                    SecondMove = 6;
                    break;
                case 6:
                    Direction = -transform.up * ScriptableObjects.PlatformForce;
                    SecondMove = 5;
                    break;
            }
            rb.AddForce(Direction, ForceMode.Impulse);
            CheckReach();
        }
        else
        {
            rb.velocity = new Vector3(0,0,0);
        }

    }

    void CheckReach()
    {
        if (Vector3.Distance(OriginalPos, transform.position) > Lenght)
        {
         ChangeStats();   
        }
    }

    void ChangeStats()
    {
        move = false;
        TypeOfMove = SecondMove;
        OriginalPos = transform.position;


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformTurretScript : MonoBehaviour
{
private bool move = false;
    [SerializeField] private float Lenght;
    private float amountMoved;
    [SerializeField] private int TypeOfMove;
    // 1: forward || 2: backwards || 3: right || 4: left || 5: up || 6: down 
    [SerializeField] public string ColorGroup;
    Vector3 Direction;
    private int SecondMove;
    public bool Move { get => move; set => move = value; }

    void Update()
    {
        if (move)
        {
            switch (TypeOfMove)
            {
                case 1:
                    Direction = transform.forward * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    amountMoved += transform.forward.z * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    SecondMove = 2;
                    break;
                case 2:
                    Direction = -transform.forward * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    amountMoved += transform.forward.z * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    SecondMove = 1;
                    break;
                case 3:
                    Direction = transform.right * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    amountMoved += transform.right.x * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    SecondMove = 4;
                    break;
                case 4:
                    Direction = -transform.right * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    amountMoved += transform.right.x * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    SecondMove = 3;
                    break;
                case 5:
                    Direction = transform.up * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    amountMoved += transform.up.y * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    SecondMove = 6;
                    break;
                case 6:
                    Direction = -transform.up * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    amountMoved += transform.up.y * ScriptableObjects.LaserSpeed * Time.deltaTime;
                    SecondMove = 5;
                    break;
            }

            transform.position += Direction;
            CheckReach();
        }

    }

    void CheckReach()
    {
        if (amountMoved >= Lenght)
        {
         ChangeStats();   
        }
    }

    void ChangeStats()
    {
        move = false;
        TypeOfMove = SecondMove;
        amountMoved = 0;

    }
}

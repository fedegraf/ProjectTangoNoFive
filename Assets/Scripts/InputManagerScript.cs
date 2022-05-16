using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public float MouseSensitivity = 50;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private float gravity = 9.8f;
    private Camera cam;
    private const string xAxis = "Mouse X";
    private const string yAxis = "Mouse Y";
    [SerializeField] private GameObject AimObject;
    

    private void Start()
    {
        cam = Camera.main;
        AimObject.transform.LookAt(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsPlaying)
        {
            float MouseX = Input.GetAxis(xAxis) * MouseSensitivity + Time.deltaTime;
            float MouseY = Input.GetAxis(yAxis) * MouseSensitivity + Time.deltaTime;

            xRotation -= MouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
        

            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.transform.Rotate(Vector3.up * MouseX);
            AimObject.transform.localRotation = Quaternion.Euler(xRotation, Vector3.up.y * MouseX, 0f);

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                player.GetComponent<PlayerMovementScript>().MoveForward();
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
            {
                player.GetComponent<PlayerMovementScript>().MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                player.GetComponent<PlayerMovementScript>().MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                player.GetComponent<PlayerMovementScript>().MoveBack();
            }

            if (Input.GetMouseButtonDown(0))
            {
                player.GetComponent<PlayerMovementScript>().Shoot();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<PlayerMovementScript>().Jump();
            }
        } 
    }
}

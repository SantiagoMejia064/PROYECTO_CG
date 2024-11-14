using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camaras : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public int numeroCam;
    
    void Awake()
    {
        numeroCam = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            cam.Priority = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            cam.Priority = 0;
        }
    }
}


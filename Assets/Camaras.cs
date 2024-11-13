using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camaras : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public int numeroCam;
    // Start is called before the first frame update
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    public static CheckManager Instance; 
    private Vector3 lastCheckpointPosition; 
    private bool checkpointActivado = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
        checkpointActivado = true; //Checkpoint activado colega
        Debug.Log("Checkpoint activado en: " + position);
    }

    public Vector3 GetLastCheckpoint()
    {
        return lastCheckpointPosition; // Devuelve la posición del último checkpoint
    }

    public bool HayCheckpointActivado()
    {
        return checkpointActivado; // Devuelve si hay un checkpoint activado
    }
}

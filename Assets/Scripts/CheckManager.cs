using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    public static CheckManager Instance; // Singleton para acceso global

    private Vector3 lastCheckpointPosition; // Última posición del checkpoint activado

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
        lastCheckpointPosition = position; // Actualiza la posición del último checkpoint
    }

    public Vector3 GetLastCheckpoint()
    {
        return lastCheckpointPosition; // Devuelve la posición del último checkpoint
    }
}

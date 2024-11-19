using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);

    void Update()
    {
        // Aplica la rotación continua
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            CheckManager.Instance.SetCheckpoint(transform.position);
            Debug.Log("Checkpoint activado en: " + transform.position);
            Destroy(gameObject);
        }
    }
}

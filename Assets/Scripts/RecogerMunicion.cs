using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecogerMunicion : MonoBehaviour
{
    public int ammoAmount = 40; 
    public float floatAmplitude = 0.1f; 
    public float floatSpeed = 100f; 

    private Vector3 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Movimiento
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            // Busca el script de disparo en el jugador
            DisparoPrefab disparoPrefab = other.GetComponent<DisparoPrefab>();
            if (disparoPrefab != null)
            {
                // Aumenta las balas mias
                disparoPrefab.balasRestantes += ammoAmount;

                // limite de balas
                if (disparoPrefab.balasRestantes > disparoPrefab.maxBalas)
                {
                    disparoPrefab.balasRestantes = disparoPrefab.maxBalas;
                }
                
                Debug.Log($"Munición recogida: +{ammoAmount}. Balas actuales: {disparoPrefab.balasRestantes}");
            }

            Destroy(gameObject);
        }
    }
}

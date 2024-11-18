using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerMunicion : MonoBehaviour
{
    public int ammoAmount = 40; 
    public float floatAmplitude = 0.1f; // Amplitud del movimiento vertical
    public float floatSpeed = 100f; // Velocidad del movimiento

    private Vector3 startPosition;
    
    void Start()
    {
        // Guarda la posición inicial del objeto
        startPosition = transform.position;
    }

    void Update()
    {
        // Movimiento vertical senoidal
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Busca el script de disparo en el jugador
            DisparoPrefab disparoPrefab = other.GetComponent<DisparoPrefab>();
            if (disparoPrefab != null)
            {
                // Aumenta las balas del jugador
                disparoPrefab.balasRestantes += ammoAmount;

                // Si supera el máximo permitido, ajusta al máximo
                if (disparoPrefab.balasRestantes > disparoPrefab.maxBalas)
                {
                    disparoPrefab.balasRestantes = disparoPrefab.maxBalas;
                }

                Debug.Log($"Munición recogida: +{ammoAmount}. Balas actuales: {disparoPrefab.balasRestantes}");
            }

            // Destruye el objeto de munición después de ser recogido
            Destroy(gameObject);
        }
    }
}

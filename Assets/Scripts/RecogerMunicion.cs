using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecogerMunicion : MonoBehaviour
{
    public int ammoAmount = 40; 
    public float floatAmplitude = 0.1f; 
    public float floatSpeed = 100f; 

    [Header("Sonidos")]
    public AudioSource sonidoRecogida;
    
    private Vector3 startPosition;
    
    void Start()
    {
        startPosition = transform.position;
        sonidoRecogida = GameObject.Find("RecogerMunicion").GetComponent<AudioSource>();
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
                sonidoRecogida.Play();
                // Aumenta las balas mias
                disparoPrefab.balasRestantes += ammoAmount;

                // limite de balas
                if (disparoPrefab.balasRestantes > disparoPrefab.maxBalas)
                {
                    disparoPrefab.balasRestantes = disparoPrefab.maxBalas;
                }
                
            }

            Destroy(gameObject);
        }
    }
}

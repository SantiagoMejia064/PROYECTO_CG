using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0);
    public Text mensajeTexto; 
    public float tiempoMensaje = 1f; 

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
            MostrarMensaje("+ CheckPoint activado");
        }
    }

    
    private void MostrarMensaje(string mensaje)
    {
        if (mensajeTexto != null)
        {
            mensajeTexto.text = mensaje;
            mensajeTexto.gameObject.SetActive(true); 

            Debug.Log("Mensaje activado: " + mensajeTexto.text);

            Invoke(nameof(OcultarMensaje), tiempoMensaje);
        }
    }

    private void OcultarMensaje()
    {
        if (mensajeTexto != null)
        {
            mensajeTexto.gameObject.SetActive(false);
        }
    }
}

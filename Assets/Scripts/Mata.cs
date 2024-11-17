using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mata : MonoBehaviour
{
    public GameObject IMGMata; // Imagen asociada al objeto
    public GameObject Mensaje; // Panel de interacción
    private Inventario inventario; // Referencia al inventario

    private void Start()
    {
        inventario = FindObjectOfType<Inventario>();
        Mensaje.SetActive(false); // Asegúrate de que el mensaje esté desactivado al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mensaje.SetActive(true); // Muestra el panel de interacción
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mensaje.SetActive(false); // Oculta el panel de interacción
        }
    }

    public void RecogerObjeto()
    {
        if (inventario.AgregarAlInventario(IMGMata)) // Intenta agregar al inventario
        {
            Destroy(gameObject); // Si se agrega con éxito, destruye el objeto
        }
        else
        {
            Debug.Log("Inventario lleno. No puedes recoger más objetos.");
        }
        Mensaje.SetActive(false); // Oculta el panel de interacción
    }

    public void CancelarRecoleccion()
    {
        Mensaje.SetActive(false); // Oculta el panel sin recoger el objeto
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Libro : MonoBehaviour
{
    public GameObject libro;
    public GameObject IMGLibro;
    public GameObject Mensaje;

    [Header("Sonidos")]
    public AudioSource CogerObjeto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IMGLibro.SetActive(true);
            CogerObjeto.Play();
            Mensaje.SetActive(true);
        }
    }

    public void CerrarMensaje()
    {
        Mensaje.SetActive(false);
        Destroy(libro);
    }
}
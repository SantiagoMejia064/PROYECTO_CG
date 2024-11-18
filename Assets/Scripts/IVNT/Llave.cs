using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameObject llave;
    public GameObject IMGLlave;
    public GameObject MensajeLlave;
    public GameObject puertas;

    [Header("Sonidos")]
    public AudioSource cogerLlave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IMGLlave.SetActive(true);
            cogerLlave.Play();
            MensajeLlave.SetActive(true);
        }
        
    }

    public void CerrarMensaje()
    {
        MensajeLlave.SetActive(false);
        Destroy(llave);
        Destroy(puertas);
    }

}

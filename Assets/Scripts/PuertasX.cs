using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PuertasX : MonoBehaviour
{
    public GameObject Mensaje;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mensaje.SetActive(true);

        }
    }
    public void CerrarMensaje()
    {
        Mensaje.SetActive(false);
    }
}

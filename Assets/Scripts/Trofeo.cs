using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trofeo : MonoBehaviour
{
    public GameObject trofeo;
    public GameObject IMGTrofeo;
    public GameObject Mensaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IMGTrofeo.SetActive(true);

            Mensaje.SetActive(true);
        }
    }

    public void CerrarMensaje()
    {
        Mensaje.SetActive(false);
        Destroy(trofeo);
    }
}

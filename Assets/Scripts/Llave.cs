using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameObject llave;
    public GameObject IMGLlave;
    public GameObject MensajeLlave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IMGLlave.SetActive(true);

            MensajeLlave.SetActive(true);
        }
    }

    public void CerrarMensaje()
    {
        MensajeLlave.SetActive(false);
        Destroy(llave);
    }

}

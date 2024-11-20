using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioPP : MonoBehaviour
{
    public GameObject PP;
    public GameObject PP2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PP.SetActive(false);
            PP2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PP.SetActive(true);
            PP2.SetActive(false);
        }
    }
}

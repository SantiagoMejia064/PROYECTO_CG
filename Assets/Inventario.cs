using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventario : MonoBehaviour
{
    public  List<GameObject> SlotHolder = new List<GameObject>();

    public bool inventoryEnabled;
    public GameObject inventario;

    public bool hudEnabled;
    public GameObject HUD;

    public bool puzzleEnabled;
    public GameObject Puzzle;

    public GameObject OBJ1;
    public GameObject OBJ2;
    public GameObject OBJ3;

    public Text Texto1;
    public Text Texto2;
    public Text Texto3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;

            if (inventoryEnabled)
            {
                inventario.SetActive(true);
            }
            else
            {
                inventario.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Item"))
        {
            // Obtener el componente RawImage del objeto con el que colisionas
            RawImage rawImage = coll.GetComponent<RawImage>();

            // Verificar si el objeto colisionado tiene un componente RawImage
            if (rawImage != null)
            {
                for (int i = 0; i < SlotHolder.Count; i++)
                {
                    if (SlotHolder[i].GetComponent<Image>().enabled == false)
                    {
                        SlotHolder[i].GetComponent<Image>().enabled = true;
                        //SlotHolder[i].GetComponent<Image>().sprite = coll.GetComponent<RawImage>();
                        break;
                    }

                        break;
                    }
                }
            }
            else
            {
                Debug.LogWarning("No se encontró un componente RawImage en el objeto colisionado.");
            }
        }
    

    public void PanelAcertijo()
    {
        puzzleEnabled = true;
        Puzzle.SetActive(true);
        HUD.SetActive(false);
    }

    public void ActivarHUD()
    {
        HUD.SetActive(true);
        hudEnabled = true;
        Puzzle.SetActive(false);
        Texto1.gameObject.SetActive(false);
        Texto2.gameObject.SetActive(false);
        Texto3.gameObject.SetActive(false);
    }

    public void cerrarInventario()
    {
        HUD.SetActive(true);
        Puzzle.SetActive(false);
        inventario.SetActive(false);
        Texto1.gameObject.SetActive(false);
        Texto2.gameObject.SetActive(false);
        Texto3.gameObject.SetActive(false);
    }

    public void InteractOBJ1()
    {
        Texto1.gameObject.SetActive(true);
        Texto2.gameObject.SetActive(false);
        Texto3.gameObject.SetActive(false);
    }
    public void InteractOBJ2()
    {
        Texto2.gameObject.SetActive(true);
        Texto1.gameObject.SetActive(false);
        Texto3.gameObject.SetActive(false);
    }
    public void InteractOBJ3()
    {
        Texto3.gameObject.SetActive(true);
        Texto1.gameObject.SetActive(false);
        Texto2.gameObject.SetActive(false);
    }
}


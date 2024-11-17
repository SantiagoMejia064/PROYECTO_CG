using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject[] Slots = new GameObject[6];

    public bool inventoryEnabled;
    public GameObject inventario;

    public bool hudEnabled;
    public GameObject HUD;

    public bool puzzleEnabled;
    public GameObject Puzzle;

    public GameObject Libro;
    public GameObject IMGLibro;

    public GameObject llave;
    public GameObject IMGLlave;

    public GameObject Premio;
    public GameObject IMGPremio;

    public GameObject OBJ1;
    public GameObject OBJ2;
    public GameObject OBJ3;

    public Text Texto1;
    public Text Texto2;
    public Text Texto3;
    public Text Mensaje;

    private void Start()
    {
        
    }

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

        if (!IMGLibro.activeSelf)
        {
            Mensaje.gameObject.SetActive(true);
        }
        else if (IMGLibro.activeSelf)
        {
            Texto1.gameObject.SetActive(true);
            Texto2.gameObject.SetActive(false);
            Texto3.gameObject.SetActive(false);
            Mensaje.gameObject.SetActive(false);
        }
    }

    public void InteractOBJ2()
    {

        if (!IMGLlave.activeSelf)
        {
            Mensaje.gameObject.SetActive(true);
        }
        else if (IMGLlave.activeSelf)
        {
            Texto2.gameObject.SetActive(true);
            Texto3.gameObject.SetActive(false);
            Texto1.gameObject.SetActive(false);
            Mensaje.gameObject.SetActive(false);
        }
    }

    public void InteractOBJ3()
    {
        if (!IMGPremio.activeSelf)
        {
            Mensaje.gameObject.SetActive(true);
        }
        else
        {
            Texto3.gameObject.SetActive(true);
            Texto1.gameObject.SetActive(false);
            Texto2.gameObject.SetActive(false);
            Mensaje.gameObject.SetActive(true);
        }
    }
    public bool AgregarAlInventario(GameObject imagenObjeto)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i] == null) // Encuentra un slot vacío
            {
                Slots[i] = imagenObjeto; // Asigna la imagen al slot
                imagenObjeto.SetActive(true); // Activa la imagen en el inventario
                return true; // Devuelve verdadero si se agregó
            }
        }
        return false; // Devuelve falso si no hay espacio
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject> SlotHolder = new List<GameObject>();

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

    public GameObject interactionPanel; // Panel de mensaje
         

    private void Start()
    {
        interactionPanel.SetActive(false); // Asegura que el panel esté desactivado al inicio
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
        // Verifica si la imagen del libro está desactivada
        if (!IMGLibro.activeSelf)
        {
            Mensaje.gameObject.SetActive(true);
        }
        else if(IMGLibro.activeSelf)
        {
            Texto1.gameObject.SetActive(true);
            Texto2.gameObject.SetActive(false);
            Texto3.gameObject.SetActive(false);
            Mensaje.gameObject.SetActive(false);
        }
    }

    public void InteractOBJ2()
    {
        // Verifica si la imagen de la llave está desactivada
        if (!IMGLlave.activeSelf)
        {
            Mensaje.gameObject.SetActive(true);
        }
        else if(IMGLlave.activeSelf)
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
}




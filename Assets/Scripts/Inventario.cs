using System.Collections;
using System.Collections.Generic;
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

    public GameObject OBJ1;
    public GameObject OBJ2;
    public GameObject OBJ3;

    public Text Texto1;
    public Text Texto2;
    public Text Texto3;

    private int itemsCount = 0; // Contador de objetos en el inventario

    public Sprite MedKit; // Imagen para el primer objeto
    public Sprite Mata; // Imagen para el segundo objeto

    public GameObject interactionPanel; // Panel de confirmaci�n de recolecci�n
    private Sprite objetoSpriteActual; // Sprite del objeto actual que se va a recoger
    private GameObject objetoActual; // Referencia al objeto actual en la escena

    private void Start()
    {
        interactionPanel.SetActive(false); // Asegura que el panel de interacci�n est� desactivado al inicio
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

    private void OnTriggerEnter(Collider coll)
    {
        // Verifica si el jugador ha colisionado con un objeto recogible usando sus tags
        if (coll.CompareTag("MedKit") || coll.CompareTag("Mata"))
        {
            Debug.Log("Jugador entr� en el �rea del objeto recogible.");

            // Determina la imagen correspondiente basado en el tag del objeto
            if (coll.CompareTag("MedKit"))
            {
                objetoSpriteActual = MedKit;
            }
            else if (coll.CompareTag("Mata"))
            {
                objetoSpriteActual = Mata;
            }

            objetoActual = coll.gameObject; // Guarda la referencia al objeto actual

            // Activa el panel de interacci�n para preguntar al jugador si desea recoger el objeto
            interactionPanel.SetActive(true);
        }
    }

    // M�todo llamado desde el bot�n de confirmaci�n en el panel de interacci�n
    public void ConfirmarRecoleccion()
    {
        Debug.Log("Intentando recoger el objeto.");
        bool agregado = AgregarObjetoAlInventario(objetoSpriteActual);

        if (agregado)
        {
            Debug.Log("Objeto recogido y agregado al inventario.");
            Destroy(objetoActual);
        }
        else
        {
            Debug.Log("Inventario lleno, no se puede recoger m�s objetos.");
        }

        interactionPanel.SetActive(false);
    }

    // M�todo para cerrar el panel de interacci�n si el jugador decide no recoger el objeto
    public void CancelarRecoleccion()
    {
        interactionPanel.SetActive(false);
        objetoActual = null; // Limpia la referencia al objeto actual
    }

    // M�todo para agregar el objeto al inventario con la imagen correspondiente
    private bool AgregarObjetoAlInventario(Sprite objetoSprite)
    {
        if (itemsCount < SlotHolder.Count)
        {
            // Activa el slot correspondiente y asigna la imagen del objeto recogido
            SlotHolder[itemsCount].SetActive(true); // Activa el GameObject del slot

            // Aseg�rate de que el slot tiene un componente Image y asigna el sprite
            Image slotImage = SlotHolder[itemsCount].GetComponent<Image>();
            if (slotImage != null)
            {
                
                slotImage.sprite = objetoSprite; // Asigna el sprite al Image del slot
                Debug.Log("Imagen asignada al slot: " + itemsCount); // Verifica que se asign� el sprite
            }
            else
            {
                Debug.Log("El slot en la posici�n " + itemsCount + " no tiene un componente Image."); // Advertencia si falta el componente Image
            }

            itemsCount++;
            return true;
        }
        else
        {
            return false; // Inventario lleno
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




using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventario : MonoBehaviour
{
	private int allSlots;
	private int enabledSlots;
	public GameObject[] slot;
	public GameObject SlotHolder;

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

	public GameObject panelRecoger;

    // Variables temporales para almacenar el item actual
    private GameObject itemRecogido;
    private int itemID;
    private string itemType;
    private string itemDescription;
    private Sprite itemIcon;

    private void Start()
	{
		allSlots = SlotHolder.transform.childCount;

		slot = new GameObject[allSlots];

		for(int i = 0; i < allSlots; i++)
		{
			slot[i] = SlotHolder.transform.GetChild(i).gameObject;

			if(slot[i].GetComponent<Slot>().item == null)
			{
				slot[i].GetComponent<Slot>().empty = true;
			}
		}
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemRecogido = other.gameObject;
            Item item = itemRecogido.GetComponent<Item>();

            // Asignar datos temporales del item
            itemID = item.ID;
            itemType = item.type;
            itemDescription = item.description;
            itemIcon = item.icon;

            panelRecoger.SetActive(true);
        }
    }

    public void colocarItem()
    {
        if (itemRecogido != null)
        {
            // Llamar a AddItem con los datos temporales
            AddItem(itemRecogido, itemID, itemType, itemDescription, itemIcon);
            panelRecoger.SetActive(false);
        }
    }
	public void CancelarRecogida()
	{
		panelRecoger.SetActive(false);
	}

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for(int i = 0; i < allSlots; i++)
        {
			if (slot[i].GetComponent<Slot>().empty)
			{
				itemObject.GetComponent<Item>().Recogido = true;

				slot[i].GetComponent<Slot>().item = itemObject;
				slot[i].GetComponent<Slot>().ID = itemID;
				slot[i].GetComponent<Slot>().type = itemType;
				slot[i].GetComponent<Slot>().description = itemDescription;
				slot[i].GetComponent<Slot>().icon = itemIcon;

				itemObject.transform.parent = slot[i].transform;
				itemObject.SetActive(false);

				slot[i].GetComponent<Slot>().UpdateSlot();

				slot[i].GetComponent<Slot>().empty = false;

                return;
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

	/*
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
	*/
}
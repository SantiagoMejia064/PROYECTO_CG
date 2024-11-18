using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;

    public bool empty;
    public Sprite icon;

    public Sprite defaultSprite; // La mascara o fondo del slot

    public Transform slotIconGameObject;

    private Inventario inventario;

    [Header("Sonidos")]
    public AudioSource curacion;

    private void Start()
    {
        //slotIconGameObject = transform.GetChild(0);

        inventario = FindAnyObjectByType<Inventario>();
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }

    public void UsarItem()
    {
        item.GetComponent<Item>().UsoItem();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (item != null)
        {
            UsarItem();

            Destroy(item);

            curacion.Play();

            ClearSlot();
        }
    }

    // Metodo para limpiar el contenido del slot
    public void ClearSlot()
    {
        // Reiniciar referencias del item dentro del slot
        item = null;
        ID = 0;
        type = null;
        description = null;
        icon = null;

        // Restaurar el sprite del slot (la mascara o fondo predeterminado)
        GetComponent<Image>().sprite = defaultSprite;

        if (slotIconGameObject != null)
        {
            // Limpia unicamente el icono del hijo que representa al item
            Image itemIconImage = slotIconGameObject.GetComponent<Image>();
            if (itemIconImage != null)
            {
                itemIconImage.sprite = null; // Elimina el �cono
            }
        }

        // Marcar el slot como vacio
        empty = true;
    }
}

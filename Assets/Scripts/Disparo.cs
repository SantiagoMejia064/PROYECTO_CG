using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPrefab : MonoBehaviour
{
    public Transform firePoint;
    public GameObject balaPrefab;
    public float fireRate;
    private Animator anim;

    public int maxBalas = 60; 
    public int balasRestantes; 
    public int aumentaBalas = 30; // Cantidad de balas que otorga

    public bool estadoDisparo = false;
    
    [SerializeField] private float tiempoDisparo;
    
    public AudioSource disparo;

    private Inventario inventario;
    private Libro libro;
    private Llave llave;
    private Trofeo trofeo;
    private PuertasX puertas;

    void Awake()
    {
        anim = GetComponent<Animator>();
        balasRestantes = maxBalas;
    }

    private void Start()
    {
        puertas = FindAnyObjectByType<PuertasX>();
        libro = FindAnyObjectByType<Libro>();
        llave = FindAnyObjectByType<Llave>();
        trofeo = FindAnyObjectByType<Trofeo>();
        inventario = FindAnyObjectByType<Inventario>();
    }
    public void Disparar()
    {
        
        if (balasRestantes > 0) // Verificar que haya balas
        {
            GameObject bala = Instantiate(balaPrefab, firePoint.position, firePoint.rotation);
            balasRestantes--;
        }
        
    }

    void Update()
    {
        // Evitar disparar si el inventario está abierto
        if (inventario.inventoryEnabled || inventario.panelRecoger.activeSelf || libro.Mensaje.activeSelf || llave.MensajeLlave.activeSelf || trofeo.Mensaje.activeSelf || puertas.Mensaje.activeSelf)
        {
            estadoDisparo = false;
            return; // Salir del Update si el inventario está activo
        }


        tiempoDisparo += Time.deltaTime;

        if(tiempoDisparo > fireRate){
            
            if(Input.GetButtonDown("Disparo"))
            {
                //Disparar();
                estadoDisparo = true;
                anim.SetTrigger("Shoot");
                disparo.Play();
                tiempoDisparo = 0;
            }
        }   
    }

}
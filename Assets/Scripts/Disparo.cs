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
    
    [SerializeField] private float tiempoDisparo;
    
    public AudioSource disparo;

    void Awake()
    {
        anim = GetComponent<Animator>();
        balasRestantes = maxBalas;
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
        tiempoDisparo += Time.deltaTime;

        if(tiempoDisparo > fireRate){
            
            if(Input.GetButtonDown("Disparo"))
            {
                //Disparar();
                anim.SetTrigger("Shoot");
                disparo.Play();
                tiempoDisparo = 0;
            }
        }   
    }

}
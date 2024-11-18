using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPrefab : MonoBehaviour
{
    public Transform firePoint;
    public GameObject balaPrefab;
    public float fireRate;
    private Animator anim;
    
    [SerializeField] private float tiempoDisparo;
    
    public AudioSource disparo;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Disparar()
    {
        
        Instantiate(balaPrefab, firePoint.position, firePoint.rotation);
        
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
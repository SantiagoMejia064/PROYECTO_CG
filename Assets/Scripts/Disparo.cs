using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPrefab : MonoBehaviour
{
    public Transform firePoint;
    public GameObject balaPrefab;
    public float fireRate;
    private Animator anim;
    //public AudioSource disparo;
    [SerializeField] private float tiempoDisparo;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Disparar()
    {
        //disparo.Play();
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
                tiempoDisparo = 0;
            }
        }   
    }
}
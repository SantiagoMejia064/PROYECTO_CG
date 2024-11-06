using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int  damage;

    private void Start()
    {
        rb.velocity = transform.right*speed;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if(collision.CompareTag("Piso"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("Enemigo"))
        {
            if(collision.GetComponent<Zombies>() != null){
                collision.GetComponent<Zombies>().GetDamage(damage);
                Destroy(gameObject);
                //collision.GetComponent<Enemigo>().Dead();
            }
        }
        else{
            Destroy(gameObject, 2);
        }       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

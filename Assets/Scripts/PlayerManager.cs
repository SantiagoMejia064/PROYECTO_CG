using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int salud;
    public GameObject Player;
    private Animator anim;
    public AudioSource muerte;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void GetDamage(int dmg)
    {
        salud -= dmg;  // Resta la cantidad de daño

        Die();
    }

    public void Die()
    {
        if (salud <= 0)
        {
            //muerte.Play();
            anim.SetTrigger("Dead");
            Invoke("DestruirPersonaje", 1f); 
             // Espera 1 segundos antes de destruir el objeto            
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde está este script (el jugador)
    }
}

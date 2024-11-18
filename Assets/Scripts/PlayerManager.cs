using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int salud = 100;
    public int maxSalud = 100;

    [Header("Interfaz")]
    public Image barraSalud;
    public Text textoSalud;
    public CanvasGroup ojosRojos;


    public GameObject Player;
    private Animator anim;
    //public AudioSource muerte;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        actualizarSalud();
        if(ojosRojos.alpha > 0)
        {
            ojosRojos.alpha -= Time.deltaTime;
        }
    }

    void actualizarSalud(){
        barraSalud.fillAmount = (float)salud / maxSalud;
        textoSalud.text = salud.ToString() + " / " + maxSalud.ToString("f0");
    }

    public void GetDamage(int dmg)
    {
        salud -= dmg;  // Resta la cantidad de daño
        ojosRojos.alpha = 1;  // Hace que los ojos rojos se vean

        Die();
    }

    public void CuracionMedKit()
    {
        salud = salud + 50;

        if (salud > maxSalud)
        {
            salud = maxSalud;
        }
    }

    public void CuracionMata()
    {
        salud = salud + 30;

        if (salud > maxSalud)
        {
            salud = maxSalud;
        }
    }

    public void Die()
    {
        if (salud <= 0)
        {
            //muerte.Play();
            anim.SetTrigger("Death");
            Invoke("DestruirPersonaje", 3f); 
            // Espera 1 segundos antes de destruir el objeto            
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde está este script (el jugador)
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private Transform controlGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int damageGolpe;
    [SerializeField] private float timeEntreAtaque;
    [SerializeField] private float timeSigAtaque;
    
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
  
    }

    public void isGroundedEnemy(Collider collision)
    {
        
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
       
    }


    public void Atacar()
    {
        // Crear un área esférica para detectar colisión con el jugador
        Collider[] colisiones = Physics.OverlapSphere(controlGolpe.position, radioGolpe, LayerMask.GetMask("Player"));

        // Verificar si se ha encontrado algún jugador dentro del área de colisión
        foreach (Collider colision in colisiones)
        {
            if (colision.CompareTag("Player"))
            {
                PlayerManager enemigo = colision.GetComponent<PlayerManager>();
                if (enemigo != null)
                {
                    enemigo.GetDamage(damageGolpe);
                }
            }
        }
    }
    
    private void DibujarAreaDeAtaque()
    {
        if (controlGolpe != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(controlGolpe.position, radioGolpe);
        }
    }

}

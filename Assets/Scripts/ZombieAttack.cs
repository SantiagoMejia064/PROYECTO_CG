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
    
    //private Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
  
    }

    public void Atacar()
    {
        Debug.Log("Atacando");
        // Crear un área esférica para detectar colisión con el jugador
        Collider[] colisiones = Physics.OverlapSphere(controlGolpe.position, radioGolpe, LayerMask.GetMask("Player"));
        Debug.Log("Colisiones: " + colisiones.Length);
        // Verificar si se ha encontrado algún jugador dentro del área de colisión
        foreach (Collider colision in colisiones)
        {
            Debug.Log("el ataque ha encontrado al jugador");
            if (colision.CompareTag("Player"))
            {
                Debug.Log("el ataqué entró en contacto con el jugador");
                PlayerManager player = colision.GetComponent<PlayerManager>();
                if (player != null)
                {
                    player.GetDamage(damageGolpe);
                }
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        if (controlGolpe != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(controlGolpe.position, radioGolpe);
        }
    }

}

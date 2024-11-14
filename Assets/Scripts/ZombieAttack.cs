using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private Transform controlGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private int damageGolpe;
    
    public void Atacar()
    {
        
        // Crear un área esférica para detectar colisión con el jugador
        Collider[] colisiones = Physics.OverlapSphere(controlGolpe.position, radioGolpe, LayerMask.GetMask("Player"));
        // Verificar si se ha encontrado algún jugador dentro del área de colisión
        foreach (Collider colision in colisiones)
        {
            if (colision.CompareTag("Player"))
            {
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

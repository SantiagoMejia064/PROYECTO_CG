using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombies : MonoBehaviour
{
    [SerializeField] private float timeEntreAtaque;
    [SerializeField] private float timeSigAtaque;
    public GameObject ammoPrefab; // Prefab de la munición
    public Transform dropPoint; 

    [Header("Salud")]
    public float salud;
    
    [Header("Referencias")]
    public Transform player; // Referencia al jugador
    public NavMeshAgent agent;
    public PlayerManager playerManager;
    public float rangoDeteccion = 5f; // Rango de detección para seguir al jugador
    public float rangoAtaque = 1f; // Rango de ataque al jugador
    public float velocidad = 2f; // Velocidad de movimiento del enemigo
    public Animator anim; // Referencia al Animator del enemigo

    private Rigidbody rb;
    //public AudioSource muerte;


    void Start()
    {
        if (player == null)
        {
            // Busca al jugador por la etiqueta "Player" si no está asignado
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                player = jugador.transform;
            }
        }

        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

    }

    void Update()
    {
        timeEntreAtaque += Time.deltaTime;

        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= rangoDeteccion)
        {
           
            agent.destination = player.position;
            anim.SetBool("Walk", true); // Activar animación de caminar

            /*
            // Dirección hacia el jugador
            Vector3 direccion = (player.position - transform.position).normalized;

            // Movimiento del enemigo
            Vector3 nuevaPosicion = new Vector3(direccion.x * velocidad, rb.velocity.y, direccion.z * velocidad);
            rb.velocity = nuevaPosicion;

            anim.SetBool("Walk", true); // Activar animación de caminar

            // Rotación del enemigo usando Quaternion para evitar conflictos
            Quaternion nuevaRotacion = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, nuevaRotacion, Time.deltaTime * velocidad);
            */
        }
        else
        {
            /*
            // Si el jugador está fuera del rango, detener el movimiento
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            */
            agent.destination = agent.transform.position;
            anim.SetBool("Walk", false); // Desactivar animación de caminar
            
        }

        if(player != null && playerManager.salud > 0){
            if (timeEntreAtaque > timeSigAtaque){
                if (distancia <= rangoAtaque)
                {
                    // Atacar al jugador
                    anim.SetTrigger("Attack");
                    timeEntreAtaque = 0;
                }
            }
        }
        
    }
    

    public void GetDamage(int dmg)
    {
        salud -= dmg;  // Resta la cantidad de daño
        Dead();
    }

    public void Dead()
    {
        if (salud <= 0)
        {
            //muerte.Play();
            anim.SetTrigger("Death");
            playerManager.cantidadZombies--;
            Invoke("DestruirPersonaje", 10f); 
            DropAmmo(); 
        } 
        
    }

    public void Kill()
    {
        salud = 0;
        Dead();
    }

    private void DropAmmo()
    {
        Debug.Log("Intentando soltar munición...");

        if (ammoPrefab != null && dropPoint != null)
        {
            Debug.Log("Prefab y DropPoint asignados correctamente.");

        // Liberar el DropPoint de la jerarquía del zombie
            dropPoint.parent = null;

        // Calculamos la posición donde aparecerá la munición
            Vector3 spawnPosition = dropPoint.position + Vector3.up * 1f;

        // Instanciamos la munición
            Instantiate(ammoPrefab, spawnPosition, Quaternion.identity);

            Debug.Log("Munición instanciada en: " + spawnPosition);
        }
        else
        {
            Debug.LogError("Error: AmmoPrefab o DropPoint no están asignados.");

        }
    
    }   


    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde está este script (el enemigo)
    }

    // Opcional: Dibujar el rango de detección en la escena
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}

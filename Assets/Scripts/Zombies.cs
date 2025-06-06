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
    private bool isDeath = false;

    [Header("Salud")]
    public float salud;
    
    [Header("Referencias")]
    public Transform player; // Referencia al jugador
    public NavMeshAgent agent;
    public PlayerManager playerManager;
    public float rangoDeteccion = 5f; // Rango de detección para seguir al jugador
    public float rangoAtaque = 1f; // Rango de ataque al jugador
    public float rangoDestruccion;
    public float velocidad = 2f; // Velocidad de movimiento del enemigo
    public Animator anim; // Referencia al Animator del enemigo

    private Rigidbody rb;
    //public AudioSource muerte;

    [Header("Sonidos")]
    public AudioSource hitZombie;

    [Header("Colisiones")]
    public CapsuleCollider capsuleCollider; // Referencia al CapsuleCollider del enemigo
    public float colliderAlturaMuerte = 0f; // Altura del CapsuleCollider al morir
    public float colliderRadioMuerte = 0.14f; // Radio del CapsuleCollider al morir
    public float nuevoRadio = 0.24f;
    public float nuevaAltura = 0.36f;
    public float nuevaBaseOffset = -0.8f;


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

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerManager = player.GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        hitZombie = GameObject.Find("HitZombie").GetComponent<AudioSource>();
        
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }

    }

    void Update()
    {
        timeEntreAtaque += Time.deltaTime;

        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia <= rangoDeteccion && !isDeath)
        {
            if (agent.isOnNavMesh)
            {
                agent.destination = player.position;
                anim.SetBool("Walk", true); 
            }
            
        }
        else
        {
            if (agent.isOnNavMesh)
            {
                agent.destination = agent.transform.position;
                anim.SetBool("Walk", false);
            }
            
        }


        if(distancia > rangoDestruccion){
            Destroy(gameObject);
            playerManager.cantidadZombies--;
        }

        if(player != null && playerManager.salud > 0 && !isDeath){
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
        hitZombie.Play();  // Reproduce el sonido de recibir daño
        Dead();
    }

    public void Dead()
    {
        if (salud <= 0)
        {
            isDeath = true;
            //muerte.Play();
            anim.SetTrigger("Death");
            StartCoroutine(ReducirCollider());
            playerManager.cantidadZombies--;
            Invoke("DestruirPersonaje", 3f); 
            DropAmmo(); 
        }  
    }

    private void DestruirPersonaje()
    {
        Destroy(gameObject);
    }

    public void OnBecameInvisible()
    {
        playerManager.cantidadZombies--;
        Destroy(gameObject);
    }

    private IEnumerator ReducirCollider()
    {
        // Esperar 1 segundo para sincronizar con la animación (ajustar según tu animación)
        yield return new WaitForSeconds(1.1f);

        // Reducir el tamaño del CapsuleCollider
        capsuleCollider.height = colliderAlturaMuerte;
        capsuleCollider.radius = colliderRadioMuerte;

        // Cambiar el radio y la altura del agente
        agent.radius = nuevoRadio;
        agent.height = nuevaAltura;
        agent.baseOffset = nuevaBaseOffset;
    }


    private void DropAmmo()
    {
        Debug.Log("Intentando soltar munición...");

        if (ammoPrefab != null && dropPoint != null)
        {
            Debug.Log("Prefab y DropPoint asignados correctamente.");
            dropPoint.parent = null;
        // Posicion de reaparicion del cargadorcito
            Vector3 spawnPosition = dropPoint.position + Vector3.up * 1f;
            Instantiate(ammoPrefab, spawnPosition, Quaternion.identity);

        }
        else
        {
            Debug.LogError("Error: AmmoPrefab o DropPoint no están asignados.");

        }
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

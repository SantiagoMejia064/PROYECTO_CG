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

    [Header("Zombies")]
    public float rangoMax = 20f; // Rango de generación de zombie máximo
    public float rangoMin = 5f;  // Rango de generación de zombie mínimo
    public GameObject zombiePrefab; // Prefab del zombie que se generará
    public float tiempoGeneracion = 20f; // Tiempo entre generación de zombies
    public int cantidadZombies = 0; // Cantidad de zombies generados
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(GenerarZombies()); // Iniciar la rutina para generar zombies
    }

    void Update()
    {
        actualizarSalud();
        if (ojosRojos.alpha > 0)
        {
            ojosRojos.alpha -= Time.deltaTime;
        }
    }

    void actualizarSalud()
    {
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
            anim.SetTrigger("Death");
            Invoke("DestruirPersonaje", 3f); 
        }
    }

    public void DestruirPersonaje()
    {
        Destroy(gameObject);  // Destruye el objeto donde está este script (el jugador)
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoMax);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangoMin);
    }

    private IEnumerator GenerarZombies()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoGeneracion); // Esperar tiempo determinado

            if (cantidadZombies >= 15) // Si ya hay 15 zombies generados, no generar más
            {
                continue;
            }
            Vector3 posicionAleatoria = GenerarPosicionAleatoria();
            Instantiate(zombiePrefab, posicionAleatoria, Quaternion.identity); // Genera un zombie
            cantidadZombies++;
        }
    }

    private Vector3 GenerarPosicionAleatoria()
    {
        Vector3 posicion;
        do
        {
            // Generar una posición aleatoria en un rango cuadrado
            float offsetX = Random.Range(-rangoMax, rangoMax);
            float offsetZ = Random.Range(-rangoMax, rangoMax);
            posicion = new Vector3(transform.position.x + offsetX, transform.position.y, transform.position.z + offsetZ);
        }
        while (Vector3.Distance(transform.position, posicion) < rangoMin || Vector3.Distance(transform.position, posicion) > rangoMax); // Asegurarse de que esté dentro del rango permitido

        return posicion;
    }
}

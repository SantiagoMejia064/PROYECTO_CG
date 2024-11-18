using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBalas : MonoBehaviour
{
    public static GameBalas Instance { get; private set; }
    public Text textoBalas;  
    private DisparoPrefab disparoJugador; 

    void Start()
    {
        disparoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<DisparoPrefab>();
    }

    void Update()
    {
        if (disparoJugador != null)
        {
            textoBalas.text = disparoJugador.balasRestantes.ToString();
        }
    }
}

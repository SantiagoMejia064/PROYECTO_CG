using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaManager : MonoBehaviour
{
    public void inicioJuego()
    {
        SceneManager.LoadScene("Principal", LoadSceneMode.Single);
    }

    public void salirJuego()
    {
        Application.Quit();
    }
}

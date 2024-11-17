using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoTrofeo : MonoBehaviour
{
    public float velocidadParpadeo = 2f; 
    public float intensidadMin = 0f;    
    public float intensidadMax = 2f;    
    private Light luz;

    void Start()
    {
        luz = GetComponent<Light>();
    }

    void Update()
    {
        luz.intensity = Mathf.Lerp(intensidadMin, intensidadMax, Mathf.PingPong(Time.time * velocidadParpadeo, 1));
    }
}

    


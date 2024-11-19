using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCheck : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 50, 0); // Velocidad de rotación en cada eje (x, y, z)

    void Update()
    {
        // Aplica la rotación continua
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}

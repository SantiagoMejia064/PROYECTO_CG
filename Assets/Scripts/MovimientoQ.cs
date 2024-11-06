using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQ : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    private Rigidbody rb;

    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveSpeed * verticalInput;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        rb.MovePosition(rb.position + movement * Time.deltaTime);
        rb.MoveRotation(rb.rotation * rotation);

        if(verticalInput > 0)
        {
            anim.SetFloat("RunF", Mathf.Abs(verticalInput));
        }else{
            anim.SetFloat("RunF", 0);
        }

        if(verticalInput < 0){
            anim.SetFloat("RunB", Mathf.Abs(verticalInput));
        }else{
            anim.SetFloat("RunB", 0);
        }

        
    }
    void Update()
    {
        
    }
}

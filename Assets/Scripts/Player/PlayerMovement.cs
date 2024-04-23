using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int speed;
    Rigidbody rb;
    Animator anim;
    Vector3 movement;// grabar la direccion de movimiento
    float horizontal; // movimiento horizontal
    float vertical; // movimiento vertical
    public LayerMask layerFloor; // capa suelo de escena

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
    }
    private void FixedUpdate()
    {
        Move();
        Turning();
        Animating();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void Move()
    {
        movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();// Normalizar el vector

        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));

        // Detener el movimiento al soltar la tecla
       

        // Debug.Log(rb.velocity);
    }
    
    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerFloor))
        {
            //Debug.Log("Colision");

            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;

            // Calculo de rotacion
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            rb.MoveRotation(newRotation);
        }

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);       
    }

    void Animating()
    {
        if(horizontal != 0 || vertical != 0) {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}

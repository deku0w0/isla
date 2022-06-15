using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoventControoller : MonoBehaviour
{
    [Header("movimiento de personaje")]
    public float speedMovent;
    public Vector3 direccion;
    public CharacterController controller;
  
    [Header("gravedad")]
    public float jumpHeight;
    public float gravity = -9.8f;
    public Vector3 desplazamientoEnY;

    [Header("rotation")]
        public float rotacionPlayerY;
    private void Update()
    {
        //calcular la gravedad de cada frame
        desplazamientoEnY.y += gravity*2f * Time.deltaTime;

        //mover el pesonaje en "y" con base a la gravedad acumulada 
        controller.Move(desplazamientoEnY * Time.deltaTime);

       //si esta tocando el suelo y el valor de y es negativo entonces restar la gravedad 
       if (controller.isGrounded && desplazamientoEnY.y < 0)
       {
            desplazamientoEnY.y = -2f;
       }

       //si el personaje est tocadno el suelo y preciona la tecla, calcular el salto del personaje 
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
           desplazamientoEnY.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Move(float Vertical, float Horizontal)
    {
        //captura valores del analogo para el movimiento del enemigo
        direccion.x = Horizontal;
        direccion.z = Vertical;

        //transformar la direccion de coordenadas del jugador
        direccion = transform.TransformDirection(direccion);

        //mover jugador en base a los imputs
        controller.Move(direccion * Time.deltaTime * speedMovent);
    }

    public void Rotate(float rotateValue) 
    {

        rotacionPlayerY += rotateValue;

        //rotar el personaje en base al movimiento acumulaod 
        controller.transform.rotation = Quaternion.Euler(0, rotacionPlayerY, 0);
       
    } 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per fram
}
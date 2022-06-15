using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoventControoller))]


public class PlayerController : MonoBehaviour
{

    [Header("movimiento camara")]
    public Vector2 mouseMovent;
    public Camera playerCamera;
    private float rotacionCameraX;
    public float sensibilidadDelRaton;

    [Header("movimiento controller")]
    public MoventControoller movement;

    private void Update()
    {
        movement.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        movement.Rotate(Input.GetAxis("Mouse X"));
        //capturar movimiento del mouse 
        mouseMovent = new Vector2(Input.GetAxis("Mouse X") * sensibilidadDelRaton, Input.GetAxis("Mouse Y") * sensibilidadDelRaton);

       // mouseMovent.x = Input.GetAxis("Mouse X");
        //mouseMovent.y = Input.GetAxis("Mouse Y");

        //almacenar el movimiento del mouse
        rotacionCameraX -= mouseMovent.y;
     

        //limitar ek movimiento de la camara en el ege x
        rotacionCameraX = Mathf.Clamp(rotacionCameraX, -60, 40);

        //rotar la camara del personaje en base a el movimiento acumulado 
        playerCamera.transform.localRotation = Quaternion.Euler(rotacionCameraX, 0, 0);

    }



}

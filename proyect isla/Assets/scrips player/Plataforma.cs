using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject plataform;
    public GameObject button;

    public Transform minPosition;
    public Transform maxPosition;

    public float speedMovent;

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            MovePlataform();
        }

    }

    private void MovePlataform()
    {
        plataform.transform.Translate(Vector3.up * Time.deltaTime * speedMovent);
        if (plataform.transform.position.y < minPosition.position.y)
        {
               
                speedMovent = 5f;
        }
       if (plataform.transform.position.y > maxPosition.position.y)
       {
                speedMovent = -5f;

       }

        
    } 
}


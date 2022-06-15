using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIntersctions : MonoBehaviour
{ 
    public PlayerEstadistics player;
    public Transform cam;
    public Transform objetoVacio;
    public Transform ArmaVacia;
    public GameObject Arma;
    public LayerMask lm;
    private void Update()

    { 
        if (Input.GetButtonDown("E"))
        {

            if (objetoVacio.childCount > 0)
            {
                objetoVacio.GetComponentInChildren<Rigidbody>().isKinematic = false;
                objetoVacio.GetChild(0).transform.parent = null;
            }
            else
            {
                RaycastHit hit;
                Debug.DrawRay(cam.position, cam.forward * 6, Color.green);
                if (Physics.Raycast(cam.position, cam.forward, out hit, 6f, lm))
                {

                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.parent = objetoVacio;
                    hit.transform.localPosition = Vector3.zero;

                }
            }
            if (objetoVacio.childCount > 0  && ArmaVacia.childCount > 0)
            {
                Arma.gameObject.SetActive(false);
            }
            if (objetoVacio.childCount == 0 && ArmaVacia.childCount > 0) 
            {
                Arma.gameObject.SetActive(true);
            }
        }
    }
   
    private void OnTriggerEnter(Collider other)
       

    {
        if (other.tag == "door"&& player.BatteryCount>=3)
        {
            other.GetComponentInParent<door>().OnOpenDoor();
        }
        if (other.tag =="batery")
        {
            other.GetComponentInParent<batery>().desaparecer();
            player.BatteryCount++;
        }
        if (other.tag == "Gun" && objetoVacio.childCount < 1)
        {
            Arma.transform.parent = ArmaVacia;
            Arma.transform.localPosition = Vector3.zero;
            Arma.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform cañon;
    public GameObject BalaPrefab;
    public Transform arma;
    public float fuerza;
    public AudioSource audi;
    public AudioClip elSonido;
    public float volumen = 56F;
    public int cartuchoMax = 35;
    private int cartuchoActual;


    private void Start()
    {
        cartuchoActual = cartuchoMax;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && arma.childCount >0 && cartuchoActual>0)
        {
            Disparo();
        }
        if (Input.GetButtonDown("R"))
        {
            reload();
        }

    }
    void Disparo()
    {
      GameObject go =  Instantiate(BalaPrefab, cañon.transform.position,cañon.transform.rotation);
      go.GetComponent<Rigidbody>().AddForce(go.transform.forward*fuerza,ForceMode.Impulse);

      AudioSource.PlayClipAtPoint(elSonido, gameObject.transform.position);

      Destroy(go.gameObject, 3f);

        cartuchoActual--;  
    }

    void reload()
    {
        cartuchoActual = cartuchoMax;
    }

}

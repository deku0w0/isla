using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batery : MonoBehaviour
{
    public AudioSource audi;
    public AudioClip elSonido;
    public float volumen =1F;
   public void desaparecer()
    {
        AudioSource.PlayClipAtPoint(elSonido, gameObject.transform.position);
        Destroy(gameObject);
        
    }

}



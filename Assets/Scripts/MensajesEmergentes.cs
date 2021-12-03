using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajesEmergentes : MonoBehaviour
{
   
    public GameObject mensaje;
    public bool mensajeEliminado;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !mensajeEliminado)
        {
            mensaje.SetActive(true);
        }
       



    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !mensajeEliminado) 
        {
            mensaje.SetActive(false);
        }
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   
}

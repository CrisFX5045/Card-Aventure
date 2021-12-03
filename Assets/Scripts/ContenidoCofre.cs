using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContenidoCofre : MonoBehaviour
{
    public Carta[] cartasEnCofre;
    public Sprite cofreAbiertoImagen;
    public bool cofreEstaAbierto=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cofreHaSidoAbierto()
    {
        cofreEstaAbierto = true;
    }

   
  
}

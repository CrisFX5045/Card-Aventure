using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour
{


    public void CambiarEscena(string escena)
    {
        try
        {
            GameManager.instancia.CambiarEscena(escena);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
    }
    public void SalirJuego()
    {
        try
        {
            GameManager.instancia.Salir();
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
    }

    }

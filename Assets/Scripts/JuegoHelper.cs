using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoHelper : MonoBehaviour
{
    public string EscenaMenu;
    public void SalirMenu()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaMenu);
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

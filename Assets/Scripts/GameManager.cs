using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singelton
    private static GameManager _instancia;
    public static GameManager instancia
    {

        get
        {
            return _instancia;
        }
    }

    // Miembros de clase privados

    private int _puntaje;
    private List<string> enemigosEliminados;
    public List<Carta> cartasIventario;

    public int ObtenerPuntaje()
    {
        return _puntaje;
    }

    public void RestaurarPuntaje()
    {
        _puntaje = 0;
    }

    public void SumarPunataje(int valor)
    {
        _puntaje += valor;
    }
    public void SetBaraja(List<Carta> cartasIventarioTem)
    {
        cartasIventario = cartasIventarioTem;
    }
    public void SetEnemigosEliminados(List<string> enemigosEliminadosTem)
    {
        enemigosEliminados = enemigosEliminadosTem;
    }
    public List<Carta> ObtenerBaraja()
    {
        return cartasIventario;
    }

    public List<string> ObtenerNombreEnemigosEliminados()
    {
        return enemigosEliminados;
    }

    public void Awake()
    {
        if (_instancia == null)
        {
            _instancia = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void CambiarEscena(string nombreEscenna)
    {
        SceneManager.LoadScene(nombreEscenna);
    }

    public void Salir()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        //operaciones ante el evento cerrar la aplicacion
        //cerrar la conexion a la bd
        //cerrar las lectura de archivos
        //pausar  el contador el tiempo de juego

    }


    public bool GuardarPuntaje(int posicion, int valor)
    {

        try
        {
            PlayerPrefs.SetInt("Pos" + posicion.ToString(), valor);
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }


    public int ObtenerPuntaje(int posicion)
    {
        return PlayerPrefs.GetInt("Pos" + posicion.ToString(), 0);
    }
}

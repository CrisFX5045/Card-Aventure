using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EscenaWin : MonoBehaviour
{
    public Text puntaje;
    public Text enemigosEliminadosText;
    private List<string> enemigosEliminados;
    public GameObject ordenarCartas;
    private void Start()
    {
        enemigosEliminados = GameManager.instancia.ObtenerNombreEnemigosEliminados();
        ValoresWin();
    }

    public void ValoresWin()
    {
        try
        {
            puntaje.GetComponent<Text>().text= GameManager.instancia.ObtenerPuntaje().ToString();
            enemigosEliminadosText.GetComponent<Text>().text = EnemigosEliminadosOrdenados();
            ordenarCartas.GetComponent<BarajaWin>().ordenarCartas();
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
    }

    public string EnemigosEliminadosOrdenados()
    {
        string textoEnemigos="";

        for (int i = 0; i < enemigosEliminados.Count; i++)
        {
            textoEnemigos += enemigosEliminados[i]+ "\n";
        }
        return textoEnemigos;
    }



}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class MenuCartas : MonoBehaviour
{

    
    public GameObject menu;
    public Player playerTemp;
    public List<Carta> cartasIventarioTemp;
    public CartasUI[] cartasMenu;
    public GameObject[] botonesCartas;
    private bool activarCartas= true;
    public GameObject NuevasCartas;
    public void ActivarMenu(Player player)
    {
        menu.SetActive(true);
        playerTemp = player;
        NuevasCartas.SetActive(false);
        ordenarCartas();
    }
    public void DesctivarMenu()
    {
        menu.SetActive(false);
      
    }

    public void ordenarCartas()
    {
        cartasIventarioTemp = playerTemp.obtenerInventario();

        if (cartasIventarioTemp.Any())
        {
            Debug.Log("Si tiene cartas y su primera carta se llama:" + cartasIventarioTemp[0].nombre);
            
            for (int i = 0; i < cartasIventarioTemp.Count; i++)
            {

                cartasMenu[i].nombre.GetComponent<Text>().text= cartasIventarioTemp[i].nombre;
                cartasMenu[i].tipo.GetComponent<Text>().text = cartasIventarioTemp[i].tipo;
                cartasMenu[i].valor.GetComponent<Text>().text = cartasIventarioTemp[i].valor.ToString();
                cartasMenu[i].imagenCarta.GetComponent<Image>().sprite = cartasIventarioTemp[i].imagenCarta;
                cartasMenu[i].imagenCarta.GetComponent<Image>().enabled = true;
                botonesCartas[i].GetComponent<Button>().interactable = activarCartas;
            }
        }
        else
        {
            Debug.Log("No tienes cartas");
        }

        
    }

}

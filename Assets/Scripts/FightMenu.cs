using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
public class FightMenu : MonoBehaviour
{

    private int fase;
    private GameObject eliminarEnemigo;
    public GameObject _FightMenu;
    private bool fightRun;
    public GameObject _enemigoFight;
    public Player playerTemp;
    public List<Carta> cartasIventarioTemp;
    public Carta[] cartasEnemigoTemp;
    public CartasUI[] cartasMenuJugador;
    public GameObject[] botonesCartas;
    public CartasUI[] cartasEnBatalla;
    public GameObject VistacartasEnBatalla;
    private bool activarCartas = true;
    public Text tipoEnemigo;
    public Text nombreEnemigo;
    public enemigoFight enemigoFightTemp;
    public GameObject buttonIniciarBatalla;
    public GameObject Flechas;
    public GameObject elementoJugador;
    public GameObject elementoEnemigo;
    public Sprite elementoFuego;
    public Sprite elementoAgua;
    public Sprite elementoNieve;
    public GameObject cronometro;
    //Cartas escogidas para batalla
    private Carta CartaEnemiga;
    private CartasUI CartaJugador;
    public GameObject dictadorJugador;
    public GameObject dictadorEnemigo;
    bool primerAtaque = true;
    public GameObject buttonNextRound;


    //Puntajes
    public GameObject puntajeFuegoJugador;
    private int puntajeFuegoJugadorInt;
    public GameObject puntajeAguaJugador;
    private int puntajeAguaJugadorInt;
    public GameObject puntajeNieveJugador;
    private int puntajeNieveJugadorInt;

    public GameObject puntajeFuegoEnemigo;
    private int puntajeFuegoEnemigoInt;
    public GameObject puntajeAguaEnemigo;
    private int puntajeAguaEnemigoInt;
    public GameObject puntajeNieveEnemigo;
    private int puntajeNieveEnemigoInt;

    public GameObject buttonAviso;
    public GameObject textoAviso;
    ///Jugador win
    private string jugadorGano;
    // Update is called once per frame
    private bool winDenifitivaJugador;
    private bool winDefinitivaEnemigo;

    public GameObject canvasWinsORLoss;
    public GameObject winJugador;
    public GameObject lossJugador;
    public GameObject nombreEnemigoWin;
    public GameObject enemigoWin;
    public GameObject nombreEnemigoLoss;
    public GameObject enemigLoss;
    public GameObject cartaRecompensaNombre;
    public GameObject cartaRecompensaTipo;
    public GameObject cartaRecompensaValor;
    public GameObject cartaRecompensaImagen;

    //Fase1.1
    public GameObject slimeP1;
    public GameObject slimeP2;
    public GameObject rocks1;
    //Fin

    //Fase1.2
    public GameObject puentePase;
    public GameObject colliderPuente;
    //Fin

    //Fase1.3 WIN
    public GameObject portal;
   //FIN
    public void FinishFight()
    {
        resetPuntaje();
        _FightMenu.SetActive(false);
        fightRun = false;


    }

    public void RunFight()
    {
        cartasIventarioTemp = playerTemp.obtenerInventario();
        if (cartasIventarioTemp.Any())
        {
           
            primerAtaque = true;
            fightRun = true;
            _FightMenu.SetActive(true);
            ponerCartasEnBatalla();
            Debug.Log("No tienes cartas");
        }
        else
        {
            buttonAviso.SetActive(true);
            textoAviso.GetComponent<Text>().text = "SIN CARTAS";
        }


    }

    public void resetPuntaje()
    {
        puntajeFuegoJugadorInt = 0;
        puntajeAguaJugadorInt = 0;
        puntajeNieveJugadorInt = 0;
        puntajeFuegoEnemigoInt = 0;
        puntajeAguaEnemigoInt = 0;
        puntajeNieveEnemigoInt = 0;

        puntajeFuegoJugador.GetComponent<Text>().text = puntajeFuegoJugadorInt.ToString();
        puntajeAguaJugador.GetComponent<Text>().text = puntajeAguaJugadorInt.ToString();
        puntajeNieveJugador.GetComponent<Text>().text = puntajeNieveJugadorInt.ToString();

        puntajeFuegoEnemigo.GetComponent<Text>().text = puntajeFuegoEnemigoInt.ToString();
        puntajeAguaEnemigo.GetComponent<Text>().text = puntajeAguaEnemigoInt.ToString();
        puntajeNieveEnemigo.GetComponent<Text>().text = puntajeNieveEnemigoInt.ToString();
        winDenifitivaJugador = false;
        winDefinitivaEnemigo = false;
    }

    public bool EstaEnbatalla()
    {
        return fightRun;
    }
    public void QuitarAvisoButto()
    {
        buttonAviso.SetActive(false);

    }

    public void posicionarEnemigo(GameObject enemigo)
    {
        Sprite enemigoSprite = enemigo.GetComponent<SpriteRenderer>().sprite;
        eliminarEnemigo = enemigo;

        _enemigoFight.GetComponent<Image>().sprite = null;
        _enemigoFight.GetComponent<Image>().sprite = enemigoSprite;


        //Asignar lo que trae el enemigo

        //CARTAS ENEMIGO
        _enemigoFight.GetComponent<enemigoFight>().cartasEnemigo = enemigo.GetComponent<Enemigo>().cartasEnemigo;
        //CARTAS RECOPENSA
        _enemigoFight.GetComponent<enemigoFight>().cartasRecompensa = enemigo.GetComponent<Enemigo>().cartasRecompensa;
        //TIPO DE ENEMIGO
        _enemigoFight.GetComponent<enemigoFight>().tipo = enemigo.GetComponent<Enemigo>().tipo;
        _enemigoFight.gameObject.name = enemigo.gameObject.name;


        nombreEnemigo.GetComponent<Text>().text = _enemigoFight.gameObject.name;
        tipoEnemigo.GetComponent<Text>().text = _enemigoFight.GetComponent<enemigoFight>().tipo;

    }



    public void ponerCartasEnBatalla()
    {
        cartasIventarioTemp = playerTemp.obtenerInventario();

        if (cartasIventarioTemp.Any())
        {
            Debug.Log("Si tiene cartas y su primera carta se llama:" + cartasIventarioTemp[0].nombre);



            var numeros = new List<int>();

            //Iteramos hasta que la lista tenga 10 elementos
            while (numeros.Count < cartasIventarioTemp.Count)
            {
                //Recuperamos un número aleatorio entre 0 - 3

                int numeroCartaAleatoria = new System.Random().Next(cartasIventarioTemp.Count);


                //Sólo si el número generado no existe en lalista se agrega
                if (!numeros.Contains(numeroCartaAleatoria))
                {
                    numeros.Add(numeroCartaAleatoria);
                }
            }

            for (int i = 0; i < 3; i++)
            {

                cartasMenuJugador[i].nombre.GetComponent<Text>().text = cartasIventarioTemp[numeros[i]].nombre;
                cartasMenuJugador[i].tipo.GetComponent<Text>().text = cartasIventarioTemp[numeros[i]].tipo;
                cartasMenuJugador[i].valor.GetComponent<Text>().text = cartasIventarioTemp[numeros[i]].valor.ToString();
                cartasMenuJugador[i].imagenCarta.GetComponent<Image>().sprite = cartasIventarioTemp[numeros[i]].imagenCarta;
                cartasMenuJugador[i].imagenCarta.GetComponent<Image>().enabled = true;
                botonesCartas[i].GetComponent<Button>().interactable = activarCartas;
            }
        }
        else
        {
            Debug.Log("No tienes cartas");
        }


    }


    public void SeleccionarCarta(int numeroDeCarta)
    {

        CartaJugador = cartasMenuJugador[numeroDeCarta];
        //CARTA seleccionada de jugador poner en pantalla
        Debug.Log("Nombre de carta seleccionada" + cartasMenuJugador[numeroDeCarta].nombre.GetComponent<Text>().text);
        cartasEnBatalla[0].nombre.GetComponent<Text>().text = cartasMenuJugador[numeroDeCarta].nombre.GetComponent<Text>().text;
        cartasEnBatalla[0].tipo.GetComponent<Text>().text = cartasMenuJugador[numeroDeCarta].tipo.GetComponent<Text>().text;
        cartasEnBatalla[0].valor.GetComponent<Text>().text = cartasMenuJugador[numeroDeCarta].valor.GetComponent<Text>().text;
        cartasEnBatalla[0].imagenCarta.GetComponent<Image>().sprite = cartasMenuJugador[numeroDeCarta].imagenCarta.GetComponent<Image>().sprite;
        VistacartasEnBatalla.SetActive(true);

        DesactivarOActivarCartas(false);
        buttonIniciarBatalla.SetActive(true);
    }

    private void DesactivarOActivarCartas(bool Accion)
    {
        botonesCartas[0].GetComponent<Button>().interactable = Accion;
        botonesCartas[1].GetComponent<Button>().interactable = Accion;
        botonesCartas[2].GetComponent<Button>().interactable = Accion;
    }




    public void IniciarBatalla()
    {
        buttonIniciarBatalla.SetActive(false);
        SeleccionarCartaEnemigo();
        Flechas.SetActive(true);
        GanadorDeRonda();
        elementoJugador.SetActive(true);
        elementoEnemigo.SetActive(true);

        StartCoroutine("ContinuarBatalla");


    }
    IEnumerator ContinuarBatalla()
    {
        cronometro.SetActive(true);
        cronometro.GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1);
        cronometro.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1);
        cronometro.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1);
        cronometro.SetActive(false);

        AsignarColoresDictadores();
        dictadorEnemigo.SetActive(true);
        dictadorJugador.SetActive(true);
        buttonNextRound.SetActive(true);

        actualizarMarcador();

    }

    private void AsignarColoresDictadores()
    {
        if (dictadorJugador.GetComponent<Text>().text.Equals("WIN"))
        {
            dictadorEnemigo.GetComponent<Text>().color = Color.red;
            dictadorJugador.GetComponent<Text>().color = Color.green;
            jugadorGano = "true";
        }
        else if (dictadorJugador.GetComponent<Text>().text.Equals("LOSS"))
        {
            dictadorEnemigo.GetComponent<Text>().color = Color.green;
            dictadorJugador.GetComponent<Text>().color = Color.red;
            jugadorGano = "false";
        }
        else if (dictadorJugador.GetComponent<Text>().text.Equals("EMPATE"))
        {
            dictadorEnemigo.GetComponent<Text>().color = Color.green;
            dictadorJugador.GetComponent<Text>().color = Color.green;
            jugadorGano = "nulo";
        }
    }

    private void actualizarMarcador()
    {
        puntajeFuegoJugador.GetComponent<Text>().text = puntajeFuegoJugadorInt.ToString();
        puntajeAguaJugador.GetComponent<Text>().text = puntajeAguaJugadorInt.ToString();
        puntajeNieveJugador.GetComponent<Text>().text = puntajeNieveJugadorInt.ToString();

        puntajeFuegoEnemigo.GetComponent<Text>().text = puntajeFuegoEnemigoInt.ToString();
        puntajeAguaEnemigo.GetComponent<Text>().text = puntajeAguaEnemigoInt.ToString();
        puntajeNieveEnemigo.GetComponent<Text>().text = puntajeNieveEnemigoInt.ToString();

        //Verificar Win
        VerificarGanador();
        activarWinOrLoss();

    }
   

    ///GANAR O PERDER 
    public void activarWinOrLoss()
    {
      

        if (winDenifitivaJugador)
        {
            
            nombreEnemigoWin.GetComponent<Text>().text = _enemigoFight.gameObject.name;
            enemigoWin.GetComponent<Image>().sprite = _enemigoFight.GetComponent<Image>().sprite;
            canvasWinsORLoss.SetActive(true);
            winJugador.SetActive(true);
            EliminarEnemigo();
            reiniciarUI();
            cerrarBatalla();
            playerTemp.GuardarNombreEnemigo(_enemigoFight.gameObject.name);

            if (_enemigoFight.GetComponent<enemigoFight>().cartasRecompensa.Length != 0)
            {
                //Carta recompensa 
                HayCartaRecompensa(true);
                cartaRecompensaNombre.GetComponent<Text>().text = _enemigoFight.GetComponent<enemigoFight>().cartasRecompensa[0].nombre;
                cartaRecompensaTipo.GetComponent<Text>().text = _enemigoFight.GetComponent<enemigoFight>().cartasRecompensa[0].tipo;
                cartaRecompensaValor.GetComponent<Text>().text = _enemigoFight.GetComponent<enemigoFight>().cartasRecompensa[0].valor.ToString();
                cartaRecompensaImagen.GetComponent<Image>().sprite = _enemigoFight.GetComponent<enemigoFight>().cartasRecompensa[0].imagenCarta;

                //Guardar Carta En inventario
                playerTemp.GuardarCartasEnIventario(_enemigoFight.GetComponent<enemigoFight>().cartasRecompensa);
            }
            else
            {
                HayCartaRecompensa(false);
            }
        }
        else if (winDefinitivaEnemigo)
        {
         
            enemigLoss.GetComponent<Image>().sprite = _enemigoFight.GetComponent<Image>().sprite;
            nombreEnemigoLoss.GetComponent<Text>().text = _enemigoFight.name;
            canvasWinsORLoss.SetActive(true);
            lossJugador.SetActive(true);
          
            reiniciarUI();
            cerrarBatalla();


        }
    }

    //FIN

        public void HayCartaRecompensa(bool cartaRecompensa)
    {
        cartaRecompensaNombre.SetActive(cartaRecompensa);
        cartaRecompensaTipo.SetActive(cartaRecompensa);
        cartaRecompensaValor.SetActive(cartaRecompensa);
        cartaRecompensaImagen.SetActive(cartaRecompensa);
    }
        

    //Eliminar Enemigo INICO
    public void EliminarEnemigo()
    {
        Destroy(eliminarEnemigo);
        FasesJuego();
    }

    //FIN

    public void FasesJuego()
    {

        //Fase #1

        //Fase 1.1
        if(_enemigoFight.name.Equals("Slime Azul"))
        {
            slimeP1.SetActive(true);
            slimeP2.SetActive(true);
            Destroy(rocks1);
        }

        //Fase 1.2
        if (_enemigoFight.name.Equals("Slime Naranja"))
        {
            puentePase.SetActive(true);
            Destroy(colliderPuente);   
        }

        //Fase 1.3 FINAL
        if (_enemigoFight.name.Equals("BOSS BEE"))
        {
            portal.SetActive(true);
        }

    }

    //Boton Continuar en WinOrLoos
    public void ActionPanelWinOrLoos(){
       
        canvasWinsORLoss.SetActive(false);
        lossJugador.SetActive(false);
        winJugador.SetActive(false);     
        FinishFight();
    }

    public void VerificarGanador()
    {

        //Jugador
        if (puntajeFuegoJugadorInt>=3)
        {
            winDenifitivaJugador = true;
        }
        else if (puntajeAguaJugadorInt >= 3)
        {
            winDenifitivaJugador = true;
        }
        else if (puntajeNieveJugadorInt >= 3)
        {
            winDenifitivaJugador = true;
        }
        else if (puntajeNieveJugadorInt >= 1 && puntajeAguaJugadorInt >= 1 && puntajeFuegoJugadorInt >= 1)
        {
            winDenifitivaJugador = true;
        }
        
        //Enemigo
        else if (puntajeFuegoEnemigoInt >= 3)
        {
            winDefinitivaEnemigo = true;
        }
        else if (puntajeAguaEnemigoInt >= 3)
        {
            winDefinitivaEnemigo = true;
        }
        else if (puntajeNieveEnemigoInt >= 3)
        {
            winDefinitivaEnemigo = true;
        }
        else if (puntajeFuegoEnemigoInt >= 1 && puntajeAguaEnemigoInt >= 1 && puntajeNieveEnemigoInt >= 1)
        {
            winDefinitivaEnemigo = true;
        }

    }
    public void AsignarElementosIgual(string tipoCartaJugador)
    {
        if (tipoCartaJugador.Equals("Fuego") && CartaEnemiga.tipo.Equals("Fuego"))
        {
            elementoJugador.GetComponent<Image>().sprite = elementoFuego;
            elementoEnemigo.GetComponent<Image>().sprite = elementoFuego;
        }
        else if (tipoCartaJugador.Equals("Agua") && CartaEnemiga.tipo.Equals("Agua"))
        {
            elementoJugador.GetComponent<Image>().sprite = elementoAgua;
            elementoEnemigo.GetComponent<Image>().sprite = elementoAgua;
        }
        else if (tipoCartaJugador.Equals("Nieve") && CartaEnemiga.tipo.Equals("Nieve"))
        {
            elementoJugador.GetComponent<Image>().sprite = elementoNieve;
            elementoEnemigo.GetComponent<Image>().sprite = elementoNieve;
        }
    }

     public void cerrarBatalla()
    {
        _FightMenu.SetActive(false);
    }
        public void reiniciarUI()
    {
        dictadorEnemigo.SetActive(false);
        dictadorJugador.SetActive(false);
        elementoJugador.SetActive(false);
        elementoEnemigo.SetActive(false);
        Flechas.SetActive(false);
        VistacartasEnBatalla.SetActive(false);
        buttonNextRound.SetActive(false);
        ponerCartasEnBatalla();
        DesactivarOActivarCartas(true);
        cartasEnBatalla[1].imagenCarta.GetComponent<Image>().sprite = null;
    }
   

    public void GanadorDeRonda()
    {
        int valorCartaJugador = Convert.ToInt16(CartaJugador.valor.text);
        string tipoCartaJugador = CartaJugador.tipo.text;
        

        if (tipoCartaJugador.Equals(CartaEnemiga.tipo))
        {
            Debug.Log("ENTRO");
            AsignarElementosIgual(tipoCartaJugador);
            if(valorCartaJugador > CartaEnemiga.valor)
            {

                dictadorJugador.GetComponent<Text>().text = "WIN";
                dictadorEnemigo.GetComponent<Text>().text = "LOSS";
                Debug.Log("Gana jugador por mayor valor de carta");
                playerTemp.puntaje += valorCartaJugador;

                if (tipoCartaJugador.Equals("Nieve"))
                {
                    puntajeNieveJugadorInt += 1;
                }
                else if (tipoCartaJugador.Equals("Fuego"))
                {
                    puntajeFuegoJugadorInt += 1;
                }
                else if (tipoCartaJugador.Equals("Agua"))
                {
                    puntajeAguaJugadorInt += 1;
                }
            }
            else if (CartaEnemiga.valor > valorCartaJugador)
            {
                dictadorJugador.GetComponent<Text>().text = "LOSS";
                dictadorEnemigo.GetComponent<Text>().text = "WIN";
                Debug.Log("Pierde jugador por menor valor de carta");


                if (CartaEnemiga.tipo.Equals("Nieve"))
                {
                    puntajeNieveEnemigoInt += 1;
                }
                else if (CartaEnemiga.tipo.Equals("Fuego"))
                {
                    puntajeFuegoEnemigoInt += 1;
                }
                else if (CartaEnemiga.tipo.Equals("Agua"))
                {
                    puntajeAguaEnemigoInt += 1;
                }
            }
            else if (CartaEnemiga.valor == valorCartaJugador)
            {
                dictadorJugador.GetComponent<Text>().text = "EMPATE";
                dictadorEnemigo.GetComponent<Text>().text = "EMPATE";
                Debug.Log("Empate");

            }
        }
        else
        {
            if(tipoCartaJugador.Equals("Fuego") && CartaEnemiga.tipo.Equals("Agua"))
            {
                elementoJugador.GetComponent<Image>().sprite = elementoFuego;
                elementoEnemigo.GetComponent<Image>().sprite = elementoAgua;

                Debug.Log("Pierde jugador, fuego no gana a el agua");
                puntajeAguaEnemigoInt += 1;
                
                dictadorJugador.GetComponent<Text>().text = "LOSS";
                dictadorEnemigo.GetComponent<Text>().text = "WIN";
            }


            else if (CartaEnemiga.tipo.Equals("Fuego") && tipoCartaJugador.Equals("Agua"))
            {
                elementoEnemigo.GetComponent<Image>().sprite = elementoFuego;
                elementoJugador.GetComponent<Image>().sprite = elementoAgua;

                Debug.Log("Gana jugador, agua si gana a el fuego");
                puntajeAguaJugadorInt += 1;
                dictadorJugador.GetComponent<Text>().text = "WIN";
                dictadorEnemigo.GetComponent<Text>().text = "LOSS";
                playerTemp.puntaje += valorCartaJugador;
            }


            else if (tipoCartaJugador.Equals("Fuego") && CartaEnemiga.tipo.Equals("Nieve"))
            {
                elementoJugador.GetComponent<Image>().sprite = elementoFuego;
                elementoEnemigo.GetComponent<Image>().sprite = elementoNieve;

                Debug.Log("Gana jugador, Fuego si gana a la Nieve");
                puntajeFuegoJugadorInt += 1;
                dictadorJugador.GetComponent<Text>().text = "WIN";
                dictadorEnemigo.GetComponent<Text>().text = "LOSS";
                playerTemp.puntaje += valorCartaJugador;
            }


            else if (CartaEnemiga.tipo.Equals("Fuego") && tipoCartaJugador.Equals("Nieve"))
            {
                elementoJugador.GetComponent<Image>().sprite = elementoNieve;
                elementoEnemigo.GetComponent<Image>().sprite = elementoFuego;

                Debug.Log("Pierde jugador, Nieve no gana a el Fuego");
                puntajeFuegoEnemigoInt += 1;
                dictadorJugador.GetComponent<Text>().text = "LOSS";
                dictadorEnemigo.GetComponent<Text>().text = "WIN";
            }


            else if (tipoCartaJugador.Equals("Agua") && CartaEnemiga.tipo.Equals("Nieve"))
            {
                elementoJugador.GetComponent<Image>().sprite = elementoAgua;
                elementoEnemigo.GetComponent<Image>().sprite = elementoNieve;

                Debug.Log("Pierde jugador, Agua no gana a la Nieve");
                puntajeNieveEnemigoInt += 1;
                dictadorJugador.GetComponent<Text>().text = "LOSS";
                dictadorEnemigo.GetComponent<Text>().text = "WIN";
            }


            else if (CartaEnemiga.tipo.Equals("Agua") && tipoCartaJugador.Equals("Nieve"))
            {
                elementoJugador.GetComponent<Image>().sprite = elementoNieve;
                elementoEnemigo.GetComponent<Image>().sprite = elementoAgua;

                Debug.Log("Gana jugador, Nieve si gana a el Agua");
                puntajeNieveJugadorInt += 1;
                dictadorJugador.GetComponent<Text>().text = "WIN";
                dictadorEnemigo.GetComponent<Text>().text = "LOSS";
                playerTemp.puntaje += valorCartaJugador;
            }

        }


        
    }


    private void ComportamientoEnemigo(int menorA, int mayorA)
    {
        cartasEnemigoTemp = enemigoFightTemp.GetComponent<enemigoFight>().cartasEnemigo;
        int numeroCartaEnemiga = elegirCartaEnemigoPorTipo(menorA, mayorA);
        CartaEnemiga = cartasEnemigoTemp[numeroCartaEnemiga];

        cartasEnBatalla[1].nombre.GetComponent<Text>().text = cartasEnemigoTemp[numeroCartaEnemiga].nombre;
        cartasEnBatalla[1].tipo.GetComponent<Text>().text = cartasEnemigoTemp[numeroCartaEnemiga].tipo;
        cartasEnBatalla[1].valor.GetComponent<Text>().text = cartasEnemigoTemp[numeroCartaEnemiga].valor.ToString();
        cartasEnBatalla[1].imagenCarta.GetComponent<Image>().sprite = cartasEnemigoTemp[numeroCartaEnemiga].imagenCarta;
    }

    public void SeleccionarCartaEnemigo()
    {

        if (primerAtaque)
        {
            ComportamientoEnemigo(10, 100);
            primerAtaque = false;
        }
        else
        {
            if (jugadorGano.Equals("true"))
            {
                ComportamientoEnemigo(90, 100);
            }
            else if (jugadorGano.Equals("false"))
            {
                ComportamientoEnemigo(20, 100);
            }
            else if (jugadorGano.Equals("nulo"))
            {
                ComportamientoEnemigo(50, 100);
            }
            
        }
       

        }

    public int elegirCartaEnemigoPorTipo(int menorA, int mayorA)
    {
        string tipoElemento = _enemigoFight.GetComponent<enemigoFight>().tipo;
       

        //Probabilidad del 20% que sea contrario al elemento, probabilidad del 80% de que sea del mismo elemento del enemigo
        bool elementoIgualprobabilidad= probabilidad(menorA, mayorA);

        bool probabilidadCambioDeCarta = probabilidad(50, 50);

        Debug.Log("Rango:" +cartasEnemigoTemp.Length);

        for (int i = 0; i < cartasEnemigoTemp.Length; i++)
        {
            if (cartasEnemigoTemp[i].tipo.Equals(tipoElemento) && elementoIgualprobabilidad)
            {
                if (probabilidadCambioDeCarta)
                {
                    Debug.Log("CAMBIO DE CARTA");
                    return CambioDeCarta(i, tipoElemento);
                }
                else
                {
                    Debug.Log("NO HUBO CAMBIO DE CARTA");
                    return i;
                }
               
               
            }
            else if (!cartasEnemigoTemp[i].tipo.Equals(tipoElemento)) 
            {
                Debug.Log("Hubo cambio de carta a elemento desigual al enemigo");
                return i;
            }

            

        }

        return 0;

    }



    public bool probabilidad(int menorA, int mayorA)
    {
        bool probabilidad;

        //Probabilidad del 20% que sea contrario al elemento, probabilidad del 80% de que sea del mismo elemento del enemigo
        int probabilidadDeResultado = new System.Random().Next(0,100);
        Debug.Log("Probabilidad es:" + probabilidadDeResultado);

        if (probabilidadDeResultado > mayorA)
        {
            return probabilidad = true;
        }
        else if (probabilidadDeResultado <= menorA)
        {
            return probabilidad = false;
        }

        return true;
    }

    public int CambioDeCarta(int cartaExepcion, string tipoElemento)
    {

        for (int i = 0; i < cartasEnemigoTemp.Length; i++)
        {
            if (cartasEnemigoTemp[i].tipo.Equals(tipoElemento) && i != cartaExepcion)
            {
                return i;
            }
        }
        return cartaExepcion;
    }








}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 input;
    public float speed;
    private Animator _animator;
    public FightMenu fight;
    private bool fightRun;
    private GameObject enemigoTem;
    private GameObject cofreTem;
    private ContenidoCofre contenidoCofre;
    public List<Carta> cartasIventario;
    private GameObject mensajeTem;
    public Carta[] cartasIventarioTem;
    private bool tocandoCofre;
    private bool tocandoPortal;
    public GameObject NuevasCartas;
    public int puntaje;
    public List<string> enemigosEliminados;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
  
    }



    // Start is called before the first frame update
    void Start()
    {
        GameManager.instancia.RestaurarPuntaje();
        List<Carta> cartasIventarioT = new List<Carta>();
        cartasIventario = cartasIventarioT;
        List<string> enemigosEliminados = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2();
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        input.Normalize();
        if(input != Vector2.zero && !fightRun)
        {
            _animator.SetFloat("Movimiento X", input.x);
            _animator.SetFloat("Movimiento Y", input.y);
            _animator.SetBool("EnMovimiento", true);
        }
        else
        {
            _animator.SetBool("EnMovimiento", false);
        }
       
            if (Input.GetKeyDown(KeyCode.E) && tocandoCofre)
        {
            
            if (!contenidoCofre.cofreEstaAbierto)
            {
                
                AgarrarContenido();
                cofreTem.GetComponent<MensajesEmergentes>().mensajeEliminado = true;
                cofreTem.GetComponent<MensajesEmergentes>().mensaje.SetActive(false);
              
                Debug.Log("Objetos Cogidos del cofre");

            }
        }

        if (Input.GetKeyDown(KeyCode.E) && tocandoPortal)
        {
            Win();


        }


        }

    public void Win()
    {
        try
        {
            GameManager.instancia.CambiarEscena("Escena Ganar");
            GameManager.instancia.SumarPunataje(puntaje);
            GameManager.instancia.SetEnemigosEliminados(enemigosEliminados);
            GameManager.instancia.SetBaraja(cartasIventario);

        }
        catch (System.Exception ex)
        {
            Debug.Log("Se te olvido poner el game manager en la escena!");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        

        if (other.collider.CompareTag("Enemigo") && !fight.EstaEnbatalla())
        {
            fight.RunFight();
            enemigoTem = other.collider.gameObject;

            Debug.Log("Toco un enemigo" + enemigoTem.name);
            fight.posicionarEnemigo(enemigoTem);
           
        }


    }
    private void OnCollisionStay2D(Collision2D other)
    {
       
        if (other.collider.CompareTag("Cofre"))
        {
            cofreTem = other.collider.gameObject;
            contenidoCofre = cofreTem.GetComponent<ContenidoCofre>();
            if (!contenidoCofre.cofreEstaAbierto)
            {
                cartasIventarioTem = cofreTem.GetComponent<ContenidoCofre>().cartasEnCofre;
    
              
              
            }
          
            tocandoCofre = true;

        }

        else if (other.collider.CompareTag("Portal Win"))
        {
            tocandoPortal = true;

            
        }
    }

  
    public void FixedUpdate()
    {
        if (!fightRun)
        {
            rb.velocity = input * speed * Time.fixedDeltaTime;
        }
        
    }

    public void AgarrarContenido()
    {
        contenidoCofre.GetComponent<SpriteRenderer>().sprite = contenidoCofre.cofreAbiertoImagen;
        contenidoCofre.cofreHaSidoAbierto();
        Debug.Log("Cofre Ha Sido Abierto");

        GuardarCartasEnIventario(cartasIventarioTem);

    }

    public void GuardarCartasEnIventario(Carta[] cartasRecompensa)
    {

        for (int i = 0; i < cartasRecompensa.Length; i++)
        {

            cartasIventario.Add(cartasRecompensa[i]);
        }

        Debug.Log("Guardado con Exito:"+ cartasIventario[1].nombre);
        NuevasCartas.SetActive(true);
    }

   

    public List<Carta> obtenerInventario()
    {
        return cartasIventario;
            
    }

    public void GuardarNombreEnemigo(string nameEnemigoEliminado) {




        enemigosEliminados.Add(nameEnemigoEliminado);
                Debug.Log("Nombre ENEMIGO guardado con exito" + nameEnemigoEliminado);
       
           

    }




}

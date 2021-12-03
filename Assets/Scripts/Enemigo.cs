using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public float speed = 1f;
    public float minX=0;
    public float maxX=0;
    public float minY=0;
    public float maxY=0;
    public float waitingTime = 2f;
    public bool movimientoArriba;
    public bool movimientoLados;
    public string tipo;
    public Carta[] cartasEnemigo;
    public Carta[] cartasRecompensa;
    private Animator _animator;
    private GameObject _target;
    
    // Start is called before the first frame update

     void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        UpdateTransform();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void UpdateTransform()
    {

        if (movimientoLados)
        {
            if (_target == null)
            {
                _target = new GameObject("Target");
                _target.transform.position = new Vector2(minX, transform.position.y);

                return;
            }


            if (_target.transform.position.x == minX)
            {
                _target.transform.position = new Vector2(maxX, transform.position.y);

            }
            else if (_target.transform.position.x == maxX)
            {
                _target.transform.position = new Vector2(minX, transform.position.y);

            }
        }
        if (movimientoArriba)
        {
            if (_target == null)
            {
                _target = new GameObject("Target");
                _target.transform.position = new Vector2(transform.position.x, minY);

                return;
            }


            if (_target.transform.position.y == minY)
            {
                _target.transform.position = new Vector2( transform.position.x, maxY);

            }
            else if (_target.transform.position.y == maxY)
            {
                _target.transform.position = new Vector2( transform.position.x, minY);

            }
        }



    }

    IEnumerator PatrolToTarget()
    {
     
            while (Vector2.Distance(transform.position, _target.transform.position) > 0.01f)
            {

                //Caminar
                
                _animator.SetBool("idle", false);


                Vector2 direction = _target.transform.position - transform.position;
                float xDirection = direction.x;
                float YDirection = direction.y;

                transform.Translate(direction.normalized * speed * Time.deltaTime);


                yield return null;


            }
       

      
        if (movimientoArriba)
        {
            transform.position = new Vector2(transform.position.x ,_target.transform.position.y);
        }
        if (movimientoLados)
        {
            transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        }
      

        //Para de caminar
        _animator.SetBool("idle", true);
        yield return new WaitForSeconds(waitingTime);

        //Vuelve hacer el siglo
        UpdateTransform();
        StartCoroutine("PatrolToTarget");

    }

}

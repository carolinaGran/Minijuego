using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    private void Awake()
    {
        instance = this;
    }
    //velocidad del enemigo
    public float moveSpeed;
    //los puntos entre los que se movera el enemigo
    public Transform leftPoint, rightPoint;
    private bool movingRight;//se mueve a la derecha?
    private Rigidbody2D theRB;//cuerpo rigido del enemygo
    public SpriteRenderer theSR;//para poder girar el cuerpo 
    // tiempo de movimiento, tiempo de espera
   public float moveTime, waitTime;
    //cuenta del movimiento y espera
    private float moveCount, waitCount;
    public Animator anim;

    //tutorial Joexscript
   /* public int rutina;
    public float cronometro;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;
    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;//detectar el jugador
    public GameObject Hit;//Mensaje de daño*/
    /* public void Comportamientos()
     {
        //anim.SetBool("run", false);
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando)
        {
           
            if (moveCount > 0)
            {
                moveCount -= Time.deltaTime;
                if (movingRight)
                {
                     //theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                     transform.localScale= new Vector2(transform.localScale.x * 1, transform.localScale.y);
                    //theSR.flipX = false;
                    //transform.rotation = Quaternion.Eulier(0, 0, 0);
                    //transform.Translate(Vector3.right * speed_walk * Time.deltaTime);

                    if (transform.position.x > rightPoint.position.x)
                    {
                        movingRight = false;
                    }
                }
                else
                {
                    /*theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                    theSR.flipX = true;
                    // tranform.rotation = Quaternion.Eulier(0, 180, 0);
                    //transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                    transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);

                    if (transform.position.x < leftPoint.position.x)
                    {
                        movingRight = true;
                    }
                }
                if (moveCount <= 0)
                {
                    waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
                }
                anim.SetBool("isMoving", true);
            }

            else if (waitCount > 0)
            {
                waitCount -= Time.deltaTime;

                theRB.velocity = new Vector2(0f, theRB.velocity.y);
                if (waitCount <= 0)
                {
                    moveCount = Random.Range(moveCount * .75f, waitTime * 1.25f);

                }
                anim.SetBool("isMoving", false);
            }
        }
        
        
        
    }
    public void Final_Ani()
    {
        anim.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;

    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }*/
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

       // target = GameObject.Find("Player");

        leftPoint.parent = null;
        rightPoint.parent = null;

       movingRight = true;
        moveCount = moveTime;

    }

    // Update is called once per frame
    void Update()
    {
        //Comportamientos();
       if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                theSR.flipX = false;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                theSR.flipX = true;
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        }
      
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;

            theRB.velocity = new Vector2(0f, theRB.velocity.y);
            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveCount * .75f, waitTime * 1.25f);

            }
            anim.SetBool("isMoving", false);
        }
      
    }

}

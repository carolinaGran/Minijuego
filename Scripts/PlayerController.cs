using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public void Awake()
    {
        instance = this;

    }
    [Header("Movimiento")]
    //velocidad de movimiento
    public float moveSpeed;

    [Header("Salto")]
    //fuerza de salto
    public float jumpForce;
    //comprobar si se puede dar doble salto
    private bool canDoubleJump;
    //para detectar el suelo, y evitar saltodemasiado libre
    [Header("Grounded")]
    //punto del personaje que toca el suelo 
    public Transform groundCheckPoint;
    //layer si es suelo
    public LayerMask whatIsGround;
    //var boolean isGrounded
    private bool isGrounded;

    [Header("Componentes")]
    //acceso al cuerpo rigido
    public Rigidbody2D theRB;
    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer theSR;

    [Header("Combat")]
    public int combo;
    public bool atacando;
    public AudioSource audio_S;
    public AudioClip[] sonido;
    public bool accion;
    public bool airAttack;

    //booleano para que el jugador no se pueda mover cuando finalice el nivel
    public bool stopInput;
    //fuerza y duracion del knockback
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        audio_S = GetComponent<AudioSource>();

    }
    //temporizador de finalización de combate
    IEnumerator Cronometro()
    {
        yield return new WaitForSeconds(.1f);
        accion = false;
    }
    public void PlayON()
    {
        StartCoroutine(Cronometro());
    }
    //combate
    public void Combos()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !atacando && isGrounded)
        {
            atacando = true;
            accion = true;
            anim.SetTrigger("" + combo);
            audio_S.clip = sonido[combo];
            audio_S.Play();
            Debug.Log("Golpe");
        }
    }
    public void Start_Combo()
    {
        atacando = false;
        if(combo < 3)
        {
            combo++;
        }
        
    }
    public void Finish_Ani()
    {
        //atacando = false;

        if (combo == 1)
        {
            combo = 2;
            atacando = false;
        }
        if (combo == 2)
        {
            combo = 0;
            atacando = false;
        }

        PlayON();
    }
    public void Golpe_aereo()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !atacando && !isGrounded)
        {
            airAttack = true;
            anim.SetTrigger("air");
            audio_S.clip = sonido[combo];
            audio_S.Play();
            
        }
    }
    public void Final_Air()
    {
        airAttack = false;
        atacando = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.isPaused && !stopInput)
        {
           
            Combos();
       // Golpe_aereo();
        if(knockBackCounter <= 0) {
            atacando = false;
            airAttack = false;
            //con el movimiento se declara un vector de eje x e y 
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
            
            

            if (isGrounded)
        {//si estamos en el suelo si se puede hacer doble salto
            canDoubleJump = true;
                //airAttack = false;
                

            }
            //if (Input.GetButtonDown("Jump") && !accion && !atacando)
            //al apretar jump desencadena las acciones dentro del condicional if
            if (Input.GetButtonDown("Jump") && !atacando)

            {
                //se realiza la llamada a la función "PlaySFX()" para activar el efecto sonoro al saltar
                AudioManager.instance.PlaySFX(10);

                

                combo = 0;
                //solo se podrá realizar el doble salto si previamente se ha pisado el suelo
                if (isGrounded)
                {
                    //se multiplica el eje "y" por la variable int para que el jugador realice el salto
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                else
                {
                        //este condicional se encarga de la lógica del doble salto
                    if (canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(10);
                        //una vez ejercido el doble salto se da false al booleano canDobleJump para evitar más saltos
                        canDoubleJump = false;
                    }
                }
        }
          /* if (theRB.velocity.x < 0)
            {
                //   theSR.flipX = true;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (theRB.velocity.x > 0)
            {
                // theSR.flipX = false;
                transform.localScale = new Vector3(1, 1, 1);
            }*/
            if (theRB.velocity.x < 0)
           {
               theSR.flipX = true;
           }
           else if (theRB.velocity.x > 0)
           {
               theSR.flipX = false;
           }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            //se desplaza brevement a un lado el jugador cuando se daña
             if (!theSR.flipX)
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
               
            }
            else
            {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
             
            }
        }
        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
    public void Knockback()
    {
        knockBackCounter = knockBackLength;
        //permiteque haya un efecto de contraste en el momento de pasar a la transparencia cuando sufre un daño
        theRB.velocity = new Vector2(0f, knockBackForce);
    }
}

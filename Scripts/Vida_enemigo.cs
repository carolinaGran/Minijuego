using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_enemigo : MonoBehaviour
{
    public static Vida_enemigo instance;
    //la vida que tenemos y el maximo de vida que podemos tener
    public int currentHealthEn, maxHealthEn;
    //tiempo de insensibilidad al daño
    public float invicibleLengthEn;
    //cuenta atras
    private float invicibleCounterEn;
    //var que hara visible el tiempo de insensibilidad con transparencia
   private SpriteRenderer theSRen;
    private Animator anim;
    public GameObject deathEffectEn;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealthEn = maxHealthEn;
        theSRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
       /* if (invicibleCounterEn > 0)
        {
            invicibleCounterEn -= Time.deltaTime;
            if (invicibleCounterEn <= 0)
            {
                theSRen.color = new Color(theSRen.color.r, theSRen.color.g, theSRen.color.b, 1f);
            }
        }*/

    }
    //funcion que llamaremos siempre que queramos hacer daño
      public void DealDamageEn()
      {
         // if (invicibleCounterEn <= 0)
          //{
              //reduce una vida
              currentHealthEn--;
          //EnemyController.instance.anim.SetTrigger("hurt");

          // anim.Play("Hit");
          //si son 0 o menos de 0 desaparece el jugador
          if (currentHealthEn <= 0)
              {
              //if (deathEffectEn != null)
              //{
                 deathEffectEn.SetActive(true);
                  theSRen.enabled = false;
                  Invoke("EnemyDie", 0.2f);
                  AudioManager.instance.PlaySFX(3);
              //}
              //  currentHealthEn = 0;
              //Instantiate(deathEffectEn, EnemyController.instance.transform.position, EnemyController.instance.transform.rotation);
              //  PlayerController.instance.anim.SetTrigger("Death");

            //  gameObject.SetActive(false); //en vez de hacerlo desparecer llamaremos
              //  deathEffectEn.SetActive(false);
              //a la funcion RespawnPlayer
              //LevelManager.instance.RespawnPlayer();
          }
              else
              {
             EnemyController.instance.anim.SetTrigger("hurt");

              // invicibleCounterEn = invicibleLengthEn;
              // theSRen.color = new Color(theSRen.color.r, theSRen.color.g, theSRen.color.b, .5f);
              // PlayerController.instance.Knockback();
          }
              //UIController.instance.UpdateHealthDisplay();



      }
     public void EnemyDie()
      {
        // deathEffectEn.SetActive(true);
        //gameObject.SetActive(false);
        Destroy(gameObject);
      }

}

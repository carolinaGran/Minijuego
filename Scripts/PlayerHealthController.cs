using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    //la vida que tenemos y el maximo de vida que podemos tener
    public int currentHealth, maxHealth;
    //tiempo de insensibilidad al daño
    public float invicibleLength;
    //cuenta atras
    private float invicibleCounter;
    //var que hara visible el tiempo de insensibilidad con transparencia
    private SpriteRenderer theSR;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
       if (invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime;
            if (invicibleCounter <= 0)
            {
               theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }

    }
    //funcion que llamaremos siempre que queramos hacer daño
    public void DealDamage()
    {
        if (invicibleCounter <= 0)
        {
            //reduce una vida
            currentHealth--;
            PlayerController.instance.anim.SetTrigger("Hurt");
            AudioManager.instance.PlaySFX(9);
            //si son 0 o menos de 0 desaparece el jugador
            if (currentHealth <= 0)
            {
                //currentHealth = 0;
                Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
                AudioManager.instance.PlaySFX(8);
                //  PlayerController.instance.anim.SetTrigger("Death");

                // gameObject.SetActive(false); //en vez de hacerlo desparecer llamaremos
                //a la funcion RespawnPlayer
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invicibleCounter = invicibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
                PlayerController.instance.Knockback();
            }
            UIController.instance.UpdateHealthDisplay();

        }

    }
    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}

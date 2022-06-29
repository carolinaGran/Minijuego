using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    // public int damage;
     public GameObject deathEffect;
    // public int currentHealthEn, maxHealthEn;
    // public GameObject deathEffect;

    public SpriteRenderer SR;
    private BoxCollider2D coll;
    public Animator anim;
    //public Rigidbody2D theRB;
    //public GameObject swordParent;
    [Range(0,100)]
    public float chanceToDrop;
    public GameObject collectible;
    // Start is called before the first frame update
    void Start()
    {
        SR = transform.root.GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if(SR.flipX== true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }


    public void Attack()
    {
        anim.Play("attack");
        coll.enabled = true;
        Invoke("DisableAttack", 0.5f);
    }
    private void DisableAttack()
    {
        coll.enabled = false;
    }
   public void OnTriggerEnter2D(Collider2D coll)
    {

        //vidaLimiteEn = coll.GetComponent<Vida_enemigo>().Vida;
        if (coll.tag == "Enemigo")
        {
            //coll.transform.parent.gameObject.SetActive(true);
            Vida_enemigo.instance.DealDamageEn();
          
           // Instantiate(deathEffect, coll.transform.position, coll.transform.rotation);

            float dropSelect = Random.Range(0, 100f);
            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, coll.transform.position, coll.transform.rotation);
               
            }
          
        }
    }
}

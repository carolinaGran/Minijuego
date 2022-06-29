using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo : MonoBehaviour
{
   // public GameObject deathEffectEn;

    private void OnTriggerEnter2D(Collider2D other)//coge el colider de otro objeto
    {
        if (other.tag == "Player")
        {
            //solo anuncia que es dañado
            //Debug.Log("Hit");
            //quitar vidas
            PlayerHealthController.instance.DealDamage();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

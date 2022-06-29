using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}

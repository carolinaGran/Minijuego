using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)//coge el colider de otro objeto
    {
        if (other.tag == "Player")
        {
            LevelManager.instance.EndLevel();
         
           
        }
    }
}

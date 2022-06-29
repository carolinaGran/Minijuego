using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LevelManager.instance.RespawnPlayer();
        }
    }
}

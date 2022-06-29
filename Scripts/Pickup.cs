using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal;
    private bool isCollected;
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                UIController.instance.UpdateGemCount();
                Instantiate(pickupEffect, transform.position, transform.rotation);

                isCollected = true;
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(0);
            }
            if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
            {
                PlayerHealthController.instance.HealPlayer();
                isCollected = true;
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(7);
            }
        }
    }
}
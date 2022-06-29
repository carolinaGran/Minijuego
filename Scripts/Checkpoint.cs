using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class Checkpoint : MonoBehaviour
{
    //objeto en Hierachy
    public SpriteRenderer theSR;
    //acceso a nuestros sprites(imagenes de la carpeta)
    public Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckpointController.instance.DeactiveCheckpoints();
            theSR.sprite = cpOn;

           CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    public Checkpoint[] checkpoints;
    //guardar coordenadas del spawnPoint
    public Vector3 spawnPoint;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //encontrar todos los objetos tipo checkpoint
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    public void DeactiveCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}

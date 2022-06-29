using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime);  
    }
}

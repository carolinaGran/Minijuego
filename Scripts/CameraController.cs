using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TFG
public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public void Awake()
    {
        instance = this;

    }
    //objeto que seguira la camara(Player)
    public Transform target;
    //prueba efecto paralax
    public Transform bg;
    //min y max que se puede mover la camara en el eje y
    public float minHeight, maxHeight;
    //pos de x e y
    private Vector2 lastPos;
    //para que pare de seguir al jugador cuando se da con la bandera
    public bool stopFollow;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopFollow)
        {
            //camara que sigue solo el eje x
            //transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
            bg.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

            lastPos = transform.position;
        }

    }
}

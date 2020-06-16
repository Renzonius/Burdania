using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomahawkLogic : MonoBehaviour
{
    public float vel_tomahawk;
    Rigidbody rb_tomahawk;
    public float alcanse;
    //private Transform contrincanteTransformRef;
    GameObject jugadorRef;
    BoxCollider colliderRef;
    bool choque;
    float vel_giro = 950f;
    private void Awake()
    {
        colliderRef = gameObject.GetComponent<BoxCollider>();
        rb_tomahawk = GetComponent<Rigidbody>();
        //contrincanteTransformRef = GameObject.FindGameObjectWithTag("Enemigo").transform;
        jugadorRef = GameObject.FindGameObjectWithTag("Jugador");
    }
    void Start()
    {
        rb_tomahawk.AddRelativeForce(Vector3.forward * 500f * Time.deltaTime, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Jugador" )
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Muro")
        {
            rb_tomahawk.velocity = Vector3.zero;
            colliderRef.enabled = false;
            choque = true;
        }
    }


    void FixedUpdate()
    {
        GiroTomahawk(choque);
        Destroy(gameObject, alcanse);
    }

    void GiroTomahawk(bool choque)
    {
        if(choque == false)
        {
            transform.Rotate(vel_giro * Time.deltaTime, 0f, 0f);
        }
    }
}

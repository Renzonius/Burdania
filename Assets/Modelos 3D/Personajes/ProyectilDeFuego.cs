using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilDeFuego : MonoBehaviour
{
    Rigidbody rbFuego;
    BoxCollider colliderRef;
    public float velocidad;
    public float alcanse;
    bool choque;
    JugadorLogic jugadorRef;
    //public float daño;
    private void Awake()
    {
        colliderRef = gameObject.GetComponent<BoxCollider>();
        rbFuego = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        jugadorRef = GameObject.FindGameObjectWithTag("Jugador").GetComponent<JugadorLogic>();
        //daño = jugadorRef.vida * 25 / 100;
        rbFuego.AddRelativeForce(Vector3.forward * velocidad * Time.deltaTime, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        Destroy(gameObject, alcanse);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Muro")
        {
            rbFuego.velocity = Vector3.zero;
            colliderRef.enabled = false;
            choque = true;
        }
    }

}

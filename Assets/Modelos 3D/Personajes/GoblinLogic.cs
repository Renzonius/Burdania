using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinLogic : MonoBehaviour
{
    Animator anim;
    GameObject jugador;
    float vel_rotacion;
    float vel_movimiento;
    Rigidbody rigidRef;
    CapsuleCollider colliderRef;

    public GameObject piezaDeFlecha;
    SpawnsLogic spawn;

    public float daño;

    bool muerto;
    bool movimiento = true;
    public bool tienePieza;
    private void Start()
    {
        daño = 25f;
        rigidRef = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Jugador");
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnsLogic>();
        vel_rotacion = 6f;
        vel_movimiento = Random.Range(3, 5);
        colliderRef = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        if(muerto == false)
        {
            MirarJugador();
            if (movimiento)
                Perseguir();
        }
    }

    void MirarJugador()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
         Quaternion.LookRotation(jugador.transform.position - transform.position), vel_rotacion * Time.deltaTime);
    }
    void Perseguir()
    {
        transform.position += transform.forward * vel_movimiento * Time.deltaTime;
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            anim.SetBool("Ataque", true);
            movimiento = false;
        }
        else
        {
            anim.SetBool("Ataque", false);
            movimiento = true;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Lanza")
        {
            anim.Play("Muerto");
            muerto = true;
            rigidRef.useGravity = false;
            colliderRef.enabled = false;
            if(tienePieza == true)
            {
                Instantiate(piezaDeFlecha, transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            }
            Destroy(gameObject, 7);
        }
    }

    void AumentarTamaño()
    {
        if(tienePieza == true)
        {
            Vector3 escalaOriginal = gameObject.transform.localScale;
            gameObject.transform.localScale = escalaOriginal * 5;
        }
    }

}

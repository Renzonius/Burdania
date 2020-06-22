using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallestaLogic : MonoBehaviour
{
    public int CantidadProyectil;
    Animator anim;
    Transform spawn;
    public GameObject proyectil;
    GameObject dragonObjetivo;

    GameObject jugadorRef;
    int cantidadDePiezasJugador;
    public ParticleSystem señalParticulas;

    float vel_rotacion = 3F;
    public bool jugadorCerca;

    AudioSource efectoDeSonido;

    private void Start()
    {
        efectoDeSonido = GetComponent<AudioSource>();
        cantidadDePiezasJugador = GameObject.FindGameObjectWithTag("Jugador").GetComponent<JugadorLogic>().pienzas;
        jugadorRef = GameObject.FindGameObjectWithTag("Jugador");
        anim = GetComponent<Animator>();
        spawn = GameObject.FindGameObjectWithTag("SpawnBallesta").transform;
        dragonObjetivo = GameObject.FindGameObjectWithTag("Dragon");
    }
    void Update()
    {
        if(jugadorCerca == true)
        {
            Apuntar();
        }
        SeñalBallestaLista();
    }

    public void DispararProyectil()
    {
        anim.Play("Disparo");
        efectoDeSonido.Play();
        if (CantidadProyectil > 0)
        {
            CantidadProyectil -= 1;
            Instantiate(proyectil, spawn.position, spawn.rotation);
        }
    }



    void Apuntar()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
         Quaternion.LookRotation(dragonObjetivo.transform.position - transform.position), vel_rotacion * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            jugadorCerca = true;
            if (jugadorRef.GetComponent<JugadorLogic>().pienzas >= 3 && jugadorCerca == true)
            {
                cantidadDePiezasJugador = 0;
                CantidadProyectil = 1;
                jugadorRef.GetComponent<JugadorLogic>().pienzas = 0;
            }
        }
        else
        {
            jugadorCerca = false;
        }
    }

    void SeñalBallestaLista()
    {
        if(jugadorRef.GetComponent<JugadorLogic>().pienzas >= 3 || CantidadProyectil ==1)
        {
            señalParticulas.Play();
        }
        else
        {
            señalParticulas.Stop();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            jugadorCerca = false;
        }
    }
}

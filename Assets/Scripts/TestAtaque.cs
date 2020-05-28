using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAtaque : MonoBehaviour
{
    // Update is called once per frame
    public Animator animeBarb;
    public Animator animeToscal;
    public Animator animeVallena;
    public Animator animeNene;
    private SelectorPersonaje personaje;
    public Transform PuntoAtaque;
    public float rango = 0.5f;
    public LayerMask Enemigo;
    public int daño = 1;
    void Start()
    {
        personaje = GameObject.Find("ContenedorVariables").GetComponent<SelectorPersonaje>();
    }
    public void Atacar() // el overlapsphere chequea que esta colisionando y para evitar problemas con el terreno le puse el layer de enemigo que pasa a una matriz de colisiones y por cada enemigo que golpee activa el recibir daño
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (personaje.seleccionoUno == true)
            {
                animeBarb.SetTrigger("ATAQE"); // esto es porque el animador para pasar de cualquier estado al ataque tiene un trigger, que se activa aca.
                Collider[] golpe = Physics.OverlapSphere(PuntoAtaque.position, rango, Enemigo);
                foreach (Collider enemigo in golpe)
                {
                  enemigo.GetComponent<AtributosEnemigo>().RecibirDaño(daño);
                   
                }
            }
            if (personaje.seleccionoDos == true) //este desproposito sirve para que cada personaje tenga su propio set de animaciones sin joder al resto.
            {
                animeToscal.SetTrigger("ATAQE");
                Collider[] golpe = Physics.OverlapSphere(PuntoAtaque.position, rango, Enemigo);
                foreach (Collider enemigo in golpe)
                {
                    enemigo.GetComponent<AtributosEnemigo>().RecibirDaño(daño);
                }
            }
            if (personaje.seleccionoTres == true)
            {
                animeVallena.SetTrigger("ATAQE");
                Collider[] golpe = Physics.OverlapSphere(PuntoAtaque.position, rango, Enemigo);
                foreach (Collider enemigo in golpe)
                {
                    enemigo.GetComponent<AtributosEnemigo>().RecibirDaño(daño);
                }
            }
            if (personaje.seleccionoCuatro == true)
            {
                animeNene.SetTrigger("ATAQE");
                Collider[] golpe = Physics.OverlapSphere(PuntoAtaque.position, rango, Enemigo);
                foreach (Collider enemigo in golpe)
                {
                    enemigo.GetComponent<AtributosEnemigo>().RecibirDaño(daño);
                }

            }

        }
    }

    
    private void OnDrawGizmosSelected() //esto solo esta para poder ver la esfera que es el "rango" de ataque
    {
        Gizmos.DrawWireSphere(PuntoAtaque.position, rango);
    }
}

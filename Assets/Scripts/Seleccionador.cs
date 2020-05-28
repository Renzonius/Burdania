using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccionador : MonoBehaviour
{
    private SelectorPersonaje elNombre;

    public GameObject barb;
    public GameObject toscal;
    public GameObject valena;
    public GameObject cruzado;

    public GameObject enemigoBarb;
    public GameObject enemigoToscal;
    public GameObject enemigoValena;
    public GameObject enemigoCruzado;

    // Start is called before the first frame update
    void Start()
    {
        elNombre = GameObject.Find("ContenedorVariables").GetComponent<SelectorPersonaje>(); //ya se que elNombre no dice absolutamente nada, pero hace referencia a que es el selector de personajes y no queria repetirlo
        SelectorUno();
        SelectorDos();
        SelectorTres();
        SelectorCuatro();

    }
    public void SelectorUno()
    {
        if (elNombre.seleccionoUno == true) //si toco el primer boton en la pantalla de seleccion se activa esto y se desactiva los enemigos y otros personajes en esta escena(probe borrandolos en vez de desactivar y hubieron problemas con la camara y colisiones asi que hay que ver cosas por ahi)
        {
            
            barb.SetActive(true);
            toscal.SetActive(false);
            valena.SetActive(false);
            cruzado.SetActive(false);

            enemigoBarb.SetActive(false);
            enemigoToscal.SetActive(true);
            enemigoValena.SetActive(false);
            enemigoCruzado.SetActive(false);
        }
    }
    public void SelectorDos()
    {
        if (elNombre.seleccionoDos == true)
        {
            
            barb.SetActive(false);
            toscal.SetActive(true);
            valena.SetActive(false);
            cruzado.SetActive(false);

            enemigoBarb.SetActive(false);
            enemigoToscal.SetActive(false);
            enemigoValena.SetActive(true);
            enemigoCruzado.SetActive(false);
        }
    }
    public void SelectorTres()
    {
        if (elNombre.seleccionoTres == true)
        {
           
            barb.SetActive(false);
            toscal.SetActive(false);
            valena.SetActive(true);
            cruzado.SetActive(false);

            enemigoBarb.SetActive(false);
            enemigoToscal.SetActive(false);
            enemigoValena.SetActive(false);
            enemigoCruzado.SetActive(true);
        }
    }
    public void SelectorCuatro()
    {
        if (elNombre.seleccionoCuatro == true)
        {
            
            barb.SetActive(false);
            toscal.SetActive(false);
            valena.SetActive(false);
            cruzado.SetActive(true);

            enemigoBarb.SetActive(true);
            enemigoToscal.SetActive(false);
            enemigoValena.SetActive(false);
            enemigoCruzado.SetActive(false);
        }
    }
}
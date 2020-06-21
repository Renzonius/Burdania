using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorFondo : MonoBehaviour
{
    public GameObject dialogo;
    public GameObject fondo;
    public GameObject fondoOscuro;
    public GameObject imagenToscal;
    public GameObject imagenBarb;
    public GameObject imagenValena;
    public GameObject imagenOmel;
    public GameObject activador;
    public GameObject boton;
    public GameObject manager;
    public GameObject textoHablar;
    public GameObject barbActivador;
    public GameObject toscalActivador;
    public GameObject omelActivador;
    public GameObject valenaActivador;
    public bool activoDialogo = false;
    
    // Update is called once per frame
    void Update()
    {
        if (activoDialogo == true) //esto es un puto caos pero lo importante es que cuando te acercas a collider del enemigo el "activoDialogo" se pone en true y pone el fondo,el texto,la imagen,desactive los movimientos del jugador y mande el true al activador del dialogo
        {
            dialogo.SetActive(true);
            fondo.SetActive(true);
            boton.SetActive(true);
            if (toscalActivador.GetComponent<ToscalTexto>().hablarConToscal == true)
                imagenToscal.SetActive(true);
            else if (barbActivador.GetComponent<BarbTexto>().hablarConBarb == true)
                imagenBarb.SetActive(true);
            else if (omelActivador.GetComponent<OmelTexto>().hablarConOmel == true)
                imagenOmel.SetActive(true);
            else if (valenaActivador.GetComponent<ValenaTexto>().hablarConValena == true)
                imagenValena.SetActive(true);
            fondoOscuro.SetActive(true);
            activador.GetComponent<JugadorLogic>().BoquearMovimiento();
            manager.GetComponent<CreadorTexto>().ChequearHablando();
        }
        else //esto los desactiva una vez terminan las oraciones del manager
        {
            dialogo.SetActive(false);
            fondo.SetActive(false);
            boton.SetActive(false);
            imagenBarb.SetActive(false);
            imagenToscal.SetActive(false);
            imagenOmel.SetActive(false);
            imagenValena.SetActive(false);
            fondoOscuro.SetActive(false);
            activador.GetComponent<JugadorLogic>().HabilitarMovimiento();
            manager.GetComponent<CreadorTexto>().NoEstaHablando();
        }
    }
    public void ActivarDialogo()
    {
        activoDialogo = true;
    }
    public void DesactivarDialogo()
    {
        activoDialogo = false;
    }
   
}


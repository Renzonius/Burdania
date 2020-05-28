using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRUEBA : MonoBehaviour
{
    public GameObject dialogo;
    public GameObject fondo;
    public GameObject fondoOscuro;
    public GameObject imagen;
    public GameObject activador;
    public GameObject boton;
    public GameObject manager;
    public GameObject cerebro;
    public bool activoDialogo = false;
    public bool empiezaCombate = false;
  

    // Update is called once per frame
    void Update()
    {
        if (activoDialogo == true) //esto es un puto caos pero lo importante es que cuando te acercas a collider del enemigo el "activoDialogo" se pone en true y pone el fondo,el texto,la imagen,desactive los movimientos del jugador y mande el true al activador del dialogo
        {
            dialogo.SetActive(true);
            fondo.SetActive(true);
            boton.SetActive(true);
            imagen.SetActive(true);
            fondoOscuro.SetActive(true);
            activador.GetComponent<TestControles>().NoSeMueve();
            manager.GetComponent<PRUEBADIALOGO>().ChequearHablando();
        }
        else //esto los desactiva una vez terminan las oraciones del manager
        {
            dialogo.SetActive(false);
            fondo.SetActive(false);
            boton.SetActive(false);
            imagen.SetActive(false);
            fondoOscuro.SetActive(false);
            activador.GetComponent<TestControles>().SeMueve();
            manager.GetComponent<PRUEBADIALOGO>().NoEstaHablando();
        }
        DestruirDialogo();
    }
    private void OnTriggerEnter(Collider col)  //esto activa el dialogo que antes tenias que tocar "E" para hacerlo y ahora es acercandote nomas, no lo saco en caso de que volvamos a como estabamos antes o por cualquier otra cosa.
    {
       if (col.gameObject.tag == "Jugador" )
        {
            ActivarDialogo();
        }
    }
  
    public void ActivarDialogo()
    {
        activoDialogo = true;
    } 
    public void DesactivarDialogo()
    {
        activoDialogo = false;
        empiezaCombate = true;
    }
    public void DestruirDialogo() //una vez que terminan las oraciones mato esto pero no pude usar "this" asi que le llame cerebro.
    {
        if (empiezaCombate == true)
        {
            Destroy(cerebro);
        }
    }
}


    







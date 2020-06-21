using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToscalTexto : MonoBehaviour
{
    public bool hablarConToscal;
    public GameObject textoHablarToscal;
    public GameObject activadorToscal;

    private void Start()
    {
        activadorToscal = GameObject.FindGameObjectWithTag("Jugador");
    }
    private void OnTriggerEnter(Collider col) 
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConToscal = true;
            activadorToscal.GetComponent<JugadorLogic>().puedeHablar = true;
            textoHablarToscal.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConToscal = false;
            activadorToscal.GetComponent<JugadorLogic>().puedeHablar = false;
            textoHablarToscal.SetActive(false);
        }
    }
}

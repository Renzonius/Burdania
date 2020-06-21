using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValenaTexto : MonoBehaviour
{
    public bool hablarConValena;
    public GameObject textoHablarValena;
    public GameObject activadorValena;

    private void Start()
    {
        activadorValena = GameObject.FindGameObjectWithTag("Jugador");
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConValena = true;
            activadorValena.GetComponent<JugadorLogic>().puedeHablar = true;
            textoHablarValena.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConValena = false;
            activadorValena.GetComponent<JugadorLogic>().puedeHablar = false;
            textoHablarValena.SetActive(false);
        }
    }
}

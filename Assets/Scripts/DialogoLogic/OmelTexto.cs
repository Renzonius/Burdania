using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmelTexto : MonoBehaviour
{
    public bool hablarConOmel;
    public GameObject textoHablarOmel;
    public GameObject activadorOmel;
    private void Start()
    {
        activadorOmel = GameObject.FindGameObjectWithTag("Jugador");
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConOmel = true;
            activadorOmel.GetComponent<JugadorLogic>().puedeHablar = true;
            textoHablarOmel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConOmel = false;
            activadorOmel.GetComponent<JugadorLogic>().puedeHablar = false;
            textoHablarOmel.SetActive(false);
        }
    }
}


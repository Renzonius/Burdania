using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbTexto : MonoBehaviour
{
    public bool hablarConBarb;
    public GameObject textoHablarBarb;
    public GameObject activadorBarb;

    private void Start()
    {
        activadorBarb = GameObject.FindGameObjectWithTag("Jugador");
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConBarb = true;
            activadorBarb.GetComponent<JugadorLogic>().puedeHablar = true;
            textoHablarBarb.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            hablarConBarb = false;
            activadorBarb.GetComponent<JugadorLogic>().puedeHablar = false;
            textoHablarBarb.SetActive(false);
        }
    }
}

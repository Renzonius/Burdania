using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrerasLogic : MonoBehaviour
{
    public GameObject fuegoParticula;
    public GameObject Murofuego;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "MuroDeFuego")
        {
            fuegoParticula.SetActive(true);
            Debug.Log("Trigger");

        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "MuroDeFuego")
        {
            fuegoParticula.SetActive(true);
            Debug.Log("Collision");
        }
    }
}

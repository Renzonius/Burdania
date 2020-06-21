using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiezaFlechaLogic : MonoBehaviour
{

    JugadorLogic cantidadPiezas;
    void Start()
    {
        cantidadPiezas = GameObject.FindGameObjectWithTag("Jugador").GetComponent<JugadorLogic>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            if (cantidadPiezas.pienzas < 3)
            {
                cantidadPiezas.pienzas += 1;
            }
            Destroy(gameObject);
        }
    }
}

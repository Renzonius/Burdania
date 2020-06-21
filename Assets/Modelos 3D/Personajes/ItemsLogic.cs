using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsLogic : MonoBehaviour
{
    public int cantidadDePuntos;
    GameObject jugadorRef;
    float vel_giro;
    void Start()
    {
        vel_giro = 200;
        jugadorRef = GameObject.FindGameObjectWithTag("Jugador");
    }

    private void FixedUpdate()
    {
        Giro();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            jugadorRef.GetComponent<JugadorLogic>().puntaje += cantidadDePuntos; 
            Destroy(gameObject);
        }
    }

    void Giro()
    {
         transform.Rotate(0f, vel_giro * Time.deltaTime, 0f);
    }
}

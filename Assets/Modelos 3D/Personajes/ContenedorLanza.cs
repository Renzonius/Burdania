using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContenedorLanza : MonoBehaviour
{
    DrakanLogic dragon;
    JugadorLogic jugador;
    float cant_lanza;
    public bool noHayLanzas;
    float tiempoSpawnLanza = 0f;
    BoxCollider colliderBarril;
    MeshRenderer meshBarril;
    void Start()
    {
        meshBarril = gameObject.GetComponent<MeshRenderer>();
        colliderBarril = gameObject.GetComponent<BoxCollider>();
        noHayLanzas = true;
        cant_lanza = 5f;
        dragon = GameObject.FindGameObjectWithTag("Dragon").GetComponent<DrakanLogic>();
        jugador = GameObject.FindGameObjectWithTag("Jugador").GetComponent<JugadorLogic>();
    }



    private void FixedUpdate()
    {
        SpawnBarrilDeLanzas();
    }
    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Jugador":
                jugador.cant_municion += cant_lanza;
                noHayLanzas = true;
                meshBarril.enabled = false;
                colliderBarril.enabled = false;
                break;
            default:
                break;
        }
    }

    void SpawnBarrilDeLanzas()
    {
        if (dragon.parte == 1 && noHayLanzas == true)
        {
            if (tiempoSpawnLanza >= 10 && noHayLanzas == true)
            {
                noHayLanzas = false;
                tiempoSpawnLanza = 0f;
                meshBarril.enabled = true;
                colliderBarril.enabled = true;
            }
            else
            {
                tiempoSpawnLanza += 0.5f * Time.deltaTime;
            }
        }
    }
}

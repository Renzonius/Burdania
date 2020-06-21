using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsLogic : MonoBehaviour
{
    public Vector3 coordenadasSpanws;
    public GameObject goblin;
    public float tiempoEspera;
    public float debeEsperar;
    public float tiempoFaltante;
    public float iniciar;
    bool detener;
    public int cantidad_goblins;
    public int partesFlecha;

    //Vector3 nuevaEscala = new Vector3(0.2f, 0.2f, 0.2f);

    //test lista
    //public GameObject[] oleadaGoblins;
    //int cantidadGoblins;

    void Start()
    {
        //cantidadGoblins = oleadaGoblins.Length;
        partesFlecha = 3;
         StartCoroutine(spawn());
    }

    void Update()
    {
        tiempoEspera = Random.Range(tiempoFaltante, debeEsperar);
        //goblinConPienza = Random.Range(0, oleadaGoblins.Length);
        if(cantidad_goblins <= 0)
        {
            gameObject.GetComponent<SpawnsLogic>().enabled= false;
        }
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(tiempoEspera);

        while (!detener)
        {
            Vector3 spanwPosicion = new Vector3(Random.Range(-coordenadasSpanws.x, coordenadasSpanws.x), 0f,
                                                Random.Range(-coordenadasSpanws.z, coordenadasSpanws.x));
            if (cantidad_goblins > 0)
            {
                cantidad_goblins -= 1;
                if(cantidad_goblins <= 3 && partesFlecha > 0)
                {
                    goblin.GetComponent<GoblinLogic>().tienePieza = true;
                    //goblin.GetComponent<GoblinLogic>().transform.localScale = nuevaEscala;
                    partesFlecha -=1;
                }
                else
                {
                    goblin.GetComponent<GoblinLogic>().tienePieza = false;
                }
                Instantiate(goblin, spanwPosicion + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            }
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    //IEnumerator spawn()
    //{
    //    yield return new WaitForSeconds(tiempoEspera);

    //    for (int i = 0; i < oleadaGoblins.Length; i++)
    //    {
    //        //cantidad_goblins -= 1;
    //        cantidadGoblins -= 1;
    //        if (i == goblinConPienza && cantidadGoblins > 3 && partesFlecha >0)
    //        {
    //            goblin.GetComponent<GoblinLogic>().tienePieza = true;
    //            partesFlecha -= 1;
    //        }
    //        else if (cantidadGoblins <= 3 && partesFlecha>0)
    //        {
    //            goblin.GetComponent<GoblinLogic>().tienePieza = true;
    //            partesFlecha -= 1;
    //        }
    //        else
    //        {
    //            goblin.GetComponent<GoblinLogic>().tienePieza = false;
    //        }

    //        Vector3 spanwPosicion = new Vector3(Random.Range(-coordenadasSpanws.x, coordenadasSpanws.x), 0f,
    //                                            Random.Range(-coordenadasSpanws.z, coordenadasSpanws.x));
    //        Instantiate(goblin, spanwPosicion + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    //        yield return new WaitForSeconds(tiempoEspera);
    //    }
    //}





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamaraScript : MonoBehaviour
{
    GameObject jugador;
    //public GameObject focojugador;
    public GameObject referencia;
    public Vector3 nuevoFoco;
    public GameObject dragon;
    public Transform focoPersecicion;
    Vector3 distancia;


    Vector3 posicionCorrecta = new Vector3(200f,1f,145f);

    bool moverCamara;
    void Start()
    {
        focoPersecicion = GameObject.FindGameObjectWithTag("FocoPersecucion").transform;
        jugador = GameObject.FindGameObjectWithTag("CamaraJugador");
        dragon = GameObject.FindGameObjectWithTag("Dragon");
        distancia = transform.position - jugador.transform.position;
    }

    void LateUpdate()
    {
        if(moverCamara == false)
        {
            distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;
            transform.position = jugador.transform.position + distancia;
        }

        //transform.LookAt(jugador.transform.position);
        if(dragon.GetComponent<DrakanLogic>().enPosicion == false && dragon.GetComponent<DrakanLogic>().segundaParte !=true)
        {
            transform.LookAt(jugador.transform.position);
            moverCamara = false;
        }
        else if (dragon.GetComponent<DrakanLogic>().segundaParte == true)
        {
            transform.LookAt(focoPersecicion.transform.position);
            transform.position = jugador.transform.position - (distancia+(new Vector3(2f,-1f,0f)));
            moverCamara = true;
        }
        else
        {
            //Falta acomodar la caramara detras del jugador
            transform.LookAt(dragon.transform.position);
            transform.position = jugador.transform.position + distancia;
            moverCamara = true;
        }

        Vector3 rotacion = new Vector3(0, transform.eulerAngles.y, 0);
        referencia.transform.eulerAngles = rotacion;
    }

    //public void EnfocarAlDragon(bool drakanHuyo)
    //{
    //    if (drakanHuyo == false)
    //    {
    //        nuevoFoco = dragon.transform.position;
    //        transform.LookAt(nuevoFoco);

    //    }
    //    else
    //    {
    //        nuevoFoco = jugador.transform.position;
    //        transform.LookAt(nuevoFoco);

    //    }
    //}

    //public void EnfocarPersecicion(bool muroFuego)
    //{
    //    if(muroFuego == true)
    //    {
    //        nuevoFoco = dragon.transform.position;
    //    }
    //    else
    //    {
    //        nuevoFoco = jugador.transform.position;
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamaraScript : MonoBehaviour
{
    GameObject jugadorFocoCamara;
    GameObject jugadorRef;
    //public GameObject focojugador;
    public GameObject referencia;
    public Vector3 nuevoFoco;
    public GameObject dragon;
    public Transform focoPersecucion;
    public GameObject focoPersecucion_2;
    Vector3 distancia;


    Vector3 posicionCorrecta = new Vector3(200f,1f,145f);

    bool moverCamara;
    void Start()
    {
        jugadorRef = GameObject.FindGameObjectWithTag("Jugador");
        focoPersecucion = GameObject.FindGameObjectWithTag("FocoPersecucion").transform;
        jugadorFocoCamara = GameObject.FindGameObjectWithTag("CamaraJugador");
        dragon = GameObject.FindGameObjectWithTag("Dragon");
        distancia = transform.position - jugadorFocoCamara.transform.position;
    }

    void LateUpdate()
    {
        if(dragon.GetComponent<DrakanLogic>().vida > 0 && jugadorRef.GetComponent<JugadorLogic>().vida>0)
        {
            if(moverCamara == false)
            {
                distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2, Vector3.up) * distancia;
                transform.position = jugadorFocoCamara.transform.position + distancia;
            }

            if(dragon.GetComponent<DrakanLogic>().enPosicion == false && dragon.GetComponent<DrakanLogic>().segundaParte !=true && 
                dragon.GetComponent<DrakanLogic>().cuartaParte != true)
            {
                //Siguiendo y mirando al jugador
                transform.LookAt(jugadorFocoCamara.transform.position);
                moverCamara = false;

            }
            else if (dragon.GetComponent<DrakanLogic>().segundaParte == true)
            {
                //mirando al dragon en la persecucion 
                transform.LookAt(focoPersecucion.transform.position);
                transform.position = jugadorFocoCamara.transform.position - (distancia+(new Vector3(4f,-1.5f,0f)));
                moverCamara = true;
            }
            else if (dragon.GetComponent<DrakanLogic>().cuartaParte == true)
            {
                //Mirando al dragon en la 2da persecucion
                transform.LookAt(focoPersecucion_2.transform.position);
                transform.position = jugadorFocoCamara.transform.position - (distancia + (new Vector3(0f, -1f, 2.5f)));
                moverCamara = true;
            }
            else if (dragon.GetComponent<DrakanLogic>().cuartaParte == false)
            {
                transform.LookAt(dragon.transform.position);
                transform.position = jugadorFocoCamara.transform.position + distancia;
                moverCamara = true;
            }
            else 
            {
                //Mirando al dragon en el 1er combate
                //Falta acomodar la caramara detras del jugador
                transform.LookAt(dragon.transform.position);
                transform.position = jugadorFocoCamara.transform.position + distancia;
                moverCamara = true;
                Debug.Log("Cambio la camara");
            }

            Vector3 rotacion = new Vector3(0, transform.eulerAngles.y, 0);
            referencia.transform.eulerAngles = rotacion;

        }
        else
        {
            if(dragon.GetComponent<DrakanLogic>().vida <= 0)
            {
                camaraVictoria();
            }
            else if(jugadorRef.GetComponent<JugadorLogic>().vida <= 0)
            {
                camaraDerrota();
            }
        }
    }

    void camaraVictoria()
    {
        jugadorRef.GetComponent<JugadorLogic>().PoseDeVictoria();
    }

    void camaraDerrota()
    {
        if(gameObject.transform.position.y < 10)
        {
            transform.position = gameObject.transform.position + new Vector3(0f, (0.5f * Time.deltaTime) , 0f);
            transform.LookAt(jugadorFocoCamara.transform.position);
        }
    }

}

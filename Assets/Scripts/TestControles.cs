using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControles : MonoBehaviour
{
    public CharacterController jugador;
    public float movHorizontal;
    public float movVertical;
    public float velocidad;
    private Vector3 jugadorInputs;
    private Vector3 movJugador;

    public Camera camara;
    private Vector3 camAdelante;
    private Vector3 camDerecha;

    public float gravedad;
    public float velCaida;
    public float fuerzaSalto;

    void Start()
    {
        gravedad = -9.8f;
        fuerzaSalto = 4;
        jugador = GetComponent<CharacterController>();
        camara = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        DespasamientoJugador();
    }



    private void DespasamientoJugador()
    {
        movHorizontal = Input.GetAxis("Horizontal");
        movVertical = Input.GetAxis("Vertical");

        jugadorInputs = new Vector3(movHorizontal, 0, movVertical); //ajustes en la velociadad del movimiento del juegador
        jugadorInputs = Vector3.ClampMagnitude(jugadorInputs, 1);

        DirecCamara();

        movJugador = jugadorInputs.x * camDerecha + jugadorInputs.z * camAdelante;
        movJugador = movJugador * velocidad;

        jugador.transform.LookAt(jugador.transform.position + movJugador);

        SetGravedad();
        SetSalto();

        jugador.Move(movJugador * Time.deltaTime);


    }

    void DirecCamara()
    {
        camAdelante = camara.transform.forward;
        camDerecha = camara.transform.right;

        camAdelante.y = 0; //bloqueo de la camara en el eje Y
        camDerecha.y = 0;

        camAdelante = camAdelante.normalized;   
        camDerecha = camDerecha.normalized;
    }
    void SetGravedad()
    {
        if (jugador.isGrounded)
        {
            velCaida = gravedad * Time.deltaTime;
            movJugador.y = velCaida;
        }
        else
        {
            velCaida += gravedad * Time.deltaTime;
            movJugador.y = velCaida;
        }
    }
    void SetSalto()
    {
        if (jugador.isGrounded && Input.GetButtonDown("Jump"))
        {
            velCaida = fuerzaSalto;
            movJugador.y = velCaida;
        }
    }
}

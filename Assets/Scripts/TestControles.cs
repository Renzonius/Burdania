using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestControles : MonoBehaviour
{
    //PARA EL DASH
    public Vector3 direccionDash; //sirve para definir la posicion del jugador  a la hora de usar el controlador.move

    public float tiempoCooldown = 1; //son los segundos que tienen que pasar hasta volver a usar la habilidad
    private float siguienteDash = 0; //se usa para el calculo del cooldown

    public const float tiempoMaximoDash = 1.0f; //el tiempo que se pasa en el dash
    public float distanciaDash = 10;// cuanta mas distancia sea mas lejos se desplaza
    public float velocidadFrenadaDash = 0.1f;// esto evita que el jugador siga de largo 
    float tiempoDashAhora = tiempoMaximoDash;//esto se usa para que todos los dashes duren lo mismo y se detengan con la frenada
    float velocidadDash = 6;// creo que se explica solo pero es que tan rapido se mueve, la diferencia con el tiempo maximo es que si este se aumenta el personaje va mas rapido y en el otro el dash dura mas o menos d
    //PARA EL DASH
    
    //PARA EL DIALOGO//
    public bool sePuedeMover = true;
    public GameObject dialogo;
    //PARA EL DIALOGO//
    public TestAtaque ataque;

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


    public GameObject barb;
    public GameObject toscal;
    public GameObject valena;
    public GameObject cruzado;
 

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
        if (sePuedeMover == true) {
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
        Dash(); //AGREGADO ACA // 
        ataque.Atacar(); //AGREGADO ACA//
        jugador.Move(movJugador * Time.deltaTime);
        }


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

    
    void Dash()
    {
        if (Input.GetButtonDown("Fire2") & jugador.isGrounded & Time.time > siguienteDash) //el time > siguiente dash es que el tiempo que paso desde que se usa la habilidad se suma con el cooldown hasta que time sea mayor y se pueda volver a usar el dash, puse lo de isGrounded para no poder usarlo en el aire
        {
            tiempoDashAhora = 0;
            siguienteDash = Time.time + tiempoCooldown; //añade el tiempo de cooldown al tiempo normal para definir cuando sale el siguiente
        }
        if (tiempoDashAhora < tiempoMaximoDash) //como al hacer click el tiempoDashAhora se vuelve 0, se puede mover hasta que se suma la frenada
        {
            direccionDash = transform.forward * distanciaDash; //esto sirve para que el dash vaya hacia adelante, no es lo mismo que el .move 
            tiempoDashAhora += velocidadFrenadaDash;
        }
        else
        {
            direccionDash = Vector3.zero; //esto vuelve a 0 para poder redefinir siempre una nueva posicion 

        }
        jugador.Move(direccionDash * Time.deltaTime * velocidadDash); // con esto se hace el dash,se "adelanta al tiempo" moviendose rapido
    }
    
    
   
   public void NoSeMueve()
    {
        sePuedeMover = false;
    }
    public void SeMueve() 
    {
        sePuedeMover = true;
    } 
}

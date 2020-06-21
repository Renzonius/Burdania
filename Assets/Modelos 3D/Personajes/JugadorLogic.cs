using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorLogic : MonoBehaviour
{
    public CharacterController jugador;
    public Animator anim;
    public float movHorizontal;
    public float movVertical;
    public float velocidad;
    private Vector3 jugadorInputs;
    private Vector3 movJugador;

    public Camera camara;
    public GameObject camaraRef;
    private Vector3 camAdelante;
    private Vector3 camDerecha;

    public float gravedad;
    public float velCaida;
    public float fuerzaSalto;
    public float vida;
    public DrakanLogic dañoFuegoDragon;

    public float cant_municion;
    public float tiempo_daño = 1f;
    public bool PuedeRecibirDaño;
    public int puntaje;

    public GameObject proyectil;
    public GameObject spawnLanzas;

    public GameObject goblinRef;

    GameObject ballesta;
    public int pienzas;

    float tiempoEntreAtaques = 3;

    void Start()
    {
        camaraRef = GameObject.FindGameObjectWithTag("MainCamera"); 
        ballesta = GameObject.FindGameObjectWithTag("Ballesta");
        spawnLanzas = GameObject.FindGameObjectWithTag("SpawnLanza");
        gravedad = -9.8f;
        fuerzaSalto = 4;
        dañoFuegoDragon = GameObject.FindGameObjectWithTag("Dragon").GetComponent<DrakanLogic>();
        jugador = GetComponent<CharacterController>();
        camara = FindObjectOfType<Camera>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (vida > 0)
        {
            DespasamientoJugador();
            RecibirDaño();
            ArrojarLanza();
            if(ballesta.GetComponent<BallestaLogic>().jugadorCerca == true &&
                ballesta.GetComponent<BallestaLogic>().CantidadProyectil >0)
            {
                DispararBallesta();
            }
        }
        else
        {
            anim.Play("Muerte");
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fuego" && PuedeRecibirDaño == true)
        {
            vida -= dañoFuegoDragon.daño;
            tiempo_daño = 0f;
            PuedeRecibirDaño = false;
        }
        else if (col.gameObject.tag == "Goblin" && PuedeRecibirDaño == true)
        {
            vida -= goblinRef.GetComponent<GoblinLogic>().daño;
            tiempo_daño = 0f;
            PuedeRecibirDaño = false;
        }
        else if(col.gameObject.tag == "MuroDeFuego")
        {
            vida = 0;
        }
    }

    void SumarPuntaje()
    {
        puntaje += 10;
    }




    void RecibirDaño()
    {
        if (tiempo_daño >= 3f)
        {
            PuedeRecibirDaño = true;
        }
        else if(tiempo_daño <= 4f)
        {
            tiempo_daño += 1f * Time.deltaTime;
        }
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

        if (movHorizontal != 0 || movVertical != 0)
        {
            anim.SetBool("Correr", true);
            anim.SetBool("Correr", true);
        }
        else
        {
            anim.SetBool("Correr", false);
        }

        if (jugador.isGrounded == true)
            anim.SetBool("Saltar", false);

    }

    void DispararBallesta()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            ballesta.GetComponent<BallestaLogic>().DispararProyectil();
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
            anim.SetBool("Saltar", true);
            velCaida = fuerzaSalto;
            movJugador.y = velCaida;
        }
    }

    void ArrojarLanza()
    {
        if(tiempoEntreAtaques >= 3f)
        {
            if (Input.GetMouseButtonDown(0) && cant_municion >0)
            {
                Instantiate(proyectil, spawnLanzas.transform.position, spawnLanzas.transform.rotation);
                anim.SetBool("AtaqueToma", true);
                cant_municion -= 1; 
                tiempoEntreAtaques = 0f;
            }
        }
        else
        {
            anim.SetBool("AtaqueToma", false);
            tiempoEntreAtaques += 2.9f * Time.deltaTime; 
        }
    }

    public void PoseDeVictoria()
    {
        transform.LookAt(camaraRef.transform.position);
        anim.Play("PoseVictoria");
    }
}

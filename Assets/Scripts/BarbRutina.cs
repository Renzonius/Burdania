using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbRutina : MonoBehaviour
{
    public Animator anim;
    int vida;
    int daño_enem;
    float vel_rotacion;
    float vel_movimiento;

    GameObject jugadorObjetivo;
    Rigidbody rigidRef;
    Vector3 pos_jugador;
    float path;

    Vector3 pos_enem;
    Transform enemTranRef;
    float cont_ataque;

    bool moverse;
    bool ataque;
    bool carga;

    //Banderas
    bool apuntar_ban;
    bool embestir_ban;
    bool esperar_ban;
    bool salto_ban;
    bool posicionCentro;

    //contadores
    float cont_apuntar;

    //2da ETAPA
    public Vector3 pos_centro;
    public float ang_salto;
    public float graveda;
    CapsuleCollider collRef;
    public Transform spanwToma;
    public GameObject tomahawkObj;
    float cont_lanzar = 2;

    void Start()
    {
        rigidRef = GetComponent<Rigidbody>();
        collRef = GetComponent<CapsuleCollider>();
        vel_movimiento = 3f;
        vel_rotacion = 6f;
        jugadorObjetivo = GameObject.FindGameObjectWithTag("Jugador");
        pos_enem = gameObject.transform.position;
        enemTranRef = gameObject.transform;
        path = 5f;
        vida = 2;
        daño_enem = 1;
        anim = GetComponent <Animator>();
        cont_ataque = 3f;
    }

    void FixedUpdate()
    {
        Etapas();

    }

    void saltoOblicuo()
    {

    }

    void Etapas()
    {
        switch (vida)
        {
            case 3:
                if (apuntar_ban == true && cont_apuntar <= 3f)
                {
                    MirarJugador();
                    cont_apuntar += 1f * Time.deltaTime;
                    Debug.Log(cont_apuntar);
                }
                else
                {
                    Embestida();
                }
                break;
            case 2:
                if (salto_ban == false && transform.position != pos_centro)
                {
                    StartCoroutine(Salto());
                    salto_ban = true;
                }
                else if(salto_ban == true && posicionCentro == true)
                {

                    LanzarTomahawk();
                }
                break;
            default:
                break;
        }
    }


    IEnumerator Salto()
    {
        yield return new WaitForSeconds(0.1f);
        //calcula la distancia del salto
        float distancia_centro = Vector3.Distance(enemTranRef.position, pos_centro);

        //velocidad de movimiento
        float vel_movimiento = distancia_centro / (Mathf.Sin(2 * ang_salto * Mathf.Deg2Rad) / graveda);

        //respectivos ejes
        float vX = Mathf.Sqrt(vel_movimiento) * Mathf.Cos(ang_salto * Mathf.Deg2Rad);
        float vY = Mathf.Sqrt(vel_movimiento) * Mathf.Sin(ang_salto * Mathf.Deg2Rad);

        //rota hacia el objetivo
        transform.rotation = Quaternion.LookRotation(pos_centro - enemTranRef.position);

        float duracion_vuelo = distancia_centro / vX;
        float tiempo_vuelo = 0;
        salto_ban = true;

        while ( transform.position.y >= pos_centro.y)
        {
            transform.Translate(0, (vY - (graveda * tiempo_vuelo)) * Time.deltaTime, vX * Time.deltaTime);
            tiempo_vuelo += Time.deltaTime;
            yield return null;
        }
        Debug.Log("llego");
        enemTranRef.position = pos_centro;
        transform.position = enemTranRef.position;
        posicionCentro = true;
    }





    void IrAPosicion()
    {
        
    }

    void CalcularDistanciaEnemigoJugador()
    {
        float distancia;
        distancia = Vector3.Distance(jugadorObjetivo.transform.position, transform.position);
    }

    void Embestida()
    {
        rigidRef.AddRelativeForce(Vector3.forward * 15f *Time.deltaTime, ForceMode.Impulse);
        anim.SetBool("Correr", true);

    }

    void AtaqueConHacha()
    {
        anim.SetBool("Correr", false);
        anim.SetTrigger("Ataque1");

    }
    void MirarJugador()
    {
        anim.SetBool("Correr", false);
        enemTranRef.rotation = Quaternion.Slerp(enemTranRef.rotation,
         Quaternion.LookRotation(jugadorObjetivo.transform.position - enemTranRef.position), vel_rotacion * Time.deltaTime);
    }
    void Perseguir()
    {
        enemTranRef.position += enemTranRef.forward * vel_movimiento * Time.deltaTime;
        anim.SetBool("Correr", true);
    }
    IEnumerator Esperar()
    {
        //Espera antes de volver a ponerse en reposo y no cortar la animacion de ataque 1
        yield return new WaitForSeconds(0.5f) ;
        ataque = true;
    }

    void LanzarTomahawk()
    {
        MirarJugador();

        StartCoroutine(InstanciarToma());

        StartCoroutine(Indefenso());

        StartCoroutine(EnGuardia());
    }
    IEnumerator InstanciarToma()
    {
        yield return new WaitForSeconds(3f);
        if(cont_lanzar <= 1.5)
        {
            Instantiate(tomahawkObj, spanwToma.position, spanwToma.rotation);
            cont_lanzar = 2;
            anim.SetBool("AtaqueToma", true);
        }
        else
        {
            cont_lanzar -= cont_lanzar *0.5f* Time.deltaTime;

        }

    }

    IEnumerator Indefenso()
    {
        yield return new WaitForSeconds(20f);
        collRef.enabled = true;
        Debug.Log("Esta indefenso");
        anim.SetBool("AtaqueToma", false);
        StopCoroutine(Indefenso());
        
    }

    IEnumerator EnGuardia()
    {
        yield return new WaitForSeconds(10f);
        collRef.enabled = false;
        Debug.Log("Esta Guardia");

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Muro")
        {
            apuntar_ban = true;
            cont_apuntar = 0f;
            rigidRef.velocity = Vector3.zero;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakanLogic : MonoBehaviour
{
    public float vida;
    Animator anim;
    BoxCollider colliderRef;
    Transform dragonTrans;

    public GameObject jugadorObjetivo;
    float jugadorVida;

    public Transform puntoSpawn;
    public GameObject llamas;
    public ParticleSystem particulasLlamas;

    //CambiarFocoCamara camara;
    MainCamaraScript camara;
    float vel_rotacion;

    Animator drakanAnim;

    public bool primeraParte;
    public bool segundaParte;
    public bool terceraParte;
    public bool cuartaParte;
    public bool quintaParte;

    public bool volando;
    public bool HabilitarZona;
    float calculo_vida;
    public float daño = 25;
    public bool enPosicion;
    public bool comienzaCombate;
    float tiempo_entre_llamas;
    public float tiempoReposo = 15f;
    public float tiempoAtaque = 10f;




    //Testeando
    public float parte;
    public float tiempoDescansando = 0; //comienza descanso 0<=10
    public float tiempoAtacando = 0;
    public bool drakanHuyo;
    bool rugir;
    GameObject drakan;
    public bool ataqueVolando;
    public bool muroFuego;
    public bool persecucionPrimeraParte;

    //Combate Fianal
    float aciertos;
    GameObject spawnGoblins;
    GameObject ballestaRef;
    void Start()
    {
        ballestaRef = GameObject.FindGameObjectWithTag("Ballesta");
        spawnGoblins = GameObject.FindGameObjectWithTag("Spawn");
        particulasLlamas.Pause();
        dragonTrans = gameObject.transform;
        jugadorObjetivo = GameObject.FindGameObjectWithTag("Jugador");
        jugadorVida = jugadorObjetivo.GetComponent<JugadorLogic>().vida;
        drakan = GameObject.FindGameObjectWithTag("Drakan");
        daño = jugadorObjetivo.GetComponent<JugadorLogic>().vida * 25 / 100;
        vel_rotacion = 6f;
        //camara = GameObject.FindGameObjectWithTag("Enfocador").GetComponent<CambiarFocoCamara>();
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamaraScript>();
        //vida = 100f;
        colliderRef = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        drakanAnim = GameObject.FindGameObjectWithTag("Drakan").GetComponent<Animator>();
        puntoSpawn = GameObject.FindGameObjectWithTag("SpawnLlamas").transform;
        calculo_vida = vida * 75 / 100;
    }

    
    void FixedUpdate()
    {
        //if(primeraParte==true)
        //    Combatir();

        //testeando
        if(vida > 0)
        {
            Combates();
        }
        else
        {
            drakanAnim.Play("Muerte");
        }

    }


 
    void Combates()
    {
        switch (parte)
        {
            case 1:
                {
                    if (enPosicion == false && drakanHuyo == false)
                    {
                        EntradaDeDrakan();
                    }
                    else if (vida > 75) //Vida del dragon >75
                    {
                        //camara.CambiarFocoPrimerCombate(drakanHuyo); //Enfocando a Drakan
                        //camara.EnfocarAlDragon(drakanHuyo);
                        anim.enabled = false; //se desactiva para que pueda rotar hacia el jugador
                        MirarJugador();
                        RugidoDrakan(); //booleano de presentacion?

                        StartCoroutine(ComienzaCombate());
                    }
                    else
                    {
                        Huir();
                    }
                    break;
                }
            case 2:
                {
                    Persecucion();
                    break;
                }
            case 3:
                {
                    JugadorEnLaPlaza();
                    break;
                }
            case 4:
                {
                    PersecucionFinal();
                    break;
                }
            case 5://Combate Final
                {
                    if (enPosicion == false)
                    {
                        DrakanDesciende();
                    }
                    else
                    {
                        anim.enabled = false;
                        drakanAnim.SetBool("Volar", false);
                        drakanAnim.SetBool("EnSuelo", true);
                        MirarJugador();
                        //se setea la cantidad de piezas que tiene cada oleada de goblins
                        spawnGoblins.GetComponent<SpawnsLogic>().partesFlecha = 3;

                    }
                    break;
                }
            case 6:
                {
                    StartCoroutine(AtaqueDeGoblins());
                    break;
                }
            case 7:
                {
                    anim.enabled = false;
                    spawnGoblins.GetComponent<SpawnsLogic>().enabled=true;
                    BallestaCargada();
                    break;
                }
            case 8:
                {
                    drakanAnim.Play("Muerte");
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void BallestaCargada()
    {
        if(ballestaRef.GetComponent<BallestaLogic>().CantidadProyectil >= 1)
        {
            enPosicion = false;
            if(enPosicion == false)
                parte = 5;
        }
    }

    IEnumerator AtaqueDeGoblins()
    {
        yield return new WaitForSeconds(1f);
        anim.enabled = true;
        drakanAnim.SetBool("RecibeDaño", false);
        drakanAnim.SetBool("EnSuelo", false);
        anim.Play("DrakanSeAleja");
    }
   public void SiguienteParte()
   {
        OleadaSegunVida();
        if(vida > 0)
        {
            parte = 7;
            Debug.Log("NO Se murio");
        }
        else
        {
            parte = 8;
        }
   }

    void OleadaSegunVida()
    {
        if (vida == 50)
        {
            spawnGoblins.GetComponent<SpawnsLogic>().cantidad_goblins = 10;
        }
        else if (vida == 25)
        {
            spawnGoblins.GetComponent<SpawnsLogic>().cantidad_goblins = 15;

        }
        else if(vida <=0)
        {
            parte = 8;
        }
    }
    
 
    

    void EntradaDeDrakan()
    {
        anim.Play("IntroDrakan");
        drakanAnim.SetBool("Volar", true);
    }

    void DrakanDesciende()
    {
        anim.enabled = true;
        anim.Play("IrAlCombateFinal");
    }

    void RugidoDrakan()
    {
        drakanAnim.SetBool("Volar", false);
        drakanAnim.SetBool("EnSuelo", true);
        drakanAnim.SetBool("Rugir", true);
        drakanAnim.SetBool("Rugir", false);
    }

    void LanzarLLamas()
    {
        drakanAnim.SetBool("AtaqueSuelo", true);
        particulasLlamas.Play();
        if (tiempo_entre_llamas <= 1.5)
        {
            Instantiate(llamas, puntoSpawn.position, puntoSpawn.rotation);
            tiempo_entre_llamas = 2;
        }
        else
        {
            tiempo_entre_llamas -= tiempo_entre_llamas * 0.5f * Time.deltaTime;

        }
        tiempoAtacando += 1 * Time.deltaTime;
    }

    void Descanso()
    {
        drakanAnim.SetBool("AtaqueSuelo", false);
        particulasLlamas.Stop();
        tiempoDescansando += 1 * Time.deltaTime;
    }


    void Huir()
    {
        particulasLlamas.Stop();
        drakanAnim.SetBool("EnSuelo", false);
        drakanHuyo = true;
        enPosicion = false;

        colliderRef.enabled = false;
        anim.enabled = true;
        anim.Play("SegundaParteDrakan");
    }


    IEnumerator ComienzaCombate()
    {
        if (tiempoDescansando <= 5)
        {
            Descanso();
        }
        else if (tiempoAtacando <= 6 && tiempoDescansando >= 5)
        {
            LanzarLLamas();
        }
        else
        {
            tiempoDescansando = 0;
            tiempoAtacando = 0;
        }
        yield return new WaitForSeconds(0.1f);
    }

    void Persecucion()
    {
        if (segundaParte == true)
        {
            anim.Play("Persecucion_1");
            if (ataqueVolando == true)
            {
                drakanAnim.SetBool("Volar", true);
            }
            else
            {
                drakanAnim.SetBool("Volar", false);
            }
        }
        else
        {
            anim.enabled = false;
        }
    }

    void PersecucionFinal()
    {
        if(enPosicion == false)
        {
            anim.Play("Persecucion_2");
            if (ataqueVolando == true)
            {
                drakanAnim.SetBool("Volar", true);
            }
            else
            {
                drakanAnim.SetBool("Volar", false);
            }
        }
    }

    void JugadorEnLaPlaza()
    {
        anim.SetBool("Patrullar", true);
        if (ataqueVolando == true)
        {
            drakanAnim.SetBool("Volar", true);
        }
    }











    void MirarJugador()
    {
        dragonTrans.rotation = Quaternion.Slerp(dragonTrans.rotation,
         Quaternion.LookRotation(jugadorObjetivo.transform.position - dragonTrans.position), vel_rotacion * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider col)
    {
        if(vida > 0)
        {
            switch (col.gameObject.tag)
            {
                case "Lanza":
                    {
                        if(parte == 1)
                            vida -= 2.5f;
                        break;
                    }
                case "Flecha":
                    {
                        drakanAnim.SetBool("RecibeDaño", true);
                        vida -= 25f;
                        parte = 6;
                        break;
                    }
            }
            //if (col.gameObject.tag == "Lanza" && vida >0)
            //{
            //    vida -= 2.5f;
            //}
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeAccion : MonoBehaviour
{

    BoxCollider colliderRef;
    public DrakanLogic drakan;
    public float nro_parte;
    public GameObject barreraSegundaParte;
    public GameObject barreraCombateFianl;
    GameObject arena;
    GameObject pasilloA;

    void Start()
    {
        arena = GameObject.FindGameObjectWithTag("Arena");
        pasilloA = GameObject.FindGameObjectWithTag("PasilloA");
        colliderRef = GetComponent<BoxCollider>();
        drakan = GameObject.FindGameObjectWithTag("Dragon").GetComponent<DrakanLogic>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider jugador)
    {
        if(jugador.gameObject.tag == "Jugador")
        {
            drakan.parte = nro_parte; //modifica el Swich
            if(nro_parte == 2)
                drakan.segundaParte = true;
            else if(nro_parte == 3)
            {
                drakan.segundaParte = false;
                barreraSegundaParte.SetActive(true);
            }
            else if(nro_parte == 4)
            {
                drakan.cuartaParte = true;
                arena.SetActive(false);
                pasilloA.SetActive(false);
            }
            else if(nro_parte == 5)
            {
                barreraCombateFianl.SetActive(true);
                drakan.cuartaParte = false;
                drakan.quintaParte = true;
            }

        }
    }
}

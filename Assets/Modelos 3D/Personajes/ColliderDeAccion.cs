using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeAccion : MonoBehaviour
{

    BoxCollider colliderRef;
    public DrakanLogic drakan;
    public float nro_parte;
    public GameObject barreraSegundaParte;

    void Start()
    {
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
            drakan.parte = nro_parte;
            if(nro_parte == 2)
                drakan.segundaParte = true;
            else if(nro_parte == 3)
            {
                drakan.segundaParte = false;
                barreraSegundaParte.SetActive(true);
            }

        }
    }
}

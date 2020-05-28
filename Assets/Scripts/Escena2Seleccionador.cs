using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escena2Seleccionador : MonoBehaviour
{
    private SelectorPersonaje elNombre;

    public GameObject barb;
    public GameObject toscal;
    public GameObject valena;
    public GameObject cruzado;

    public GameObject enemigoBarb;
    public GameObject enemigoToscal;
    public GameObject enemigoValena;
    public GameObject enemigoCruzado;


    // Start is called before the first frame update
    void Start()// intente hacerlo todo con un solo seleccionador y saltaron 50 problemas, por lo que hice unga unga y puse tres seleccionadores que cambian dependiendo de la escena.
    {
        elNombre = GameObject.Find("ContenedorVariables").GetComponent<SelectorPersonaje>();
        SelectorUno();
        SelectorDos();
        SelectorTres();
        SelectorCuatro();

    }
    void SelectorUno()
    {
        if (elNombre.seleccionoUno == true)
        {
            barb.SetActive(true);
            toscal.SetActive(false);
            valena.SetActive(false);
            cruzado.SetActive(false);

            enemigoBarb.SetActive(false);
            enemigoToscal.SetActive(false);
            enemigoValena.SetActive(true);
            enemigoCruzado.SetActive(false);
          
        }
    }
    void SelectorDos()
    {
        if (elNombre.seleccionoDos == true)
        {
            barb.SetActive(false);
            toscal.SetActive(true);
            valena.SetActive(false);
            cruzado.SetActive(false);

            enemigoBarb.SetActive(false);
            enemigoToscal.SetActive(false);
            enemigoValena.SetActive(false);
            enemigoCruzado.SetActive(true);
           
        }
    }
    void SelectorTres()
    {
        if (elNombre.seleccionoTres == true)
        {
            barb.SetActive(false);
            toscal.SetActive(false);
            valena.SetActive(true);
            cruzado.SetActive(false);

            enemigoBarb.SetActive(true);
            enemigoToscal.SetActive(false);
            enemigoValena.SetActive(false);
            enemigoCruzado.SetActive(false);
     
        }
    }
    void SelectorCuatro()
    {
        if (elNombre.seleccionoCuatro == true)
        {
            barb.SetActive(false);
            toscal.SetActive(false);
            valena.SetActive(false);
            cruzado.SetActive(true);

            enemigoBarb.SetActive(false);
            enemigoToscal.SetActive(true);
            enemigoValena.SetActive(false);
            enemigoCruzado.SetActive(false);
          
        }
    }
}

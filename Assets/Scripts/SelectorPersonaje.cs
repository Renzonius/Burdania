using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorPersonaje : MonoBehaviour
{
    public bool seleccionoUno = false;
    public bool seleccionoDos = false;
    public bool seleccionoTres = false;
    public bool seleccionoCuatro = false;


    //seleccion de personajes

    //public GameObject Barb;
    //public GameObject Toscal;
    //public GameObject Valena;
    //public GameObject Omel;

    //// Start is called before the first frame update
    //void Awake()
    //{
    //    DontDestroyOnLoad(this);
    //}
   
    //public void SegunNombre()
    //{
    //    if(Barb.name == "BARB")
    //    {
    //        SceneManager.LoadScene("");
    //    }
    //}
   







    public void SelectorUno()
    {
        seleccionoUno= true;
    }
    public void SelectorDos()
    {
        seleccionoDos = true;
    }
    public void SelectorTres()
    {
        seleccionoTres = true;
    }
    public void SelectorCuatro()
    {
        seleccionoCuatro = true;
    }
}

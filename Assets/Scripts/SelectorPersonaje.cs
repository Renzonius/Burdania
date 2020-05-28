using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorPersonaje : MonoBehaviour
{
    public bool seleccionoUno = false;
    public bool seleccionoDos = false;
    public bool seleccionoTres = false;
    public bool seleccionoCuatro = false;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        
    }
   
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
    // Update is called once per frame
    void Update()
    {
        
    }
}

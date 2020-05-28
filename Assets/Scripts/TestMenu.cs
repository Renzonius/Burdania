using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMenu : MonoBehaviour
{
    public string pantallaSeleccion;

    public void SeleccionPersonaje()
    {
        SceneManager.LoadScene(pantallaSeleccion);
    }
    public void Salir()
    {
        Application.Quit();
    }
}

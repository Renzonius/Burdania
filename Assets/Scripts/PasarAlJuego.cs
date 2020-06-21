﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PasarAlJuego : MonoBehaviour
{
    public string nuevoJuego;
    public string menuPrincipal;

    public void NuevaPartida()
    {
        SceneManager.LoadScene(nuevoJuego);
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene(menuPrincipal);
    }
}

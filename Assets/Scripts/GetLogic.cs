using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLogic : MonoBehaviour
{
    [System.Serializable]
    public class PlayerInfo
    {
        public string nickJugador;
        public int puntos;
    }
    [System.Serializable]
    public class ListaPlayerInfo
    {
        public PlayerInfo[] listaPartidas;
    }
}

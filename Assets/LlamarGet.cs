using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static GetLogic;
using TMPro;

public class LlamarGet : MonoBehaviour
{

    public TextMeshProUGUI mostrar;
    public TextMeshProUGUI mostrar2;
    public TextMeshProUGUI mostrar3;

    readonly string get = "http://localhost:55803/api/partida/obtenerListado";
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InvocarGet()
    {
        StartCoroutine(GetRequest(get));
    }
    IEnumerator GetRequest(string url)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);

        yield return uwr.SendWebRequest();
        
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            ListaPlayerInfo lista = JsonUtility.FromJson<ListaPlayerInfo>("{\"listaPartidas\":" + uwr.downloadHandler.text + "}");

            mostrar.text = lista.listaPartidas[0].nickJugador + ":" + lista.listaPartidas[0].puntos.ToString(); 
            mostrar2.text = lista.listaPartidas[1].nickJugador + ":" + lista.listaPartidas[1].puntos.ToString();
            mostrar3.text = lista.listaPartidas[2].nickJugador + ":" + lista.listaPartidas[2].puntos.ToString(); 


        }
    }
}

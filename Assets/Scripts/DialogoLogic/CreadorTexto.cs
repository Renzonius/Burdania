using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CreadorTexto : MonoBehaviour
{
    public TextMeshProUGUI mostrarTexto;
    string[] oraciones = { "" };
    private int indice;
    public float velocidadTipeo;
    public bool estaHablando = false;
    public bool matarRutina = false;
    public GameObject desactivador;
    public GameObject toscal;
    public GameObject barb;
    public GameObject valena;
    public GameObject omel;
    public int estaEscena;
    // Start is called before the first frame update
    void Start()
    {
        int estaEscena = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void Update()
    {
        if (estaHablando == true & matarRutina == false) //el matar rutina solo esta para evitar que la rutina se repita todo el tiempo
        {
            StartCoroutine(Escrbir());
            matarRutina = true;
        }
        if(estaEscena == 5)
        {
            OracionesParaBarb();
        }
        else if (estaEscena == 6)
        {
            OracionesParaToscal();
        }
    }
    IEnumerator Escrbir()
    {
        foreach (char letras in oraciones[indice].ToCharArray()) //esto es lo que hace que se "escriban" las letras y no aparezcan de una,devuelve letra por letra en las oraciones que escribi dependiendo de la velocidad que quiera
        {
            mostrarTexto.text += letras;
            yield return new WaitForSeconds(velocidadTipeo);
        }
    }
    public void SiguienteOracion()
    {
        if (indice < oraciones.Length - 1) //mientras quede mas oraciones en la matriz va a seguir escupiendolas, el "" evita que se siga escribiendo
        {
            indice++;
            mostrarTexto.text = "";
            StartCoroutine(Escrbir());
        }
        else //una vez que se termino todo, mato la esfera de colision que activa el dialogo
        {
            mostrarTexto.text = "";
            desactivador.GetComponent<ActivadorFondo>().DesactivarDialogo();
        }
    }
    public void TerminoOracion() //Esto sirve para el boton de continuar que activa la siguiente oracion
    {
        if (mostrarTexto.text == oraciones[indice])
        {
            SiguienteOracion();
        }
    }
    public void ChequearHablando() //esto era para el acercarse y tocar "E", lo mismo, no lo saco por las dudas.
    {
        estaHablando = true;
    }
    public void NoEstaHablando()
    {
        estaHablando = false;
        matarRutina = false;
    }

    public void OracionesParaBarb() 
    {
        if (toscal.GetComponent<ToscalTexto>().hablarConToscal == true)//De Toscal
        {
            oraciones[0] = "JAJAJAJAJAJAJAJAJA"; 
        }
        if (valena.GetComponent<ValenaTexto>().hablarConValena == true)//De Valena
        {
            oraciones[0] = "kkkkkkkkkkkkkkk";
        }
        if (omel.GetComponent<OmelTexto>().hablarConOmel == true)//De Omel
        {
            oraciones[0] = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        
        }
    }
    public void OracionesParaToscal()
    {
        if (barb.GetComponent<BarbTexto>().hablarConBarb == true)//De Barb
        {
            oraciones[0] = "JVVVVVVVVVVVVVVVVVA";
        }
        if (omel.GetComponent<OmelTexto>().hablarConOmel == true)//De Omel
        {
            oraciones[0] = "ADSASDASD";
        }
        if (valena.GetComponent<ValenaTexto>().hablarConValena == true)//De Valena
        {
            oraciones[0] = "EEEEEEEEEEEEEEEEEEEE";
        }
        
    }
    #region los marginados

    public void OracionesDeValena()
    {
        int estaEscena3 = SceneManager.GetActiveScene().buildIndex;
        if (estaEscena3 == 2)//Para Omel
        {
            oraciones[0] = "JAJAJAJAJAJAJCVCVCCVCVCVAJAJA";
            oraciones[1] = "EY FUNBBBBCIONA";
        }
        if (estaEscena3 == 3)//Para Barb
        {
            oraciones[0] = "kkkkkkkkkASDASDASDkkkkkk";
            oraciones[1] = "EY FUNCIOGGGGGGGGGNA";
        }
        if (estaEscena3 == 4)//Para Toscal
        {
            oraciones[0] = "AAAAAAAAAAAAAAAEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAA";
            oraciones[1] = "EY FUNCIORRRRNA";
        }
    }
    public void OracionesDeOmel()
    {
        int estaEscena4 = SceneManager.GetActiveScene().buildIndex;
        if (estaEscena4 == 2)//Para Barb
        {
            oraciones[0] = "JAJAJAJAJAJAJAJAJAAAAAAAAAAAAAA";
            oraciones[1] = "EY FUASDASDNCIONA";
        }
        if (estaEscena4 == 3)//Para Toscal
        {
            oraciones[0] = "kkkkkkkkkkkkkNNNNNNNNNNNNNkk";
            oraciones[1] = "EY FUNCIOSADFFFFFFFFFNA";
        }
        if (estaEscena4 == 4)//Para Valena
        {
            oraciones[0] = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAFFFFFFFFFFAAAAAAAA";
            oraciones[1] = "EY FUNCICVVCBBONA";
        }
    }
    #endregion


}
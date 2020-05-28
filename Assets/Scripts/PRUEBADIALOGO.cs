using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PRUEBADIALOGO : MonoBehaviour
{
    public TextMeshProUGUI mostrarTexto;
    string[] oraciones = { "", "",};
    private int indice;
    public float velocidadTipeo;
    public bool estaHablando = false;
    public bool matarRutina = false;
    public GameObject desactivador;

    private SelectorPersonaje cambiarTexto;
    
    // Start is called before the first frame update
    void Start()
    {   
      
        cambiarTexto = GameObject.Find("ContenedorVariables").GetComponent<SelectorPersonaje>(); //como cada personaje va a decir su frase, necesito saber que eligio el jugador antes
        if (cambiarTexto.seleccionoUno == true )
        {
            OracionesParaBarb(); 
        }
        if (cambiarTexto.seleccionoDos == true)
        {
            OracionesParaToscal();
        }
        if (cambiarTexto.seleccionoTres == true)
        {
            OracionesParaValena();
        }
        if (cambiarTexto.seleccionoCuatro == true)
        {
            OracionesParaCruzado();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (estaHablando == true & matarRutina == false) //el matar rutina solo esta para evitar que la rutina se repita todo el tiempo
        {
            StartCoroutine(Type());
            matarRutina = true;
        }
    }
    IEnumerator Type()
    {
        foreach(char letras in oraciones[indice].ToCharArray()) //esto es lo que hace que se "escriban" las letras y no aparezcan de una,devuelve letra por letra en las oraciones que escribi dependiendo de la velocidad que quiera
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
            StartCoroutine(Type());
        }
        else //una vez que se termino todo, mato la esfera de colision que activa el dialogo
        { 
            mostrarTexto.text = "";
            desactivador.GetComponent<PRUEBA>().DesactivarDialogo();
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
    }

    void OracionesParaBarb() //como cada personaje puede ser boss en cualquier escena, chequeo en que escena esta y contra quien se va a enfrentar
    {
        //Barb -> Toscal,Valena, Omel
        //Toscal -> Valena, Omel, Barb
        //Valena -> Omel, Barb, Toscal
        //Omel -> Barb, Toscal, Valena

        int estaEscena = SceneManager.GetActiveScene().buildIndex ;
        if (estaEscena == 2) //Toscal
        {
            oraciones[0] = "JAJAJAJAJAJAJAJAJA"; //intente varias formas de cambiar las oraciones pero hasta ahora esta es la que funciono bien.
            oraciones[1] = "EY FUNCIONA";
        }
        if (estaEscena == 3)// Valena
        {
            oraciones[0] = "kkkkkkkkkkkkkkk";
            oraciones[1] = "EY FUNCIONA";
        }
        if (estaEscena == 4) //Omel
        {
            oraciones[0] = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            oraciones[1] = "EY FUNCIONA";
        }
    }
    void OracionesParaToscal()
    {
        int estaEscena2 = SceneManager.GetActiveScene().buildIndex;
        if (estaEscena2 == 2)//Valena
        {
            oraciones[0] = "JAJAJAJAJAJAJAJAJA";
            oraciones[1] = "EY FUNCIONA";
        }
        if (estaEscena2 == 3)//Omel
        {
            oraciones[0] = "kkkkkkkkkkkkkkk";
            oraciones[1] = "EY FUNCIONA";
        }
        if (estaEscena2 == 4)//Barb
        {
            oraciones[0] = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            oraciones[1] = "EY FUNCIONA";
        }
    }
    void OracionesParaValena()
    {
        int estaEscena3 = SceneManager.GetActiveScene().buildIndex;
        if (estaEscena3 == 2)//Omel
        {
            oraciones[0] = "JAJAJAJAJAJAJCVCVCCVCVCVAJAJA";
            oraciones[1] = "EY FUNBBBBCIONA";
        }
        if (estaEscena3 == 3)//Barb
        {
            oraciones[0] = "kkkkkkkkkASDASDASDkkkkkk";
            oraciones[1] = "EY FUNCIOGGGGGGGGGNA";
        }
        if (estaEscena3 == 4)//Toscal
        {
            oraciones[0] = "AAAAAAAAAAAAAAAEEEEEEEEEEEEEAAAAAAAAAAAAAAAAAAAAAA";
            oraciones[1] = "EY FUNCIORRRRNA";
        }
    }
    void OracionesParaCruzado()
    {
        int estaEscena4 = SceneManager.GetActiveScene().buildIndex;
        if (estaEscena4 == 2)//Barb
        {
            oraciones[0] = "JAJAJAJAJAJAJAJAJAAAAAAAAAAAAAA";
            oraciones[1] = "EY FUASDASDNCIONA";
        }
        if (estaEscena4 == 3)//Toscal
        {
            oraciones[0] = "kkkkkkkkkkkkkNNNNNNNNNNNNNkk";
            oraciones[1] = "EY FUNCIOSADFFFFFFFFFNA";
        }
        if (estaEscena4 == 4)//Valena
        {
            oraciones[0] = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAFFFFFFFFFFAAAAAAAA";
            oraciones[1] = "EY FUNCICVVCBBONA";
        }
    }
   

   
}

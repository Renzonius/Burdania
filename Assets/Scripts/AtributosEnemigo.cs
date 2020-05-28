using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtributosEnemigo : MonoBehaviour
{
    public int vidaMaxima;
    int vidaAhora;
    public GameObject poder;
    // Start is called before the first frame update
    void Start() //no hay nada nuevo aca en el final pongo un desactivador de colisiones por las dudas y un cambio de escena simple, podemos probar metiendo transiciones con el animator.
    {
        vidaAhora = vidaMaxima;
    }

    public void RecibirDaño(int daño)
    {
        vidaAhora -= daño;


        if (vidaAhora <= 0)
        {
            Morir();
        }
    }
    void Morir()
    {
        Destroy(poder);
        GetComponent<Collider>().enabled = false;
        int siguienteEscena = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(siguienteEscena);
    }
}

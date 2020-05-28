using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDash : MonoBehaviour
{
    //COMENTAR
    public Vector3 direccionDash;

    public float tiempoCooldown = 1; 
    private float siguienteDash = 0;

    public const float tiempoMaximoDash = 1.0f;
    public float distanciaDash = 10;
    public float velocidadFrenadaDash = 0.1f;
    float tiempoDashAhora = tiempoMaximoDash;
    float velocidadDash = 6; //

    public CharacterController jugador;



    private void Componente()
    {
        jugador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetButtonDown("Fire2") & jugador.isGrounded & Time.time > siguienteDash)
        {
            tiempoDashAhora = 0;
            siguienteDash = Time.time + tiempoCooldown;
        }
        if (tiempoDashAhora < tiempoMaximoDash)
        {
            direccionDash = transform.forward * distanciaDash;
            tiempoDashAhora += velocidadFrenadaDash;
        }
        else
        {
            direccionDash = Vector3.zero;
            
        }
        jugador.Move(direccionDash * Time.deltaTime * velocidadDash); 
    
    }
}


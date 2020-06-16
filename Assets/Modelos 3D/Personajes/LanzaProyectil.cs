using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaProyectil : MonoBehaviour
{
    Rigidbody rigidRef;

    public float angulo_vuelo;
    public float velocidadAngular;

    public float daño = 2.5f;

    void Start()
    {
        rigidRef = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        TrayectoDeLanza();
    }

    void TrayectoDeLanza()
    {
        rigidRef.AddRelativeForce(Vector3.forward * 15f * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Dragon")
        {
            Destroy(gameObject);
        }

    }
}

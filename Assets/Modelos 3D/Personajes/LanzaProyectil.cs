using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaProyectil : MonoBehaviour
{
    Rigidbody rigidRef;

    public float velocidad;

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
        rigidRef.AddRelativeForce(Vector3.forward * velocidad * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Dragon":
                {
                    Destroy(gameObject);
                    break;
                }
            case "Muro":
                {
                    rigidRef.velocity = Vector3.zero;
                    Destroy(gameObject, 5f);
                    break;
                }
            case "Goblin":
                {
                    Destroy(gameObject);
                    break;
                }
        }
        //if (col.gameObject.tag == "Dragon")
        //{
        //    Destroy(gameObject);
        //}

    }
}

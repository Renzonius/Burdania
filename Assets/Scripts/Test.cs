using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Vector3 posicion;
    public GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {
        posicion = objeto.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posicion.x = posicion.x + 1 * Time.deltaTime;
        objeto.transform.position = posicion;
        Debug.Log(posicion);
    }
}

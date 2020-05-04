using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraAlHombro : MonoBehaviour
{
    public Vector3 posCamara;
    public Transform objetivo;
    [Range(0, 1)] public float deslisamiento;
    public float sensibilidad;
    void Start()
    {
        objetivo = GameObject.FindGameObjectWithTag("Jugador").transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, objetivo.position + posCamara, deslisamiento);
        //transform.LookAt(objetivo);
        posCamara = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * posCamara;
    }
}

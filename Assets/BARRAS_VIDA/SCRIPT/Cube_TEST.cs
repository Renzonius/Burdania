using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_TEST : MonoBehaviour
{
    public float life = 100f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
         if ( Input.GetKeyDown ( KeyCode.Space ))
        {
            life -= 5;
            Vida_barra.Heath = life;

        }
        
    }
}

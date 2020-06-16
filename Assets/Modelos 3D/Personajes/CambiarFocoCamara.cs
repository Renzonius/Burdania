using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CambiarFocoCamara : MonoBehaviour
{
    public Transform dragonObj;
    CinemachineFreeLook foco;
    public Transform focoJugador;
    public Transform PersecucionFoco;
    public Transform mainCamara;

    void Start()
    {
        dragonObj = GameObject.FindGameObjectWithTag("Dragon").transform;
        focoJugador = GameObject.FindGameObjectWithTag("CamaraJugador").transform;
        foco = gameObject.GetComponent<CinemachineFreeLook>();
        //PersecucionFoco = GameObject.FindGameObjectWithTag("FocoPersecucion").transform;
        mainCamara = GameObject.FindGameObjectWithTag("CamaraPrincipal").transform;
    }

    private void Update()
    {
    }
    
    public void PersecucionCambiarFoco(bool muroFuegoActivado)
    {
        if(muroFuegoActivado == true)
        {
            foco.LookAt = PersecucionFoco;
            foco.m_Orbits[1].m_Radius = 7f;
            foco.m_XAxis.m_InputAxisName = "";
        }
        else
        {
            foco.LookAt = focoJugador;
            foco.m_Orbits[1].m_Radius = 3f;
            foco.m_XAxis.m_InputAxisName = "Mouse X";
        }
    }
    public void CambiarFocoPrimerCombate(bool drakanHuyo)
    {
        if (drakanHuyo == false)
        {
            //Enfoca a Drakan
            foco.LookAt = dragonObj;
            foco.m_Orbits[1].m_Radius = 5f;
            foco.m_XAxis.m_InputAxisName = "";
        }
        else
        {
            //Enfoca al Jugador
            foco.LookAt = focoJugador;
            foco.m_Orbits[1].m_Radius = 3f;
            foco.m_XAxis.m_InputAxisName = "Mouse X";
        }
    }
}

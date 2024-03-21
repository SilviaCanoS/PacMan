using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public Puntaciones puntaciones;

    void Start()
    {
        if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil)
            this.gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Escenario", "Jugador", 
                "Radar");
        else
            this.gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Jugador", "Radar");
    }
}

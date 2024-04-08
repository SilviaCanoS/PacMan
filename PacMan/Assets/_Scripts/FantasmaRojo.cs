using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaRojo : Fantasma
{
    public float referenciaPuntos, puntosRestantes;
    public Transform puntos;
    public bool aumentarVelocidad = true;

    private void Awake()
    {
        if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil) rangoAlerta = 3;
        else if (puntaciones.nivelDificultad == Puntaciones.Dificultad.normal) rangoAlerta = 5;
        else rangoAlerta = 8f;
        coordenadaX = -2f;

        puntos = GameObject.Find("Puntos").transform;
        referenciaPuntos = puntos.childCount / 2;
    }

    private void FixedUpdate()
    {
        puntosRestantes = puntos.childCount;
        if (puntosRestantes < referenciaPuntos)
        {
            if (aumentarVelocidad)
            {
                nav.speed += 1;
                aumentarVelocidad = false;
            }
        }
    }
}

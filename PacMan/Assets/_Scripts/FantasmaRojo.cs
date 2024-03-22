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

    private void Awake()
    {
        rangoAlerta = 5f;
        coordenadaX = -2f;

        puntos = GameObject.Find("Puntos").transform;
        referenciaPuntos = puntos.childCount / 2;
    }

    private void FixedUpdate()
    {
        puntosRestantes = puntos.childCount;
        if (puntosRestantes < referenciaPuntos) nav.speed += 1;
    }
}

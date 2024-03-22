using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaAzul : Fantasma
{
    private void Awake()
    {
        if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil) rangoAlerta = 5;
        else if (puntaciones.nivelDificultad == Puntaciones.Dificultad.normal) rangoAlerta = 10;
        else rangoAlerta = 15f;
        coordenadaX = 0.7f;
    }
}

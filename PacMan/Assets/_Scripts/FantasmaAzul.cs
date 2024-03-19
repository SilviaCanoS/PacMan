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
        rangoAlerta = 10f;
        coordenadaX = 0.7f;
    }
}

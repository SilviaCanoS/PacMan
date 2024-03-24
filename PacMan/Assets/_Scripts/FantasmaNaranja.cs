using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaNaranja : Fantasma
{

    private void Awake()
    {
        rangoAlerta = 0;
        coordenadaX = 2f;
    }
    
    void Update()
    {
        if (nav.remainingDistance < .5f) SiguientePunto();

        if (puntaciones.efectoAzul)
            GetComponent<NavMeshAgent>().destination = new Vector3(coordenadaX, 0, 0.9f);
        
        if (puntaciones.congelar)
            GetComponent<NavMeshAgent>().destination = gameObject.transform.position;
    }
}

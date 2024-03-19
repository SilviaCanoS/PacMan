using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaRosa : Fantasma
{
    void Update()
    {
        if (nav.remainingDistance < .5f) SiguientePunto();
        if (!puntaciones.efectoAzul) GetComponent<NavMeshAgent>().SetDestination(jugador.position);
    }
}

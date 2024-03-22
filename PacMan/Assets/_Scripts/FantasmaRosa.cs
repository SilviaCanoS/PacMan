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
        if (puntaciones.efectoAzul) GetComponent<NavMeshAgent>().destination = new Vector3(-0.7f, 0, 0.9f);
        else GetComponent<NavMeshAgent>().destination = jugador.position;
    }
}

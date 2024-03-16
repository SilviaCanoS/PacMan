using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaRosa : MonoBehaviour
{
    public Transform jugador;

    private void Start()
    {
        jugador = GameObject.Find("PacMan").transform;
    }

    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(jugador.position);
    }
}

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal Derecho"))
        {
            gameObject.transform.position = new Vector3(-23.5f, 0, 1f);
        }

        else if (other.CompareTag("Portal Izquierdo"))
        {
            gameObject.transform.position = new Vector3(23.5f, 0, 1f);
        }
    }
}

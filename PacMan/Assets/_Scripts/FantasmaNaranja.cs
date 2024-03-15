using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaNaranja : MonoBehaviour
{
    public GameObject puntos;
    public int hijos;
    System.Random aleatorio = new System.Random();
    public float rangoAlerta = 2f, velocidad = 3f;
    bool alerta;
    public LayerMask capaPuntos;

    private void Start()
    {
        puntos = GameObject.Find("Puntos");
        hijos = puntos.transform.childCount;
        var buscar = puntos.transform.GetChild(aleatorio.Next(hijos));
        GetComponent<NavMeshAgent>().SetDestination(buscar.transform.position);
    }

    void Update()
    {
        alerta = Physics.CheckSphere(transform.position, rangoAlerta, capaPuntos); //detecta si esta cerca
        if (alerta)
        {
            var buscar = puntos.transform.GetChild(aleatorio.Next(hijos));
            GetComponent<NavMeshAgent>().SetDestination(buscar.transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta); //dibuja la esfera de alerta
    }
}

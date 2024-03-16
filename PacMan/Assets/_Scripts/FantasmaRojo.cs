using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaRojo : MonoBehaviour
{
    public Transform[] control;
    int puntoDestino = 0;
    NavMeshAgent nav;
    System.Random random = new System.Random();

    public float rangoAlerta = 5f, referenciaPuntos, puntosRestantes;
    public Transform jugador, puntos;
    public LayerMask capaJugador;
    bool alerta;

    private void Start()
    {
        puntos = GameObject.Find("Puntos").transform;
        referenciaPuntos = puntos.childCount / 2;

        Transform aux = GameObject.Find("Control").transform;
        control = new Transform[aux.childCount];
        for (int i = 0; i < control.Length; i++) control[i] = aux.GetChild(i).transform;
        control = control.OrderBy(x => random.Next()).ToArray(); //desordena el arreglo

        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;
        SiguientePunto();

        jugador = GameObject.Find("PacMan").transform;
    }

    void Update()
    {
        puntosRestantes = puntos.childCount;
        if (puntosRestantes < referenciaPuntos) nav.speed = 6;

        if (nav.remainingDistance < .5f) SiguientePunto();

        //detecta si pacman esta cerca
        alerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);
        if (alerta) nav.destination = jugador.position;
    }

    void SiguientePunto()
    {
        nav.destination = control[puntoDestino].position;
        puntoDestino = (puntoDestino + 1) % control.Length;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta); //dibuja la esfera de alerta
    }
}

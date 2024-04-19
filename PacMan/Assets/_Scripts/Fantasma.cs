using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Fantasma : MonoBehaviour
{
    public Transform[] control;
    public int puntoDestino = 0;
    public NavMeshAgent nav;
    public System.Random random = new System.Random();

    public float rangoAlerta;
    public Transform jugador;
    public LayerMask capaJugador;
    public bool alerta;

    public Puntaciones puntaciones;
    public float coordenadaX;

    public Material azulMarino, color;

    private void Start()
    {
        Transform aux = GameObject.Find("Control").transform;
        control = new Transform[aux.childCount];
        for (int i = 0; i < control.Length; i++) control[i] = aux.GetChild(i).transform;
        control = control.OrderBy(x => random.Next()).ToArray(); //desordena el arreglo

        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;
        SiguientePunto();

        if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil) nav.speed = 1;
        else if (puntaciones.nivelDificultad == Puntaciones.Dificultad.normal) nav.speed = 1.5f;
        else nav.speed = 2;

        jugador = GameObject.Find("PacMan").transform;
    }

    void Update()
    {
        if (nav.remainingDistance < .5f) SiguientePunto();

        if (puntaciones.efectoAzul)
        {
            GetComponent<NavMeshAgent>().destination = new Vector3(coordenadaX, -1.24f, 0.9f);

            var aux = gameObject.transform.GetChild(4);
            aux.GetComponent<MeshRenderer>().material = azulMarino;
            aux = gameObject.transform.GetChild(5); //indicador
            aux.GetComponent<MeshRenderer>().material = azulMarino;

            Invoke("DevolverColor", 10);
        }
        else if(puntaciones.congelar) 
            GetComponent<NavMeshAgent>().destination = gameObject.transform.position;
        else
        {
            //detecta si pacman esta cerca
            alerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);
            if (alerta) nav.destination = jugador.position;
        }
    }

    public void SiguientePunto()
    {
        nav.destination = control[puntoDestino].position;
        puntoDestino = (puntoDestino + 1) % control.Length;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta); //dibuja la esfera de alerta
    }

    public void DevolverColor()
    {
        var aux = gameObject.transform.GetChild(4);
        aux.GetComponent<MeshRenderer>().material = color;
        aux = gameObject.transform.GetChild(5);//indicador
        aux.GetComponent<MeshRenderer>().material = color;
    }
}

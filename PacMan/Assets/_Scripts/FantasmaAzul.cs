using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaAzul : MonoBehaviour
{
    public float rangoAlerta = 10f, velocidad = 3f;
    public LayerMask capaJugador;
    bool alerta;
    public Transform jugador;

    public GameObject puntos;
    public int hijos;
    System.Random aleatorio = new System.Random();

    private void Start()
    {
        jugador = GameObject.Find("PacMan").transform;

        puntos = GameObject.Find("Puntos");
        hijos = puntos.transform.childCount;
    }

    void Update()
    {
        //detecta si pacman esta cerca
        alerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);
        if (alerta)
        {
            Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posJugador); //mira al jugador
            transform.position = Vector3.MoveTowards(transform.position, posJugador,
                velocidad * Time.deltaTime); //Sigue al jugador
        }
        else
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

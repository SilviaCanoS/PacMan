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

    private void Start()
    {
        jugador = GameObject.Find("PacMan").transform;
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta); //dibuja la esfera de alerta
    }
}

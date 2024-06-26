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

        if (puntaciones.efectoAzul)
        {
            GetComponent<NavMeshAgent>().destination = new Vector3(-0.7f, .25f, 0.9f);

            var aux = gameObject.transform.GetChild(4);
            aux.GetComponent<MeshRenderer>().material = azulMarino;
            aux = gameObject.transform.GetChild(5);
            aux.GetComponent<MeshRenderer>().material = azulMarino;

            Invoke("DevolverColor", 10);
        }
        else if (puntaciones.congelar) 
            GetComponent<NavMeshAgent>().destination = gameObject.transform.position;
        else GetComponent<NavMeshAgent>().destination = jugador.position;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaNaranja : Fantasma
{

    private void Awake()
    {
        rangoAlerta = 0;
    }
    
    void Update()
    {
        if (nav.remainingDistance < .5f) SiguientePunto();

        if (puntaciones.efectoAzul)
        {
            GetComponent<NavMeshAgent>().destination = new Vector3(2, 0, 0.9f);

            var aux = gameObject.transform.GetChild(0);
            aux.GetComponent<MeshRenderer>().material = azulMarino;
            aux = gameObject.transform.GetChild(1);
            aux.GetComponent<MeshRenderer>().material = azulMarino;

            Invoke("DevolverColor", 10);
        }
        
        if (puntaciones.congelar)
            GetComponent<NavMeshAgent>().destination = gameObject.transform.position;
    }
}

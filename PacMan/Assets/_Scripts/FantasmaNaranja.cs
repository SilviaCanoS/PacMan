using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FantasmaNaranja : Fantasma
{
    private void Start()
    {
        rangoAlerta = 0;

        Transform aux = GameObject.Find("Control").transform;
        control = new Transform[aux.childCount];
        for(int i=0; i<control.Length; i++) control[i] = aux.GetChild(i).transform;
        control = control.OrderBy(x => random.Next()).ToArray(); //desordena el arreglo

        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;
        SiguientePunto();
    }

    void Update()
    {
        if (nav.remainingDistance < .5f) SiguientePunto();
    }
}

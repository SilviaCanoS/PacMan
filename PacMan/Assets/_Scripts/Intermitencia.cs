using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermitencia : MonoBehaviour
{
    public int hijo;
    GameObject aux;
    public Puntaciones puntaciones;

    void Start()
    {
        aux = gameObject.transform.GetChild(hijo).gameObject;
        if(puntaciones.nivelDificultad == Puntaciones.Dificultad.dificil) Invoke("Mostrar", 2);
    }

    public void Mostrar()
    {
        aux.SetActive(true);
        Invoke("Ocultar", 2);
    }

    public void Ocultar()
    {
        aux.SetActive(false);
        Invoke("Mostrar", 2);
    }
}

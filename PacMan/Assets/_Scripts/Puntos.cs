using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class Puntos : MonoBehaviour
{
    public Transform[] puntos;
    public System.Random random = new System.Random();
    public Material verde, blanco;

    void Start()
    {
        puntos = new Transform[gameObject.transform.childCount];
        for (int i = 0; i < puntos.Length; i++) puntos[i] = gameObject.transform.GetChild(i).transform;
        puntos = puntos.OrderBy(x => random.Next()).ToArray(); //desordena el arreglo

        for (int i = 0; i < 5; i++) 
        {
            puntos[i].transform.localScale = new Vector3(1, 1, 1);
            puntos[i].GetComponent<MeshRenderer>().material = verde;
            puntos[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = verde;
            puntos[i].gameObject.tag = "PuntoVere";
        }
        Invoke("Tranquilo", Random.Range(1, 11));
    }

    public void Tranquilo()
    {
        if (puntos.Length >= 5) Cambiar(5, blanco, "Punto");
        else Cambiar(puntos.Length, blanco, "Punto");

        Invoke("Peligroso", Random.Range(1, 11));
    }

    public void Peligroso()
    {
        puntos = new Transform[gameObject.transform.childCount];
        for (int i = 0; i < puntos.Length; i++) puntos[i] = gameObject.transform.GetChild(i).transform;
        puntos = puntos.OrderBy(x => random.Next()).ToArray(); //desordena el arreglo

        if (puntos.Length >= 5) Cambiar(5, verde, "PuntoVere");
        
        Invoke("Tranquilo", Random.Range(1, 11));
    }

    public void Cambiar(int numero, Material color, string tag)
    {
        for (int i = 0; i < numero; i++)
        {
            if (puntos[i] != null)
            {
                puntos[i].transform.localScale = new Vector3(.4f, .4f, .4f);
                puntos[i].GetComponent<MeshRenderer>().material = color;
                puntos[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = color;
                puntos[i].gameObject.tag = tag;
            }

        }
    }
}

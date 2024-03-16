using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmasSpawner : MonoBehaviour
{
    public GameObject rojo, prefabRojo, rosa, prefabRosa, azul, prefabAzul, naranja, prefabNaranja;
    public PacMan pacMan;
    public Material azulMarino;

    private void Start()
    {
        rojo = GameObject.Find("Fantasma Rojo");
        rosa = GameObject.Find("Fantasma Rosa");
        azul = GameObject.Find("Fantasma Azul");
        naranja = GameObject.Find("Fantasma Naranja");
    }

    private void Update()
    {
        if (rojo == null)
        {
            rojo = Instantiate<GameObject>(prefabRojo, transform.position, Quaternion.identity);
            if (pacMan.efectoAzulActivado) EfectoAzul("Rojo");
        }

        if (rosa == null)
        {
            rosa = Instantiate<GameObject>(prefabRosa, transform.position, Quaternion.identity);
            if (pacMan.efectoAzulActivado) EfectoAzul("Rosa");
        }

        if (azul == null)
        {
            azul = Instantiate<GameObject>(prefabAzul, transform.position, Quaternion.identity);
            if (pacMan.efectoAzulActivado) EfectoAzul("Azul");
        }

        if (naranja == null)
        {
            naranja = Instantiate<GameObject>(prefabNaranja, transform.position, Quaternion.identity);
            if (pacMan.efectoAzulActivado) EfectoAzul("Naranja");
        }
    }

    public void EfectoAzul(string colores)
    {
        var aux = GameObject.FindGameObjectWithTag(colores).transform.GetChild(0);
        aux.GetComponent<MeshRenderer>().material = azulMarino;
        aux = GameObject.FindGameObjectWithTag(colores).transform.GetChild(1);
        aux.GetComponent<MeshRenderer>().material = azulMarino;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmasSpawner : MonoBehaviour
{
    public GameObject rojo, prefabRojo, rosa, prefabRosa, azul, prefabAzul, naranja, prefabNaranja;

    private void Update()
    {
        rojo = GameObject.Find("Fantasma Rojo");
        if (rojo == null)
        {
            Instantiate<GameObject>(prefabRojo, transform.position, Quaternion.identity);
        }

        rosa = GameObject.Find("Fantasma Rosa");
        if (rosa == null)
        {
            Instantiate<GameObject>(prefabRosa, transform.position, Quaternion.identity);
        }

        azul = GameObject.Find("Fantasma Azul");
        if (azul == null)
        {
            Instantiate<GameObject>(prefabAzul, transform.position, Quaternion.identity);
        }

        naranja = GameObject.Find("Fantasma Naranja");
        if (naranja == null)
        {
            Instantiate<GameObject>(prefabNaranja, transform.position, Quaternion.identity);
        }
    }
}

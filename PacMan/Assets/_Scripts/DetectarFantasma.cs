using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectarFantasma : MonoBehaviour
{
    public bool radar;
    public LayerMask capaJugador;

    void Update()
    {
        radar = Physics.CheckSphere(transform.position, 10f, capaJugador);
        if (radar) this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        else this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}

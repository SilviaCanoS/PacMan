using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public bool alerta;
    public LayerMask capaEnemigos;
    public GameObject sonidoFantasma;
    public AudioSource sourceFantasma;

    void Start()
    {
        sonidoFantasma = GameObject.Find("Fantasmas");
        sourceFantasma = sonidoFantasma.GetComponent<AudioSource>();
    }

    void Update()
    {
        alerta = Physics.CheckSphere(transform.position, 10, capaEnemigos);
        if (alerta && !sourceFantasma.isPlaying) sourceFantasma.Play();
        if (!alerta && sourceFantasma.isPlaying) sourceFantasma.Stop();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10); //dibuja la esfera de alerta
    }
}

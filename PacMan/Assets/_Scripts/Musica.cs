using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Musica : MonoBehaviour
{
    public bool alerta;
    public LayerMask capaEnemigos;
    public GameObject sonidoFantasma;
    public AudioSource sourceFantasma;
    public PostProcessVolume postProcess;
    Grain grain;

    void Start()
    {
        sonidoFantasma = GameObject.Find("Fantasmas");
        sourceFantasma = sonidoFantasma.GetComponent<AudioSource>();
        postProcess = gameObject.transform.GetChild(0).GetComponentInChildren<PostProcessVolume>();
        postProcess.profile.TryGetSettings(out grain);
    }

    void Update()
    {
        alerta = Physics.CheckSphere(transform.position, 10, capaEnemigos);
        if (alerta && !sourceFantasma.isPlaying)
        {
            sourceFantasma.Play();
            grain.active = true;
        }
        if (!alerta && sourceFantasma.isPlaying)
        {
            sourceFantasma.Stop();
            grain.active = false;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10); //dibuja la esfera de alerta
    }
}

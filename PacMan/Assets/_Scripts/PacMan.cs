using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    new Rigidbody rigidbody;
    Vector2 inputMov, inputRot;
    float caminar = 10f, sensibilidadMouse = 1f, rotacionX;
    Transform camara;

    public AudioClip comerPuntos;
    GameObject sonidoComerPuntos;
    AudioSource sourceComerPuntos;

    public int puntuacion = 0;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        camara = transform.GetChild(0); //Toma al primer hijo
        rotacionX = camara.eulerAngles.x;

        sonidoComerPuntos = GameObject.Find("ComerPunto");
        sourceComerPuntos = sonidoComerPuntos.GetComponent<AudioSource>();
    }

    private void Update()
    {
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        inputRot.x = Input.GetAxis("Mouse X") * sensibilidadMouse;
        inputRot.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * caminar * inputMov.y //Avanzar adelante y atras
                                + transform.right * caminar * inputMov.x; //Avanzar izquierda y derecha

        transform.rotation *= Quaternion.Euler(0, inputRot.x, 0); //Camara izquiera y derecha

        //rotacionX -= inputRot.y;
        //rotacionX = Mathf.Clamp(rotacionX, -50f, 50f);
        //camara.localRotation = Quaternion.Euler(rotacionX, 0, 0); //Camara arriba y abajo
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Punto")) 
        {
            sourceComerPuntos.Play();
            puntuacion += 10;
            Destroy(other.gameObject);
        }

        else if(other.CompareTag("Portal Derecho"))
        {
            gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);
        }

        else if (other.CompareTag("Portal Izquierdo"))
        {
            gameObject.transform.position = new Vector3(23.5f, -0.5f, 1f);
        }

    }
}

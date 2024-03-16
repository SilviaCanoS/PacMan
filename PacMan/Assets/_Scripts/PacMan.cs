using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PacMan : MonoBehaviour
{
    new Rigidbody rigidbody;
    Vector2 inputMov, inputRot;
    float caminar = 10f, sensibilidadMouse = 1f, rotacionX;
    Transform camara;

    public AudioClip comerPuntos, iniciarJuego, pacManMuere, efectoAzul, comeFantasma;
    GameObject sonidoComerPuntos, sonidoIniciarJuego, sonidoPacManMuere, sonidoEfectoAzul, sonidoComeFantasma;
    AudioSource sourceComerPuntos, sourceIniciarJuego, sourcePacManMuere, sourceEfectoAzul, sourceComeFantasma;

    public int puntuacion = 0, vidas = 2;
    public Transform transformPuntuacion;
    public TMPro.TMP_Text textPuntuacion;
    public Puntaciones puntaciones;

    public GameObject vida1, vida2, vida3;

    public Material azulMarino, rojo, rosa, azul, naranja;
    public bool efectoAzulActivado;

    private void Start()
    {
        transformPuntuacion = GameObject.Find("TextPuntuacion").transform;
        textPuntuacion = transformPuntuacion.GetComponent<TMPro.TMP_Text>();
        //puntaciones.Cargar();

        rigidbody = GetComponent<Rigidbody>();
        camara = transform.GetChild(0); //Toma al primer hijo
        rotacionX = camara.eulerAngles.x;

        sonidoComerPuntos = GameObject.Find("ComerPunto");
        sourceComerPuntos = sonidoComerPuntos.GetComponent<AudioSource>();
        sonidoIniciarJuego = GameObject.Find("iniciarJuego");
        sourceIniciarJuego = sonidoIniciarJuego.GetComponent<AudioSource>();
        sourceIniciarJuego.Play();
        vida1.GetComponent<Image>().color = Color.black;
        sonidoPacManMuere = GameObject.Find("PacManMuere");
        sourcePacManMuere = sonidoPacManMuere.GetComponent<AudioSource>();
        sonidoEfectoAzul = GameObject.Find("EfectoAzul");
        sourceEfectoAzul = sonidoEfectoAzul.GetComponent<AudioSource>();
        sonidoComeFantasma = GameObject.Find("ComeFantasma");
        sourceComeFantasma = sonidoComeFantasma.GetComponent<AudioSource>();
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
        if (other.CompareTag("Punto"))
        {
            sourceComerPuntos.Play();
            puntuacion += 10;
            CambiarPuntuacion();

            if (other.transform.localScale.x == 1)
            {
                puntuacion += 10;
                CambiarPuntuacion();
                efectoAzulActivado = true;
                sourceEfectoAzul.Play();
                var aux = GameObject.FindGameObjectWithTag("Rojo").transform.GetChild(0);
                aux.GetComponent<MeshRenderer>().material = azulMarino;
                aux = GameObject.FindGameObjectWithTag("Rojo").transform.GetChild(1);
                aux.GetComponent<MeshRenderer>().material = azulMarino;

                aux = GameObject.FindGameObjectWithTag("Rosa").transform.GetChild(0);
                aux.GetComponent<MeshRenderer>().material = azulMarino;
                aux = GameObject.FindGameObjectWithTag("Rosa").transform.GetChild(1);
                aux.GetComponent<MeshRenderer>().material = azulMarino;

                aux = GameObject.FindGameObjectWithTag("Azul").transform.GetChild(0);
                aux.GetComponent<MeshRenderer>().material = azulMarino;
                aux = GameObject.FindGameObjectWithTag("Azul").transform.GetChild(1);
                aux.GetComponent<MeshRenderer>().material = azulMarino;

                aux = GameObject.FindGameObjectWithTag("Naranja").transform.GetChild(0);
                aux.GetComponent<MeshRenderer>().material = azulMarino;
                aux = GameObject.FindGameObjectWithTag("Naranja").transform.GetChild(1);
                aux.GetComponent<MeshRenderer>().material = azulMarino;

                Invoke("DevolverColor", 10);
            }
            //puntaciones.Guardar();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Rojo") || other.CompareTag("Rosa") || other.CompareTag("Azul") 
            || other.CompareTag("Naranja"))
        {
            if(efectoAzulActivado)
            {
                sourceComeFantasma.Play();
                puntuacion += 200;
                CambiarPuntuacion();
                Destroy(other.gameObject);
            }
            else
            {
                sourcePacManMuere.Play();
                if (vidas == 2) vida2.GetComponent<Image>().color = Color.black;
                if (vidas == 1)
                {
                    vida3.GetComponent<Image>().color = Color.black;
                    int escenaActual = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(escenaActual);
                }
                vidas--;
                sourceIniciarJuego.Play();
                gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);
            }
        }

        else if(other.CompareTag("Portal Derecho"))
            gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);

        else if (other.CompareTag("Portal Izquierdo"))
            gameObject.transform.position = new Vector3(23.5f, -0.5f, 1f);
    }

    public void DevolverColor()
    {
        var aux = GameObject.FindGameObjectWithTag("Rojo").transform.GetChild(0);
        aux.GetComponent<MeshRenderer>().material = rojo;
        aux = GameObject.FindGameObjectWithTag("Rojo").transform.GetChild(1);
        aux.GetComponent<MeshRenderer>().material = rojo;

        aux = GameObject.FindGameObjectWithTag("Rosa").transform.GetChild(0);
        aux.GetComponent<MeshRenderer>().material = rosa;
        aux = GameObject.FindGameObjectWithTag("Rosa").transform.GetChild(1);
        aux.GetComponent<MeshRenderer>().material = rosa;

        aux = GameObject.FindGameObjectWithTag("Azul").transform.GetChild(0);
        aux.GetComponent<MeshRenderer>().material = azul;
        aux = GameObject.FindGameObjectWithTag("Azul").transform.GetChild(1);
        aux.GetComponent<MeshRenderer>().material = azul;

        aux = GameObject.FindGameObjectWithTag("Naranja").transform.GetChild(0);
        aux.GetComponent<MeshRenderer>().material = naranja;
        aux = GameObject.FindGameObjectWithTag("Naranja").transform.GetChild(1);
        aux.GetComponent<MeshRenderer>().material = naranja;
        sourceEfectoAzul.Stop();
        efectoAzulActivado = false;
    }

    public void CambiarPuntuacion()
    {
        if (puntuacion > puntaciones.puntos[5])
        {
            puntaciones.puntos[5] = puntuacion;
            puntaciones.nombres[5] = puntaciones.nombreActual;
        }
        textPuntuacion.text = puntuacion.ToString();
    }
}

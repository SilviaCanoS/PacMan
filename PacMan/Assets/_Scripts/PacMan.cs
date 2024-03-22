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
    float caminar = 15f, sensibilidadMouse = 5f, rotacionX;
    Transform camara;

    GameObject sonidoComerPuntos, sonidoIniciarJuego, sonidoPacManMuere, sonidoEfectoAzul, sonidoComeFantasma,
        sonidoPerder, sonidoGanar;
    AudioSource sourceComerPuntos, sourceIniciarJuego, sourcePacManMuere, sourceEfectoAzul, 
        sourceComeFantasma, sourcePerder, sourceGanar;

    public int puntuacion = 0, vidas = 2, ref1up = 1000;
    public Transform transformPuntuacion;
    public TMPro.TMP_Text textPuntuacion;
    public Puntaciones puntaciones;

    public GameObject vida1, vida2, vida3, vida4, vida5, canvasPerder;

    public Material azulMarino, rojo, rosa, azul, naranja;
    public bool efectoAzulActivado;

    public Transform puntos;

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
        sonidoPerder = GameObject.Find("Perder");
        sourcePerder = sonidoPerder.GetComponent<AudioSource>();
        sonidoGanar = GameObject.Find("Ganar");
        sourceGanar = sonidoGanar.GetComponent<AudioSource>();

        puntos = GameObject.Find("Puntos").transform;
    }

    private void Update()
    {
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        inputRot.x = Input.GetAxis("Horizontal") * sensibilidadMouse;
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

            if(other.transform.localScale.x == .4f)
            {
                puntuacion -= 100;
                CambiarPuntuacion();
            }

            if (other.transform.localScale.x == 1)
            {
                puntuacion += 10;
                CambiarPuntuacion();
                efectoAzulActivado = true;
                puntaciones.efectoAzul = true;
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

            if (puntos.childCount == 1)
            {
                sourceGanar.Play();
                int escenaActual = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(escenaActual + 1);
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
                switch (vidas)
                {
                    case 4: 
                        sourcePacManMuere.Play();
                        vida5.SetActive(false);
                        vida4.GetComponent<Image>().color = Color.black;
                        vidas--;
                        sourceIniciarJuego.Play();
                        gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);
                        break;
                    case 3:
                        sourcePacManMuere.Play();
                        vida4.SetActive(false);
                        vida1.GetComponent<Image>().color = Color.black;
                        vidas--;
                        sourceIniciarJuego.Play();
                        gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);
                        break;
                    case 2:
                        sourcePacManMuere.Play();
                        vida1.GetComponent<Image>().color = Color.black;
                        vidas--;
                        sourceIniciarJuego.Play();
                        gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);
                        break;
                    case 1:
                        sourcePacManMuere.Play();
                        vida2.GetComponent<Image>().color = Color.black;
                        vidas--;
                        sourceIniciarJuego.Play();
                        gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);
                        break;
                    case 0:
                        vida3.GetComponent<Image>().color = Color.black;
                        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        canvasPerder.SetActive(true);
                        sourcePerder.Play();
                        Invoke("Reiniciar", 3);
                        break; 
                }
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
        puntaciones.efectoAzul = false;
    }

    public void CambiarPuntuacion()
    {
        puntaciones.puntacionActual = puntuacion;
        textPuntuacion.text = puntuacion.ToString();

        //Consigue 1up cada 1000 puntos
        if (puntaciones.puntacionActual >= ref1up) 
        {
            
            if (vidas < 4) vidas++;
            switch (vidas)
            {
                case 2: vida2.GetComponent<Image>().color = Color.white; break;
                case 3: 
                    vida1.GetComponent<Image>().color = Color.white;
                    vida4.SetActive(true);
                    vida4.GetComponent<Image>().color = Color.black;
                    break;
                case 4:
                    vida4.GetComponent<Image>().color = Color.white;
                    vida5.SetActive(true); break;
            }
        }
        ref1up += 1000;
    }

    public void Reiniciar()
    {
        if (puntaciones.puntacionActual > puntaciones.puntos[5])
        {
            puntaciones.puntos[5] = puntaciones.puntacionActual;
            puntaciones.nombres[5] = puntaciones.nombreActual;
        }
        puntaciones.puntacionActual = 0;
        SceneManager.LoadScene(0);
    }
}

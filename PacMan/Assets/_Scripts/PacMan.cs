using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**Esta clase controla a PacMan, que es a quien controla el jugador
 */
public class PacMan : MonoBehaviour
{
    Rigidbody rigidbody;
    Vector2 inputMov, inputRot;
    float caminar = 15f, sensibilidadMouse = 2.55f, rotacionX;
    Transform camara;

    GameObject sonidoComerPuntos, sonidoIniciarJuego, sonidoPacManMuere, sonidoEfectoAzul, sonidoComeFantasma,
        sonidoGanar, sonidoFruta, sonidoPerder;
    AudioSource sourceComerPuntos, sourceIniciarJuego, sourcePacManMuere, sourceEfectoAzul,
        sourceComeFantasma, sourceGanar, sourceFruta, sourcePerder;

    public int puntuacion = 0, vidas = 2, ref1up = 1000;
    public Transform transformPuntuacion;
    public TMPro.TMP_Text textPuntuacion;
    public Puntaciones puntaciones;

    public GameObject vida1, vida2, vida3, vida4, vida5, canvasGanar, cerezaPrefab, cereza, fresaPrefab,
        fresa, manzanaPrefab, manzana, mandarinaPrefab, mandarina;

    public bool efectoAzulActivado;

    public Transform puntos, control;

    public Vector3[] cerezasCoord = new Vector3[] {new Vector3(-4.5f, 0, 4), new Vector3(-4.5f, 0, -2),
                                                    new Vector3(4.5f, 0, 4), new Vector3(4.5f, 0, -2)};

    /**Al iniciar se inicializan transformPuntuacion y textPuntuacion, que es donde se escribe la \n
     * puntuacion del jugador en tiempo real \n
     * Se inicializa el rigidbody de PacMan, la camara que hace que el juego se vea en primera persona \n
     * y la rotacion en x de esa camara \n
     * Se inicializan todos los efectos de sonido necesarios
     * Se inicializa puntos, que es el objeto que guarda todos los puntos que PacMan debe comer y que \n
     * aun estan en el escenario
     * Se inicializa contro, que es el objeto que guarda todos los puntos de patrullaje del escenario
     */
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
        sonidoGanar = GameObject.Find("Ganar");
        sourceGanar = sonidoGanar.GetComponent<AudioSource>();
        sonidoFruta = GameObject.Find("Fruta");
        sourceFruta = sonidoFruta.GetComponent<AudioSource>();
        sonidoPerder = GameObject.Find("Perder");
        sourcePerder = sonidoPerder.GetComponent<AudioSource>();

        puntos = GameObject.Find("Puntos").transform;
        control = GameObject.Find("Control").transform;

        Invoke("Manzana", Random.Range(10, 61));
        Invoke("Mandarina", Random.Range(10, 61));
    }

    /**Se leen lasentradas que manda el usuario
     */
    private void Update()
    {
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        inputRot.x = Input.GetAxis("Horizontal") * sensibilidadMouse;
        inputRot.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;
    }

    /**Actualiza la posición y rotación de PacMan segun las entradas del jugador
     */
    private void FixedUpdate()
    {
        rigidbody.velocity = transform.forward * caminar * inputMov.y; //Avanzar adelante y atras
                                //+ transform.right * caminar * inputMov.x; //Avanzar izquierda y derecha

        transform.rotation *= Quaternion.Euler(0, inputRot.x, 0); //Camara izquiera y derecha

        //rotacionX -= inputRot.y;
        //rotacionX = Mathf.Clamp(rotacionX, -50f, 50f);
        //camara.localRotation = Quaternion.Euler(rotacionX, 0, 0); //Camara arriba y abajo
    }

    /**Detecta las colisiones con los fantasmas \n
     * en caso de que el efecto azul este activado PacMan se puede comer al fantasma \n
     * en caso contrario el fantasma se puede comer a PacMan y pierde una vida
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rojo") || collision.gameObject.CompareTag("Rosa") || 
            collision.gameObject.CompareTag("Azul") || collision.gameObject.CompareTag("Naranja"))
        {
            if (efectoAzulActivado)
            {
                sourceComeFantasma.Play();
                if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil) puntuacion += 100;
                else if (puntaciones.nivelDificultad == Puntaciones.Dificultad.normal) puntuacion += 200;
                else puntuacion += 300;
                CambiarPuntuacion();
                Destroy(collision.gameObject);
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
                        sourcePerder.Play();
                        puntaciones.muerte = true;
                        break;
                    default: break;
                }
            }
        }
    }

    /**Detecta los puntos que PacMan se tiene que comer \n
     * si son puntos grandes activa el efecto para que PacMan se pueda comer a los fantasmas \n
     * e instancia una cereza cerca de la base de los fantasmas \n
     * si son puntos verdes resta puntuacion y genera una fresa en algun lugar del escenario \n
     * Detecta los portales que teletransportan a PacMan al otro lado del escenario \n
     * Detecta las cerezas, que dan una vida extra \n
     * Detecta las fresas, que dan puntos extra \n
     * Detecta las manzanas, que activan la funcion de congelar a los fantasmas un momento \n
     * Detecta las naranjas, que aumentan la velocidad de PacMan
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Punto"))
        {
            sourceComerPuntos.Play();
            if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil) puntuacion += 5;
            else if (puntaciones.nivelDificultad == Puntaciones.Dificultad.normal) puntuacion += 10;
            else puntuacion += 15;
            CambiarPuntuacion();

            AvanzarNivel();
            //puntaciones.Guardar();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("PuntoAzul"))
        {
            sourceComerPuntos.Play();
            if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil) puntuacion += 10;
            else if (puntaciones.nivelDificultad == Puntaciones.Dificultad.normal) puntuacion += 20;
            else puntuacion += 30;
            CambiarPuntuacion();

            cereza = Instantiate<GameObject>(cerezaPrefab, cerezasCoord[Random.Range(0, 4)],
                    Quaternion.identity);

            efectoAzulActivado = true;
            puntaciones.efectoAzul = true;
            sourceEfectoAzul.Play();
            Invoke("DevolverColor", 10);

            AvanzarNivel();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("PuntoVere"))
        {
            sourceComerPuntos.Play();
            puntuacion -= 100;
            CambiarPuntuacion();

            fresa = Instantiate<GameObject>(fresaPrefab,
                    control.GetChild(Random.Range(0, 21)).transform.position, Quaternion.identity);
            Invoke("DestruirFresa", 20);

            AvanzarNivel();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Portal Derecho"))
            gameObject.transform.position = new Vector3(-23.5f, -0.5f, 1f);

        else if (other.CompareTag("Portal Izquierdo"))
            gameObject.transform.position = new Vector3(23.5f, -0.5f, 1f);

        else if (other.CompareTag("Cereza"))
        {
            sourceFruta.Play();
            VidaExtra();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Fresa"))
        {
            sourceFruta.Play();
            if (puntaciones.nivelDificultad == Puntaciones.Dificultad.facil) puntuacion += 100;
            else if (puntaciones.nivelDificultad == Puntaciones.Dificultad.normal) puntuacion += 150;
            else puntuacion += 250;
            CambiarPuntuacion();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Manzana"))
        {
            sourceFruta.Play();
            puntaciones.congelar = true;
            Destroy(other.gameObject);
            Invoke("Descongelar", 10);
        }

        else if (other.CompareTag("Mandarina"))
        {
            sourceFruta.Play();
            caminar *= 2;
            Destroy(other.gameObject);
            Invoke("Ralentizar", 10);
        }
    }

    /**Detiene el efecto que permite a PacMan comerse a los fantasmas y da unos segundos mas para \n 
     * destruir la cereza si no la ha comido PacMan
     */
    public void DevolverColor()
    {
        sourceEfectoAzul.Stop();
        efectoAzulActivado = false;
        puntaciones.efectoAzul = false;

        Invoke("DestruirCereza", 10);
    }

    /**Cambia la puntuacion en el registro \n
     * Da una vida extra cada mil puntos alcanzados
     */
    public void CambiarPuntuacion()
    {
        puntaciones.puntacionActual = puntuacion;
        textPuntuacion.text = puntuacion.ToString();

        //Consigue 1up cada 1000 puntos
        if (puntaciones.puntacionActual >= ref1up) VidaExtra();   
        ref1up += 1000;
    }

    /**Agrega vidas segun se requiera
     */
    public void VidaExtra()
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

    /**Destruye la cereza si PacMan no se la ha comido
     */
    public void DestruirCereza()
    {
        if(cereza != null) Destroy(cereza);
    }

    /**Destruye la fresa si PacMan no se la ha comido
     */
    public void DestruirFresa()
    {
        if(fresa != null) Destroy(fresa);
    }

    /**Destruye la manzana si PacMan no se la ha comido
     */
    public void DestruirManzana()
    {
        if (manzana != null) Destroy(manzana);
    }

    /**Destruye la naranja si PacMan no se la ha comido
     */
    public void DestruirMandarina()
    {
        if (mandarina != null) Destroy(mandarina);
    }

    /**Intancia una manzana en un lugar aleatorio del escenario y espera para destruirla
     */
    public void Manzana()
    {
        manzana = Instantiate<GameObject>(manzanaPrefab,
                    control.GetChild(Random.Range(0, 21)).transform.position, Quaternion.identity);
        Invoke("DestruirManzana", 20);
    }

    /**Intancia una naranja en un lugar aleatorio del escenario y espera para destruirla
     */
    public void Mandarina()
    {
        mandarina = Instantiate<GameObject>(mandarinaPrefab,
                    control.GetChild(Random.Range(0, 21)).transform.position, Quaternion.identity);
        Invoke("DestruirMandarina", 20);
    }

    /**Desactiva el efecto que congela a los fantasmas
     */
    public void Descongelar()
    {
        puntaciones.congelar = false;
    }

    /**Devuelve la velocidad normal a PacMan
    */
    public void Ralentizar()
    {
        caminar /= 2;
    }

    /**Analiza si PacMan ya se ha comido todos los puntos para avanzar de nivel o ganar
    */
    public void AvanzarNivel()
    {
        if (puntos.childCount == 1)
        {
            sourceGanar.Play();
            puntaciones.avanzar = true;
        }
    }
}

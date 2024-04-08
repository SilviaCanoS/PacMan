using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Principal : MonoBehaviour
{
    public GameObject canvasPrincipal, canvasPausa, canvasPuntuacion, canvasControles, canvasPerder, 
        canvasGanar, canvasAvanzar;
    public Puntaciones puntaciones;

    private void Start()
    {
        puntaciones.efectoAzul = false;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) MostrarPausa();

        if (puntaciones.muerte)
        {
            canvasPrincipal.SetActive(false);
            canvasPerder.SetActive(true);
            puntaciones.muerte = false;
            Invoke("ReiniciarNivel", 5);
        }

        if(puntaciones.avanzar)
        {
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            puntaciones.avanzar = false;
            canvasPrincipal.SetActive(false);
            GameObject.Find("PacMan").transform.position = new Vector3(0, 10, 0);
            if (SceneManager.sceneCountInBuildSettings > escenaActual + 1)
            {
                canvasAvanzar.SetActive(true);
                Invoke("SiguienteNivel", 5);
            }
            else canvasGanar.SetActive(true);
        }
    }

    public void SiguienteNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }

    public void MostrarPausa()
    {
        Time.timeScale = 0;
        canvasPrincipal.SetActive(false);
        canvasPausa.SetActive(true);
    }

    public void OcultarPausa()
    {
        Time.timeScale = 1;
        canvasPrincipal.SetActive(true);
        canvasPausa.SetActive(false);
    }

    public void MostrarControles()
    {
        canvasPausa.SetActive(false);
        canvasControles.SetActive(true);
    }

    public void OcultarControles()
    {
        canvasPausa.SetActive(true);
        canvasControles.SetActive(false);
    }

    public void MostrarPuntuacion()
    {
        canvasPausa.SetActive(false);
        canvasPuntuacion.SetActive(true);
    }

    public void OcultarPuntuacion()
    {
        canvasPausa.SetActive(true);
        canvasPuntuacion.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void ReiniciarNivel()
    {
        canvasPuntuacion.SetActive(true);
        puntaciones.puntacionActual = 0;
        Time.timeScale = 1;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }

    public void ReiniciarJuego()
    {
        canvasPuntuacion.SetActive(true);
        puntaciones.puntacionActual = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

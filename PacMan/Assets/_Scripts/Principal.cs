using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Principal : MonoBehaviour
{
    public GameObject canvasPrincipal, canvasPausa, canvasPuntuacion;
    public Puntaciones puntaciones;

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
        if (puntaciones.puntacionActual > puntaciones.puntos[5])
        {
            puntaciones.puntos[5] = puntaciones.puntacionActual;
            puntaciones.nombres[5] = puntaciones.nombreActual;
        }
        puntaciones.puntacionActual = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}

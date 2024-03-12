using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Principal : MonoBehaviour
{
    public GameObject canvasPrincipal, canvasPausa, canvasPuntuacion;
    public TMPro.TMP_Text textPuntuacion;

    private void OnEnable()
    {
        //textoRecursos.text = $"Recursos: {adminJuego.recursos}";
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
        Time.timeScale = 1;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}

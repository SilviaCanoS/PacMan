using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public Puntaciones puntaciones;
    public GameObject canvasAjustes, canvasInicio, canvasControles, canvasTabla;

    public void MostrarAjustes()
    {
        canvasInicio.SetActive(false);
        canvasAjustes.SetActive(true);
    }

    public void OcultarAjustes()
    {
        canvasInicio.SetActive(true);
        canvasAjustes.SetActive(false);
    }

    public void MostrarControles()
    {
        canvasControles.SetActive(true);
        canvasAjustes.SetActive(false);
    }

    public void OcultarControles()
    {
        canvasControles.SetActive(false);
        canvasAjustes.SetActive(true);
    }

    public void MostrarTabla()
    {
        canvasTabla.SetActive(true);
        canvasAjustes.SetActive(false);
    }

    public void OcultarTabla()
    {
        canvasTabla.SetActive(false);
        canvasAjustes.SetActive(true);
    }

    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    //public void CambiarNombre()
    //{
    //    puntaciones.nombreActual = inputNombre.text;
    //    puntaciones.puntacionActual = 0;

    //    if(puntaciones.nombreActual == inputNombre.text )
    //    {
    //        cambio.SetActive(true);
    //        Invoke("OcultarCambio", 2);
    //    }
    //}

    //public void OcultarCambio()
    //{
    //    cambio.SetActive(false);
    //}

    public void Salir()
    {
        Application.Quit();
    }
}

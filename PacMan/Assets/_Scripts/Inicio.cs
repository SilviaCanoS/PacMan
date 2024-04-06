using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public TMPro.TMP_InputField inputNombre;
    public Puntaciones puntaciones;
    public GameObject cambio;

    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void CambiarNombre()
    {
        puntaciones.nombreActual = inputNombre.text;
        puntaciones.puntacionActual = 0;

        if(puntaciones.nombreActual == inputNombre.text )
        {
            cambio.SetActive(true);
            Invoke("OcultarCambio", 2);
        }
    }

    public void OcultarCambio()
    {
        cambio.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}

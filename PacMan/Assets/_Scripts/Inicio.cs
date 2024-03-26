using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{
    public TMPro.TMP_InputField inputNombre;
    public Puntaciones puntaciones;

    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void CambiarNombre()
    {
        puntaciones.nombreActual = inputNombre.text;
        puntaciones.puntacionActual = 0;
    }

    public void Salir()
    {
        Application.Quit();
    }
}

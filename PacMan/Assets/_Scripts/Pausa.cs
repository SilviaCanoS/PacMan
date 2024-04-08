using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public Transform transformTitulo;
    public TMPro.TMP_Text textTitulo;
    public Puntaciones puntaciones;
    public TMPro.TMP_InputField inputNombre;

    private void OnEnable()
    {
        transformTitulo = GameObject.Find("TextNombre").transform;
        textTitulo = transformTitulo.GetComponent<TMPro.TMP_Text>();
        textTitulo.text = $"¡Hola, {puntaciones.nombreActual}!";
    }

    public void CambiarNombre()
    {
        string nombre = inputNombre.text;
        if (puntaciones.puntacionActual > puntaciones.puntos[5])
        {
            puntaciones.puntos[5] = puntaciones.puntacionActual;
            puntaciones.nombres[5] = puntaciones.nombreActual;
        }
        puntaciones.nombreActual = nombre;
        puntaciones.puntacionActual = 0;
        textTitulo.text = $"¡Hola, {puntaciones.nombreActual}!";

        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex != 0) SceneManager.LoadScene(1);
    }
}

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
        textTitulo.text = $"�Hola, {puntaciones.nombreActual}!";
    }

    public void CambiarNombre()
    {
        string nombre = inputNombre.text;
        puntaciones.nombreActual = nombre;
        textTitulo.text = $"�Hola, {puntaciones.nombreActual}!";

        Time.timeScale = 1;
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
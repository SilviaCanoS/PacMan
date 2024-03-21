using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropdownDificultad : MonoBehaviour
{
    public Puntaciones puntaciones;
    TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = this.GetComponent<TMP_Dropdown>();
        dropdown.value = (int)puntaciones.nivelDificultad;
        dropdown.onValueChanged.AddListener(delegate {
            puntaciones.CambiarDificultad(dropdown.value);
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        });
    }

    public void IdentificarNivel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

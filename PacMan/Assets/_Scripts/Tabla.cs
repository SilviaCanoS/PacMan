using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabla : MonoBehaviour
{
    public Transform transformNombre1, transformNombre2, transformNombre3, transformNombre4,
        transformNombre5, transformNombre6;
    public Transform transformPuntaje1, transformPuntaje2, transformPuntaje3, transformPuntaje4,
        transformPuntaje5, transformPuntaje6;
    public TMPro.TMP_Text textNombre1, textNombre2, textNombre3, textNombre4, textNombre5, textNombre6;
    public TMPro.TMP_Text textPuntaje1, textPuntaje2, textPuntaje3, textPuntaje4, textPuntaje5, textPuntaje6;
    public Puntaciones puntaciones;

    private void OnEnable()
    {
        if (puntaciones.puntos[5] > puntaciones.puntos[4]) Cambiar(5, 4);
        if (puntaciones.puntos[4] > puntaciones.puntos[3]) Cambiar(4, 3);
        if (puntaciones.puntos[3] > puntaciones.puntos[2]) Cambiar(3, 2);
        if (puntaciones.puntos[2] > puntaciones.puntos[1]) Cambiar(2, 1);
        if (puntaciones.puntos[1] > puntaciones.puntos[0]) Cambiar(1, 0);

        transformNombre1 = GameObject.Find("TextNombre1").transform;
        transformNombre2 = GameObject.Find("TextNombre2").transform;
        transformNombre3 = GameObject.Find("TextNombre3").transform;
        transformNombre4 = GameObject.Find("TextNombre4").transform;
        transformNombre5 = GameObject.Find("TextNombre5").transform;
        transformNombre6 = GameObject.Find("TextNombre6").transform;
        transformPuntaje1 = GameObject.Find("Text1").transform;
        transformPuntaje2 = GameObject.Find("Text2").transform;
        transformPuntaje3 = GameObject.Find("Text3").transform;
        transformPuntaje4 = GameObject.Find("Text4").transform;
        transformPuntaje5 = GameObject.Find("Text5").transform;
        transformPuntaje6 = GameObject.Find("Text6").transform;

        textNombre1 = transformNombre1.GetComponent<TMPro.TMP_Text>();
        textNombre2 = transformNombre2.GetComponent<TMPro.TMP_Text>();
        textNombre3 = transformNombre3.GetComponent<TMPro.TMP_Text>();
        textNombre4 = transformNombre4.GetComponent<TMPro.TMP_Text>();
        textNombre5 = transformNombre5.GetComponent<TMPro.TMP_Text>();
        textNombre6 = transformNombre6.GetComponent<TMPro.TMP_Text>();
        textPuntaje1 = transformPuntaje1.GetComponent<TMPro.TMP_Text>();
        textPuntaje2 = transformPuntaje2.GetComponent<TMPro.TMP_Text>();
        textPuntaje3 = transformPuntaje3.GetComponent<TMPro.TMP_Text>();
        textPuntaje4 = transformPuntaje4.GetComponent<TMPro.TMP_Text>();
        textPuntaje5 = transformPuntaje5.GetComponent<TMPro.TMP_Text>();
        textPuntaje6 = transformPuntaje6.GetComponent<TMPro.TMP_Text>();

        textNombre1.text = puntaciones.nombres[0];
        textNombre2.text = puntaciones.nombres[1];
        textNombre3.text = puntaciones.nombres[2];
        textNombre4.text = puntaciones.nombres[3];
        textNombre5.text = puntaciones.nombres[4];
        textNombre6.text = puntaciones.nombres[5];
        textPuntaje1.text = puntaciones.puntos[0].ToString();
        textPuntaje2.text = puntaciones.puntos[1].ToString();
        textPuntaje3.text = puntaciones.puntos[2].ToString();
        textPuntaje4.text = puntaciones.puntos[3].ToString();
        textPuntaje5.text = puntaciones.puntos[4].ToString();
        textPuntaje6.text = puntaciones.puntos[5].ToString();

    }

    public void Cambiar(int num1, int num2)
    {
        string nom = puntaciones.nombres[num2];
        int punt = puntaciones.puntos[num2];
        puntaciones.nombres[num2] = puntaciones.nombres[num1];
        puntaciones.puntos[num2] = puntaciones.puntos[num1];
        puntaciones.nombres[num1] = nom;
        puntaciones.puntos[num1] = punt;
    }
}

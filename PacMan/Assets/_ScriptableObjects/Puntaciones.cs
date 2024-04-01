using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puntuaciones", menuName = "Herramientas/ Puntuaciones", order = 0)]
public class Puntaciones : ScriptableObjects
{
    public bool efectoAzul, congelar, muerte, avanzar;
    public int puntacionActual = 0;
    public string nombreActual = "Jugador";

    public string[] nombres = new string[6] {"Jugador1", "Jugador2", "Jugador3", "Jugador4", "Jugador5",
                                            "Jugador6" };
    public int[] puntos = new int[6] {0, 0, 0, 0, 0, 0 };

    public Dificultad nivelDificultad = Dificultad.normal;
    public enum Dificultad { facil, normal, dificil }

    public void CambiarDificultad(int nuevaDificultad)
    {
        nivelDificultad = (Dificultad)nuevaDificultad;
    }

}

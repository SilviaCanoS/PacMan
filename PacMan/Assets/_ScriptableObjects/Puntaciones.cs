using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puntuaciones", menuName = "Herramientas/ Puntuaciones", order = 0)]
public class Puntaciones : ScriptableObjects
{
    public bool efectoAzul;
    public int puntacionActual = 0;
    public string nombreActual = "Jugador";
    public string[] nombres = new string[6] {"Jugador1", "Jugador2", "Jugador3", "Jugador4", "Jugador5",
                                            "Jugador6" };
    public int[] puntos = new int[6] {0, 0, 0, 0, 0, 0 };

}

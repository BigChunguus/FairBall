using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porteria : MonoBehaviour
{
    public int puntosJugador1 = 0;
    public int puntosJugador2 = 0;
    public Text textoPuntos1;
    public Text textoPuntos2;
    void Start()
    {
        // Configura la referencia de la portería en la pelota
        MovimientoPelota pelotaScript = FindObjectOfType<MovimientoPelota>();
        if (pelotaScript != null)
        {
            pelotaScript.SetPorteria(this);
        }

        // Asegúrate de asignar el objeto Text en el inspector
        if (textoPuntos1 == null || textoPuntos2 == null)
        {
            Debug.LogError("Asigna el objeto Text en el inspector.");
        }
        else
        {
            // Actualiza el texto con los puntos iniciales
            ActualizarTextoPuntos1();
            ActualizarTextoPuntos2();
        }
    }

    // Método para anotar un punto
    public void AnotarPunto1()
    {
        puntosJugador1++;
        Debug.Log("¡Gol! Puntos del Jugador: " + puntosJugador1);
        ActualizarTextoPuntos1();
    }
    public void AnotarPunto2(){
        puntosJugador2++;
        Debug.Log("¡Gol! Puntos del Jugador: " + puntosJugador2);
        ActualizarTextoPuntos2();
    }

    void ActualizarTextoPuntos1()
    {
        if (textoPuntos1 != null)
        {
            textoPuntos1.text = "Puntos: " + puntosJugador1;
        }
    }
    void ActualizarTextoPuntos2()
    {
        if (textoPuntos2 != null)
        {
            textoPuntos2.text = "Puntos: " + puntosJugador2;
        }
    }
}

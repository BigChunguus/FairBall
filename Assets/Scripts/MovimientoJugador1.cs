using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador1 : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del jugador
    public float limiteSuperior = 2f; // Límite superior en el eje Y
    public float limiteInferior = -2f; // Límite inferior en el eje Y

    void Update()
    {
        // Obtener la entrada del teclado vertical
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento solo en la dirección vertical
        Vector3 movimiento = new Vector3(0f, movimientoVertical, 0f) * velocidad * Time.deltaTime;

        // Calcular la nueva posición después del movimiento
        Vector3 nuevaPosicion = transform.position + movimiento;

        // Aplicar el movimiento solo si la nueva posición está dentro de los límites
        if (nuevaPosicion.y < limiteSuperior && nuevaPosicion.y > limiteInferior)
        {
            // Aplicar el movimiento al jugador
            transform.Translate(movimiento);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMaquina : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento de la máquina
    public float limiteSuperior = 2f; // Límite superior en el eje Y
    public float limiteInferior = -2f; // Límite inferior en el eje Y

    public Transform pelota; // Referencia a la pelota para seguir su posición

    void Update()
    {
        if (pelota != null)
        {
            // Calcula la dirección hacia la posición de la pelota
            float direccionY = Mathf.Clamp(pelota.position.y - transform.position.y, -1f, 1f);

            // Calcula el vector de movimiento solo en la dirección vertical
            Vector3 movimiento = new Vector3(0f, direccionY, 0f) * velocidad * Time.deltaTime;

            // Calcula la nueva posición después del movimiento
            Vector3 nuevaPosicion = transform.position + movimiento;

            // Aplica el movimiento solo si la nueva posición está dentro de los límites
            if (nuevaPosicion.y < limiteSuperior && nuevaPosicion.y > limiteInferior)
            {
                // Aplica el movimiento a la máquina
                transform.Translate(movimiento);
            }
        }
    }
}

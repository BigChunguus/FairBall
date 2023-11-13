using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPelota : MonoBehaviour
{
    public float velocidadInicial = 5f;
    public float velocidadMaxima = 16f;
    public float velocidadMinima = 2f;
    private float velocidadActual;
    public float factorFrenado = 0.99998f;

    private Rigidbody2D rb;
    private Porteria porteria; // Agrega esta variable para referenciar la portería

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadActual = velocidadInicial;
        IniciarPelota();
    }

    // Agrega este método para configurar la referencia a la portería
    public void SetPorteria(Porteria porteria)
    {
        this.porteria = porteria;
    }

    void IniciarPelota()
    {
        float direccionY = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 direccionInicial = new Vector2(-5f, direccionY).normalized;
        rb.velocity = direccionInicial * velocidadInicial;
    }
    void ResetearPelota1(){

        Vector3 posicion = new Vector3(1f, 0f, 0f);
        // Método para reaparecer la pelota en una posición específica
        transform.position = posicion;
        // Puedes reiniciar la velocidad u otras propiedades según sea necesario
        rb.velocity = Vector2.zero;
        IniciarPelota();
    
    }
    void ResetearPelota2(){

        Vector3 posicion = new Vector3(-1f, 0f, 0f);
        // Método para reaparecer la pelota en una posición específica
        transform.position = posicion;
        // Puedes reiniciar la velocidad u otras propiedades según sea necesario
        rb.velocity = Vector2.zero;
        IniciarPelota();
    
    }
    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude / 1.003f, velocidadMaxima);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        string etiqueta = col.gameObject.tag;

        switch (etiqueta)
        {
            case "Bumper":
                rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude * 2.5f, velocidadMaxima);
                break;
            case "Pared":
                rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude * 2f, velocidadMaxima);
                break;
            case "Jugador":
                rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude * 3f, velocidadMaxima);
                break;
            case "Triangulo":
                 rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude * 2f, velocidadMaxima);
                break;
            default:
                rb.velocity = rb.velocity.normalized * Mathf.Min(rb.velocity.magnitude * 2f, velocidadMaxima);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D trig){
    string etiqueta = trig.gameObject.tag;
        switch (etiqueta){
            case "Porteria1":
                    // Llama al método de la portería para anotar un punto
                    if (porteria != null)
                    {
                        porteria.AnotarPunto2();
                    }
                    // Resetea la posición de la pelota
                    ResetearPelota2();
                    break;
                case "Porteria2":
                    // Llama al método de la portería para anotar un punto
                    if (porteria != null)
                    {
                        porteria.AnotarPunto1();
                    }
                    // Resetea la posición de la pelota
                    ResetearPelota1();
                    break;
        }
    }
}

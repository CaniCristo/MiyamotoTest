using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Parámetros de movimiento"), Space]
    [Tooltip("Velocidad de movimiento")]
    public float speed;

    //Referencia al valor del Input axis horizontal
    private float h;

    //Referencia al valor del Input axis vertical
    private float v;

    //Vector de movimiento
    private Vector2 movement;


    [Header("Límite de pantalla")]
    [Tooltip("Límite de movimiento en eje X")]
    public float xLimit;

    [Tooltip("Límite de movimiento en eje Y")]
    public float yLimit;

    private float playerXPos;
    private float playerYPos;


    //Referencias
    //Referencias al rigidbody 2D
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //recuperamos los valores de los axis horizontal y vertical
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate() {
        Movement();
    }

    /// <summary>
    /// Metodo que se encargara de realizar el movimiento del jugador
    /// </summary>
    private void Movement() {


        //Generamos un vector de movimiento y lo normalizamos
        movement = new Vector2(h, v).normalized;

        //Aplicamos el movimiento sobre el jugador
        rb2d.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);


        //Este es el límite de la parte derecha de la pantalla
        if (transform.position.x > xLimit) {

            rb2d.position = new Vector2(xLimit, transform.position.y);

        }


        //Este es el límite de la parte Izquierda de la pantalla
        if (transform.position.x < -xLimit)
        {

            rb2d.position = new Vector2(-xLimit, transform.position.y);

        }

        //Este es el límite de la parte Superior de la pantalla
        if (transform.position.y > yLimit)
        {

            rb2d.position = new Vector2(transform.position.x, yLimit);

        }


        //Este es el límite de la parte Inferior de la pantalla
        if (transform.position.y < -yLimit){

           rb2d.position = new Vector2(transform.position.x, -yLimit);

        }


    }



}

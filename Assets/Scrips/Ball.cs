using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //se crea variable de tipo Rigibody2D para controlar las fisicas del GameObject
    //atributo SerializeField permite mostrar la variable como campo en la ventana
    //Inspector, pero manteniendola como variable privada
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 5;
    //se crear variables de tipo Vector2 para manejar el moviento de Ball
    Vector2 moveDirection;
    Vector2 currentVelocity;
    void FixedUpdate()
    {
       //se asigna a currentVelicity la direccion actual de GameObject
       currentVelocity = rigidbody2d.velocity;
    }
    //metodo para traer informacion del GameObject con el que hace colision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //se asigna a moveDirection la normal del GameObject al colisionar con
        //otro GameObject
        moveDirection = Vector2.Reflect(currentVelocity, collision.GetContact(0).normal);
        //se asigna a currentVelocity la nueva direccion del GameObject
        rigidbody2d.velocity = moveDirection;
        //se utiliza tags para evaluar cuando el jugador pierda vidas
        if (collision.transform.CompareTag("DeathLimit"))
        {
            GameManager.Instance.PlayerLives--;
        }
    }

    public void LaunchBall()
    {
        //separo a Ball de su padre Paddle para que el movimiento de estos s
        //ea independiente luego de lanzar la bola
        transform.SetParent(null);
       // utilizando rigibody2d con atributo SealizeField e indicando que
       // vaya hacia arriba al iniciar juego
       rigidbody2d.velocity = Vector2.up * speed;
    }
    //metodo para resetear posision de la bola al perder una vida
    public void ResetBall()
    {
        Debug.Log("RESTAURAR BOLA");
        //paramos el moviemiento asignandole zero al vector
        rigidbody2d.velocity = Vector3.zero;
        //traemos el objeto el paddle
        Transform paddle = GameObject.Find("Paddle").transform;
        //hacemos al objeto ball hijo nuevamente del objeto paddle 
        transform.SetParent(paddle);
        //se asigna la posision de paddle a la variable
        Vector2 ballPosition = paddle.position;
        //incrementamos el valor de la posicion en el eje y para que ball
        //este mas arriba del paddle
        ballPosition.y += 1f;
        //le asignamos a la posicion de la bola
        transform.position = ballPosition;
        //pasamos a false la propiedad BallOnPlay para que se pueda hacer
        //el lanzamiento de la bola
        GameManager.Instance.BallOnPlay = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //se crea variable para controlar la velocidad del paddle
    [SerializeField] float speed = 6;
    [SerializeField] float xLimit = 7.5f;  
    void Update()
    {
        //validamos si se presionó la tecla D
        if (Input.GetKey(KeyCode.D) && transform.position.x < xLimit)
        {
            //la posision del GameObject cambia hacia la derecha
            //delta time: tiempo entre FPS
            transform.position += Time.deltaTime * Vector3.right * speed;
        }
        //validamos si se presionó la tecla A
        if (Input.GetKey(KeyCode.A) && transform.position.x > -xLimit)
        {
            transform.position += Time.deltaTime * Vector3.left * speed;
        }
        //validamos si se presiono el click izq del mouse
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("BallOnPlay: "+GameManager.Instance.BallOnPlay);
            Debug.Log("PlayerLives: " + GameManager.Instance.PlayerLives);
            Debug.Log("BricksOnLevel: " + GameManager.Instance.BricksOnLevel);
            Debug.Log("Topic: " + GameManager.Instance.Topic);
            //se evalua estado de la propiedad BallOnPlay y se cambia a true
            if (GameManager.Instance.BallOnPlay == false)
            {
                GameManager.Instance.BallOnPlay = true;
            }
            //se evalua estado de la propiedad GameStarted y se cambia a true
            if (GameManager.Instance.GameStarted == false)
            {
                GameManager.Instance.GameStarted = true;
            }
        }
    }
}

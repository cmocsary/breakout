using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    void Start()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.BricksOnLevel++;
        }
    }

    //metodo para modificar la propiedad BricksOnLevel, resta del acumulado de bricks cada vez que se elimina un bloque
    public void OnCollisionEnter2D(Collision2D collision)
    {
       if(GameManager.Instance != null)
        {
            GameManager.Instance.BricksOnLevel--;
        }
       //destruye el GameObject (cuando se escribe en camelcase hace referencia al this object)
        Destroy(gameObject);
    }
}

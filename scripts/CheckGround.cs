using UnityEngine;

//Este script, nos devuelve una variable estatica que es isOnGround
//la cual estara a true, si el objeto que tiene el script esta tocando
//el suelo, cuyo layer sera pasado mediante el atributo layerToCompare
//Este script, es para Juegos 2D, para juegos 3D, simplemente tendremos
//que cambiar las funciones OnTriggerEnter2D por OnTriggerEnter y sus
//parametros Collider2D por Collider

public class CheckGround : MonoBehaviour
{
    [SerilizeField] int layerToCompare;
    public static bool isOnGround;

    public int prueba;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layerToCompare)
        {
            isOnGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layerToCompare)
        {
            isOnGround = false;
        }
    }
}
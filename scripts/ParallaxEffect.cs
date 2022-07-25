using UnityEngine;

/*
 * Para calcular la diferencia de posicion del frame actual y del frame anterior vamos a emplear LateUpdate (Para conocer el valor una vez que la camara se haya movido) 
 * y a guardar en una variable, la posicion actual de la camara en x
 *  
 */

/*
* Este script se aplicará a cada fondo que vaya a componer nuestro background de parallax. De igual modo, se podra y debera
* aplicar a el suelo donde se vaya a ir desplazando el personaje.
*/
public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] Transform trCamera;    //Para refernciar el transform de la camara principal
    [SerializeField] float amountMovement;  //Para indicar la cantidad de movimiento de cada capa
    Vector3 preCameraPosition;              //Para guardar la posicion de la camara en el frame anterior
    float spriteWidth;                      //Voy a guardar el ancho del sprite
    float startPosition;                    //Voy a guardar donde esta inicialmente la capa

    void Awake()
    {
        if (trCamera == null) 
        {
            trCamera = Camera.main.GetComponent<Transform>(); //Referencio el Transform de la camara principal
        }

        preCameraPosition = trCamera.position;  //Guardamos al comienzo la posicion inicial de la camara
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; //Almaceno el ancho del sprite
        startPosition = transform.position.x;   //Guardo el valor inicial de la capa
    }

    void LateUpdate()
    {
        Paralla();
    }

    void Parallax()
    {
        //Guardamos la diferencia una vez que la camara se haya movido. Por eso metemos esta linea en LateUpdate
        //Voy a usar diffX para que cada capa de fondo se mueva esa cantidad de desplazamiento
        float diffX = (trCamera.position.x - preCameraPosition.x) * amountMovement;
        
        //En esta linea calculo cuanto se ha movido la camara con respecto a la capa
        float cantidadDesplazamiento = trCamera.position.x * (1 - amountMovement);
        
        transform.Translate(new Vector3(diffX, 0, 0));

        //Volvemos actualizar la posicion previa de la camara
        preCameraPosition = trCamera.position;

        if(cantidadDesplazamiento > startPosition + spriteWidth) //Para el desplazamiento a la derecha
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0)); //Movemos toda la capa a la posición del ancho de la capa
            startPosition += spriteWidth;   //Reposicionamos el inicio para que la camara se reposicione, justo donde se ha posicionado el nuevo sprite
        }
        else if(cantidadDesplazamiento < startPosition - spriteWidth) //Para el desplazamiento a la izquierda
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;
        }
    }
}
using UnityEngine;

//Este script, lo podemos aplicar al comportamiento de un enemigo en nuestro juego, para que se mueva a lo largo de una trayectora predefinida
public class MovimientoWayPoint : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;             //Array que almacenara los WayPoints que hayamos dispuesto en el escenario para el enemigo
    [SerializeField] float movementSpeed;               //La velocidad a la que se desplazara de un waypoint a otro
    [SerializeField] float distanciaCambioPunto;        //Distancia a la que cambiara a otro punto de la ruta
    int siguientePunto;                                 //El siguiente punto al que se va a mover el objeto que porte el script

    //Funcion que mueve un objeto, en una ruta predefinida por puntos. Esto seran empty objects ubicados en el escenario
    void MoverPorWayPoints()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[siguientePunto].transform.position, movementSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, wayPoints[siguientePunto].transform.position) < distanciaCambioPunto)
        {
            siguientePunto++;
            if(siguientePunto >= wayPoints.Length) siguientePunto = 1;
        }
    }
}
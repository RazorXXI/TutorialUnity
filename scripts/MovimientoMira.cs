using UnityEngine;

//Para usar este codigo sobre un GameObject que actue de mira para un juego.
//Debemos crear un Empty Object al cual cargaremos este script.
//Agregaremos al GameObject un componente sprite renderer, al cual le cargaremos el sprite que hayamos hecho con la mira

public class MovimientoMira : MonoBehaviour
{
    [SerializeField] Camera cam;

    void Update()
    {
        transform.position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
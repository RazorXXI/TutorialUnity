using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //NO OLVIDAR INCLUIR LA LIBRERIA PARA PODER USAR EL NUEVO INPUT SYSTEM

public class MoverCuadrado : MonoBehaviour
{
    [SerializeField] Rigidbody2D rbCuadrado;
    [SerializeField] float velocidadCuadrado = 8;

    Vector2 direccionMovimiento = Vector2.zero; //Para ir almacenando los movimientos
    PlayerActions accionesCuadrado;     //Para poder acceder a las acciones definidas en nuestro Input
   
    void Awake()
    {
        rbCuadrado = GetComponent<Rigidbody2D>();
        accionesCuadrado = new PlayerActions();     //Debemos crear una instancia para poder acceder a los controles
    }

    //Importante no olvidar para que no mueva o actue con algo que no existe NO OLVIDES PONER ESTO
    private void OnEnable()
    {
        accionesCuadrado.Enable(); //Para activar nuestras acciones
    }

    //Igual de importante que el anterior, por la misma razon NO OLVIDES PONER ESTO
    private void OnDisable()
    {
        accionesCuadrado.Disable(); //Para desactivar nuestras acciones
    }

    void Update()
    {
        //En update vamos leyendo los controles
        LeerControles();
    }

    void FixedUpdate()
    {
        //En el FixedUpdate movemos el objeto
        MoverObjeto();    
    }

    void MoverObjeto()
    {
        //Aplicamos movimiento al Rigidbody de nuestro amigo el cuadrado
        rbCuadrado.velocity = new Vector2(direccionMovimiento.x, direccionMovimiento.y) * velocidadCuadrado;
    }

    void LeerControles()
    {
        //Aqui estamos llamando a la accion relacionada con el movimiento la cual hemos definido con sus controles
        direccionMovimiento = accionesCuadrado.Personaje.Mover.ReadValue<Vector2>(); 
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploBasicoRaycast : MonoBehaviour
{
    //Voy a usar la camara como portadora del RayCast, modo Juego en primera persona
    [SerializeField] Camera cam;

    void Start()
    {
        
    }

    void Update()
    {
        DestroyWithRaycast();
    }

    void DestroyWithRaycast()
    {
        //Vamos comprobando que hemos  pulsado el boton izquierdo del raton
        if (Input.GetMouseButtonDown(0))
        {
            //Declaro una variable tipo raycast y le asigno la funcion ScreenPointToRay que lo que hace es devolver un rayo desde una camara
            //hasta un punto apuntado en la pantalla por el raton.
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //Almacena la información que devuelve el rayo al impactar

            //Aqui compruebo si el raycast a impactado contra algo, cuya información esta contenida en "hit", a una distancia máxima de 100 unidades
            //y desde un origen, en una dirección
            if(Physics.Raycast(ray.origin, ray.direction,out hit, 100))
            {
                //Esto es simplemente para saber que ha impactado por consola
                Debug.Log("Ha impactado");

                //Aqui compruebo si contra lo que ha chocado el rayo, pertenece a la capa 13
                if(hit.collider.gameObject.layer == 13)
                {
                    //Si pertenece a la capa 13, entonces destruyo el objeto contra el que ha chocado el rayo
                    //para ello nos valemos de la variable hit.
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}

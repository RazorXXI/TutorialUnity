using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Un ejemplo básico del uso del Raycast - La misión es entender como funciona y como se usa
public class EjemploBasicoDeRaycast : MonoBehaviour
{
    //Voy a usar la cámara como portadora del RayCast, modo Juego en primera persona
    [SerializeField] private Camera cam;


    void Update()
    {
        DestroyWithRaycast();
    }

    void DestroyWithRaycast()
    {
        //Declaro una variable tipo raycast y le asigno la funcion ScreenPointToRay que lo que hace es devolver un rayo desde una cámara
        //hasta un punto apuntado en la pantalla por el ratón.
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; //Almacena la información que devuelve el rayo al impactar
        
        //Vamos comprobando que hemos  pulsado el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            

            //Aquí compruebo si el raycast a impactado contra algo, cuya información esta contenida en "hit", a una distancia máxima de 100 unidades
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
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
}

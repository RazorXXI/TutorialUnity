using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutinas : MonoBehaviour
{
    //float counter;
    //[SerializeField] int counterInt; //Para ajustar los segundos sin decimales
    //bool canSayHello; //Para controlar el saludo

    // Start convertido en Corrutina
    //IEnumerator Start()
    //{
    //    //canSayHello = false; //Usada para hacer el saludo sin corrutina

    //    //Llamada a la corrutina
    //    //StartCoroutine(SayHello());
    //    //yield return new WaitForSeconds(5);
    //    //StartCoroutine(SayHelloOneFrame());
    //}

    private void Start()
    {
        StartCoroutine(SayHelloOneFrame());
    }

    // Saludando sin corrutinas
    //void Update()
    //{
    //    //Para hacer que la función salte transcurridos 10 segundos sin el uso de corrutinas
    //    //Time.deltaTime, indica el tiempo que hay entre frame y frame.
    //    counter = counter + Time.deltaTime;
    //    counterInt = (int)counter; //Hacemos el casting para que los segundos no tengan decimales.

    //    if ((counterInt == 10) && (!canSayHello)) //Cuando llegue al numero de segundos y canSayHello aun no se haya activado
    //    {
    //        canSayHello = true; //La hacemos verdadera
    //        SayHello();         //Ejecutamos la función saludo.
    //    }


    //}

    //Metodo que saluda usando una función comun
    //void SayHello()
    //{
    //    Debug.Log("Hello My Friend!!!...");
    //}

    private void Update()
    {

    }

    //Corrutina para saludar
    IEnumerator SayHello()
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("Hello My Friend!!!...");
        yield return new WaitForSeconds(5f);
        Debug.Log("My Name Is SKYNET!!!... Juas Juas Juas");
    }

    IEnumerator SayHelloOneFrame()
    {
        Debug.Log("Te voy a saludar al transcurrir un Frame");
        yield return null;
        Debug.Log("Hola!!! Ya paso un FRAME...");
    }
}

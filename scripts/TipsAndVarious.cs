using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsAndVarious : MonoBehaviour
{
   // Start is called before the first frame update
    void Start()
    {
        //Llamando con Invoke
        //Invoke(nameof(SayHelloWithInvoke), 10f);
        //Invoke("SayHelloWithInvoke", 5f);

        InvokeRepeating(nameof(SayHelloPepe), 3f, 5f);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Invoke Detenidos...");
            CancelInvoke();
        }
    }
    //Vamos a usar Invoke
    void SayHelloWithInvoke()
    {
        Debug.Log("Te estoy diciendo Hola con Invoke");
    }

    IEnumerator SayHelloWithParameter(string nameToSayHello)
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Hello " + nameToSayHello);
    }

    void SayHelloPepe()
    {
        Debug.Log("Hello Pepe Again...");
    }
}

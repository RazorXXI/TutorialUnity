using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* En este script vamos a intercambiar la masa de dos objetos.
 * El primer objeto recibira la masa del segundo y viceversa.
 * 
 * Vamos a realizar la referencia de los Rigidbodys de los objeto, arrastrando desde el editor de Unity.
 * Pondremos igualmente la manera de hacerlo mediante la referenciación de los objetos por código puro y duro.
 */
public class IgualarMasasDeObjetos : MonoBehaviour
{
    //Vamos a declarar las variables como [SerializeField] para poder verlo desde el editor de Unity
    float auxiliarMass; //Variable auxiliar para el intercambio de las masas.

    [Header("Referencia a objetos")]
    [SerializeField] Rigidbody rigidbodyObj1; //El Rigidbody para el Objeto 1
    [SerializeField] Rigidbody rigidbodyObj2; //El Rigidbody para el Objeto 2

   
    void Start()
    {
        InterchangeMass();
    }

    void Update()
    {
        
    }

    void InterchangeMass()
    {
        //Intercambiamos las masas, asignando primero la masa de uno de los objetos a auxilarMass
        auxiliarMass = rigidbodyObj1.mass;
        rigidbodyObj1.mass = rigidbodyObj2.mass;
        rigidbodyObj2.mass = auxiliarMass;
    }

    //Para esta función, vamos a buscar directamente la referencia de los objetos en lugar de asignarlos por el editor.
    void InterchageMassTwo()
    {
        //Obtengo el componente Rigidbody del objeto que tiene aplicado el script, en este caso el Cubo.
        rigidbodyObj1 = GetComponent<Rigidbody>();

        //Localizo el Rigidbody del segundo objeto mediante Find
        rigidbodyObj2 = GameObject.Find("SphereMassDestiny").GetComponent<Rigidbody>();

        auxiliarMass = rigidbodyObj1.mass;
        rigidbodyObj1.mass = rigidbodyObj2.mass;
        rigidbodyObj2.mass = auxiliarMass;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRigidBody : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }    
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            //Activamos y desactivamos la propiedad Is Kinematic
            rb.isKinematic = !rb.isKinematic;
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX; //Bloqueamos la rotacion en el eje X
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationY; //Bloqueamos la rotacion en el eje Y
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationZ; //Bloqueamos la rotacion en el eje Z
        }
        //Solo podemos bloquear un eje de rotación con la instruccion RigidbodyConstraints.FreezeRotation
        //Con  lo cual, actua como un conmutador de bloqueo de cada eje.
    }
}
using UnityEngine;

//Forma de buscar el componente Rigidbody de nuestro player o de cualquier otra cosa
public class BuscarPlayer : MonoBehaviour 
{
    Rigidbody rbPlayer;
    void Start() 
    {
        //Suponemos que nuestro player tiene el tag Player
        //Nunca usar esto en Update, o tiraremos el rendimiento a la basura
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
}
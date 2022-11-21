using UnityEngine;

/**
* Este script lo que hace es que al recibir un impacto un objeto
* el cual esta indicado en el layer especificado dentro del OnCollisionEnter,
* se llama a una corrutina que lo que hace es cambiar el color dos veces
* a modo de simular un parpadeo por el impacto recibido.
*/

public class MaterialColor : MonoBehaviour
{
    [SerializeField] Color colorInicio;
    [SerializeField] Color colorFin;    
    [SerializeField] int numOfLayer;
    [SerializeField] float duracion;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == numOfLayer)
        {
            StartCoroutine(ChangeColor());
        }
    }
    
    public IEnumerator ChangeColor()
    {
        while(true)
        {
            rend.material.color = colorFin;
            yield return new WaitForSeconds(duracion);
            rend.material.color = colorInicio;
            yield return new WaitForSeconds(duracion);
            gameObject.SetActive(false);
        }
    }
}
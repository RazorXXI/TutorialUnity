using UnityEngine;
//Este Script, sirve para poder cambiar un material de un GameObject por codigo
//El componente que se encarga de referenciar un material es el Renderer

public class ChangeMaterial : MonoBehaviour
{
    Renderer rnd;
    [SerializeField] Material newMaterial;
    [SerializeField] Material[] newMaterials; //Array de materiales para poder cambiar entre varios
    [SerializeField] int materialIndex;       //Indice para la matriz de materiales.

    private void Start()
    {
        rnd = GetComponent<Renderer>();
        //rnd.material = newMaterial;     //Con esta linea, cargamos el nuevo material al objeto

        rnd.material = newMaterials[materialIndex]; //Con esta linea, cargamos el nuevo material desde un array de materiales
    }
}

using UnityEngine;

//Vamos a cambiar un material por codigo
//El componente que se encarga de referenciar un material es el Renderer

public class ChangeMaterial : MonoBehaviour
{
    Renderer rnd;
    [SerializeField] Material newMaterial;

    private void Start()
    {
        rnd = GetComponent<Renderer>();
        rnd.material = newMaterial;     //Con esta linea, cargamos el nuevo material al objeto
    }
}
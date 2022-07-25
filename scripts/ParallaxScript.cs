using UnityEngine;

//Script para aplicar a fondos para realizar efecto parallax para un endless runner
//el juego sera visualizado en una unica pantalla de camara, con lo cual no sera 
//necesario el tener en consideracion el desplazamiento de la camara, ni el del personaje
//el personaje se le aplicara una animacion de correr, aunque su posicion sera estatica en 
//todo momento, siendo el desplazamiento del fondo el que nos de la sensacion de desplazamiento
public class ParallaxScript : MonoBehaviour
{
    Material mat;       //Para guardar la referencia del material del plane (el fondo)
    float distance;     //Para el calculo de la distancia de desplazamiento

    //Para la velocidad a la que se desplazara el fondo
    [SerializeField, Range(0f, 1f)] public float speed = 0.2f;

    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        OffSetBackGround();
    }

    public void OffSetBackGround()
    {
        distance += speed * Time.deltaTime; //Calculo de la distancia de desplazamiento
        //Variacion del offset de la imagen, que nos dara la sensacion de movimiento
        //"_MainTex" es el nombre que Unity aplica al material por defecto del plane
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }

    public float GetParallaxSpeed()
    {
        return speed;
    }

    public void SetParallaxSpeed(float value)
    {
        speed = value;
    }
}
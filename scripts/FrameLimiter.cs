//Este script sirve para limitar la tasa FPS del juego
//Para este caso, ha sido limitado a 60 FPS
//Cargar el script en un objeto del juego, como por ejemplo la camara.
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
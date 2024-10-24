# DoTween Guia Resumida

## ¿Que es DoTween?

Una herramienta de Unity para crear animaciones suaves y personalizadas de forma sencilla.

## ¿Como se instala DoTween?

 - Descarga el paquete desde el Asset Store de Unity.

  ![DoTween_AssetStore](/docs/wiki/imgWiki/05_DoTweenAssetStore.png)

 - Importa el paquete a tu proyecto.

## Script Básico de DoTween

El script básico para usar DoTween debe empezar con la importación de su libreria, tal y como se muestra a continuación.

```C#
using DG.Tweening;  //Importacion necesaria para usar DoTween

//Hacer algo
```

## Tipos de Tween
 A continuación las funciones mas relevantes de DOTween.

 | Tipo de Tween | Descripción |
 | :--- | :--- |
 | DOMove | Anima o cambia de posición |
 | DORotate | Anima o cambia la rotación |
 | DOScale | Anima o cambia la escala |
 | DOColor | Anima o cambia el color | 
 | DOFade | Anima o cambia la opacidad |
 | DOValue | Anima o cambia cualquier valor numérico |
 | | |

 Funciones de personalización de los Tweenie.

 | Personalización | Descripción |
 |:--- | :--- |
 | SetEase | Define el tipo de curva de animación (linear, in, out, etc)
 | SetLoops | Repite la animación |
 | SetDelay | Retrasa el inicio de la animación |
 | OnComplete | Ejecuta el código al finalizar |
 | OnStart | Ejecuta el código al iniciar |
 | OnUpdate | Ejecuta el código durante la animación |
 | | |

 A continuación un ejemplo de uso de función y personalización.

 ```c#
using UnityEngine;
using DG.Tweening;

public class DoTweenExample : MonoBehaviour
{
    //Variables y codigo

    private void funcionDoTween()
    {
        //Codigo...
        // Escalar hacia arriba y hacia abajo
        transform.DOPunchScale(Vector3.one, 1f, 10) 
            .SetEase(Ease.InOutSine)        // Movimiento suave
            .SetLoops(-1, LoopType.Yoyo);   // Repetir infinitamente, yendo y viniendo
    }
}
 ```

## Secuencias
 Con DOTween tambien podemos encadenar varias animaciones, es lo que DOTween define como secuencia.

 Para declarar y usar una secuencia en DOTween lo haremos del siguiente modo.

 ```c#
 //Declaracion de la secuencia
 Sequence mySequence = DOTween.Sequence();

 //Agregar animacion
 mySequence.Append(transform.DOMoveX(2, 1));
 //Agregar animacion
 mySequence.Append(transform.DORotate(Vector3.up * 360, 2));

 //Reproducir secuencia
 mySequence.Play();
 ```

## Control de Tweens
Los controles de animaciones y secuencias son los siguientes:

 - **Play** : Inicia la animación
 - **Pause** : Pausa la animación
 - **Resume** : Reanuda la animación
 - **Rewind** : Vuelve la animación al principio
 - **Kill** : Cancela la animación
 - **Complete** : Fuerza la finalización de la animación


## Otros métodos interesantes de DOTween
 - **DOShake** : Simula un temblor
 - **DOPath** : Anima a lo largo de un camino
 - **DOProperty** : Anima cualquier propiedad personalizada

## Ejemplos útiles

 A continuación se muestran algunos ejemplos utiles de DOTween.

 ### Ejemplos con Sistema de Particulas
  **Menú Desplegable**
  ```c#
public void ToggleMenu() 
{
    menuPanel.DOMoveY(menuPanel.rectTransform.anchoredPosition.y + 100, 0.5f).SetEase(Ease.OutBack);
}
  ```

  **Controlar vida util de particulas (Sistema de Particulas)**
  ```c#
 ParticleSystem ps = GetComponent<ParticleSystem>();
//Otras declararciones

// Aumenta a 2 segundos en 1 segundo
 ps.main.startLifetimeModule.constant.DOValue(2f, 1f); 
  ```

  **Efecto de desvanecimiento de particulas**
  ```c#
ParticleSystem ps = GetComponent<ParticleSystem>();
//Otras declaraciones

ps.colorOverLifetime.color.gradient.Evaluate(1f).DOFade(0, 1f); // Desvanece el último color en 1 segundo
  ```

  **Animar la velocidad de emisión de las particulas**
  ```c#
 ParticleSystem ps = GetComponent<ParticleSystem>();
 //Otras declaraciones

 ps.emision.rateOverTime.constant.DOValue(100, 2f); // Aumenta a 100 partículas por segundo en 2 segundos
  ```

   **Cambiar el tamaño del emisor de particulas**
   ```c#
 ParticleSystem ps = GetComponent<ParticleSystem>();
 //Otras declaraciones

 ps.shape.radius.DOValue(5f, 1f); // Aumenta el radio a 5 unidades en 1 segundo
   ```

   **Crear efecto de explosión aumentando la velocidad y tamaño de las particulas**

   ```c#
 ParticleSystem ps = GetComponent<ParticleSystem>();
 //Otras declaraciones

 ps.main.startSpeed.DOValue(20f, 0.5f);
 ps.shape.radius.DOValue(10f, 0.5f);
   ```

   **Activar y desactivar el sistema de particulas**
   ```c#
 ParticleSystem ps = GetComponent<ParticleSystem>();
 //Otras declaraciones

 DOTween.Sequence()
    .Append(transform.DOPunchScale(Vector3.one, 1f, 1))
    .AppendCallback(() => ps.Play());
   ```

   **Efecto de explosion al destruir un objeto**
   ```c#
 public void Explode() 
 {
    ParticleSystem ps = GetComponent<ParticleSystem>();
    ps.Play();

    // Aumentar la velocidad y el tamaño de las partículas
    ps.main.startSpeed.DOValue(20f, 0.2f);
    ps.shape.radius.DOValue(10f, 0.2f);

    // Destruir el objeto después de la explosión
    Destroy(gameObject, 1f);
 }
   ```

 ### Ejemplos con la cámara
 A continuación algunos ejemplos de DOTween con la camara principal.
 
 **Movimiento suave de cámara**
 ```c#
 // Mueve la cámara a una nueva posición en 2 segundos
 Camera.main.transform.DOMove(new Vector3(10, 5, -10), 2f); 
 ```
 
 **Zoom de cámara**
 ```c#
 // Cambia el tamaño ortogonal de la cámara en 1 segundo
 Camera.main.orthographicSize.DOValue(5, 1f); 
 ```

 **Rotar la cámara**
 ```c#
 // Rota la cámara 30 grados en el eje X en 2 segundos
 Camera.main.transform.DORotate(new Vector3(30, 0, 0), 2f); 
 ```

 **Seguir un objeto en movimiento**
 ```c#
 // Sigue al objeto targetTransform con una velocidad de 2 unidades por segundo
 Camera.main.transform.DOFollow(targetTransform, 2f); 
 ```

 **Combinar seguimiento con zoom**
 ```c#
 // Añade un poco de anticipación al seguimiento
 Camera.main.transform.DOFollow(targetTransform, 2f).SetLookAhead(0.5f); 
 // Hace zoom mientras sigue al objeto
 Camera.main.orthographicSize.DOValue(3, 2f); 
 ```

 **Efecto Sacudida**
 ```c#
 // Sacude la cámara durante 1 segundo
 Camera.main.DOShakePosition(1f, 0.2f, 10, 90, false); 
 ```

 **Efecto de camara lenta**
 ```c#
 // Reduce la velocidad del tiempo
 Time.timeScale = 0.5f; 
 ```

 **Volver a la normalidad despues de efecto**
 ```c#
 // Aumenta la velocidad del tiempo en 2 segundos
 DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1, 2f); 
 ```

 **Combinar multiples efectos de camara**
 ```c#
 Sequence mySequence = DOTween.Sequence();
 
 mySequence.Append(Camera.main.transform.DOMove(new Vector3(10, 5, -10), 2f));
 mySequence.Append(Camera.main.transform.DORotate(new Vector3(30, 0, 0), 1f));
 mySequence.Play();
 ```

 **Camara que sigue a un personaje con efecto zoom**
 ```c#
 public class CameraFollow : MonoBehaviour
 {
    // Objeto a seguir
    public Transform target; 
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Zoom hacia el objetivo cuando se acerca
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        Camera.main.orthographicSize = Mathf.Lerp(10, 5, distanceToTarget / 10);
    }
 }
 ```
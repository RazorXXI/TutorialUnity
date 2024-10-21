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

**Menú Desplegable**
 ```c#
public void ToggleMenu() {
    menuPanel.DOMoveY(menuPanel.rectTransform.anchoredPosition.y + 100, 0.5f).SetEase(Ease.OutBack);
}
 ```

 **Controlar vida util de particulas (Sistema de Particulas)**
 ```c#
 ParticleSystem ps = GetComponent<ParticleSystem>();
//Otras declararciones

 ps.main.startLifetimeModule.constant.DOValue(2f, 1f); // Aumenta a 2 segundos en 1 segundo
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
 public void Explode() {
    ParticleSystem ps = GetComponent<ParticleSystem>();
    ps.Play();

    // Aumentar la velocidad y el tamaño de las partículas
    ps.main.startSpeed.DOValue(20f, 0.2f);
    ps.shape.radius.DOValue(10f, 0.2f);

    // Destruir el objeto después de la explosión
    Destroy(gameObject, 1f);
}
 ```
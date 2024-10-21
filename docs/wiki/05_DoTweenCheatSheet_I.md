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
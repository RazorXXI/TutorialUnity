# Uso de Raycast - Guia Resumida
## Que es un Raycast y para que sirve
 Un **raycast** es un rayo virtual que se lanza desde un punto en el espacio, en una dirección especifica.

 El objetivo del **raycast** es detectar colisones con otros objetos de la escena, proporcionando datos sobre el objeto impactado, tales como, distancia hasta la colisión, punto de colisión, entre otros.

## Funciones principales del Raycast

 * **Physics.Raycast**:
    - Devuelve `true` o `false` si impacta o no contra un `GameObject` en escena.
    - **Sintaxis**: `Physics.Raycast(orig, direc, **out** hit, dist);`
    - Parámetros:
        - *orig*: Punto de inicio del rayo
        - *direc*: Vector de dirección del rayo
        - *hit*: Objeto `RaycastHit` que almacena la información sobre la colisión.
        - *dist*: Distancia maxima que puede recorrer el rayo.


CONTINUAR AQUI CON EL RAYCAST
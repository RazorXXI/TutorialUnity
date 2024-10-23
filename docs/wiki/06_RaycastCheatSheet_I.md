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
 * **Physics.RaycastAll**: Devuelve un array de `RaycastHit` con todos los objetos impactados.
 * **Physics2D.Raycast**: Versión 2D del Physics.Raycast para proyectos 2D.

## Estructura del RaycastHit

 * **point**: Punto exacto de la colisión.
 * **normal**: Vector normal a la superficie en el punto de colisión.
 * **distance**: Distancia desde el origen del rayo hasta el punto de colisión.
 * **collider**: Referencia al collider del GameObject impactado.

## Usos Comunes del Raycast

 * **Detección de colisiones**: Disparos, interacción con objetos, detectar plataformas...
 * **Cálculo de distancias**: Medir distancia entre objetos.
 * **Creación de efectos visuales**: Sombras, partículas...
 * **Mecánicas de juego**: Puertas, triggers, ajuste de puntería...
 * **Optimización**: Verificación de visibilidad.

## Tips para raycast

 * **Visualicación**:
    Para visualizar el `raycast` en el `Scene View`, usaremos las funciones `Debug.DrawRay` o  `Debug.DrawLine`.
 * **Filtros**:
    Usaremos `layers` para filtrar los objetos a los cuales el `raycast` detecta.
 * **Optimización**:
    Emplearemos el `raycast` de modo eficiente para evitar sobrecargar la CPU.
 * **Combinaciones**:
    Podemos combinar el `raycast` con otras herramientas como `Physics.OverlapSphere` para detectar objetos cercanos.

## Ejemplos del uso del Raycast

### Ejemplo 01 - Declaración, detección y mensaje

Lanzamos un rayo desde un GameObject y se detecta con que ha chocado.

```C#
using UnityEngine;

public class MyScript : MonoBehaviour
{
    public float distancia = 10f

    void Update()
    {
        //Variable para almacenar la informacion de la colision
        RaycastHit hit;

        //Creamos un rayo desde la posicion del gameObject hacia delante
        Ray ray = new Ray(transform.position, transform.forward);

        //Comprobamos si hay colision con algo al lanzar el rayo
        if (Physics.Raycast(ray, out hit, distancia))
        {
            //Devuelve un mensaje por consola que nos dice con que hemos chocado
            Debug.Log("Hemos Chocado con: " + hit.collider.name);
        }
    }
}
```

### Ejemplo 02 - Disparos

Disparamos un rayo desde el cañon de un arma y se verifica si impacta contra un enemigo. Si el impacto es contra un enemigo, se le aplica daño a este.

```C#
public class Gun : MonoBehaviour
{
    public float range = 100f;          //Distancia maxima del rayo
    public int damage = 50;             //Cantidad de daño al enemigo
    public ParticleSystem shootEffect;  //Efecto de particulas para el disparo

    public void Shoot()
    {
        shootEffect.Play(); // Efecto visual del disparo

        RaycastHit hit;

        // Crear un rayo desde la posición del cañón en la dirección hacia adelante
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            //Mostramos por consola si ha habido impacto
            Debug.Log("Impacto en: " + hit.collider.name);

            // Si el objeto impactado tiene la etiqueta "Enemy"
            if (hit.collider.CompareTag("Enemy"))
            {
                // Infligir daño al enemigo
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    //Funcion para aplicar daño al enemigo
                    enemy.TakeDamage(damage);
                }
            }
        }
    }
}
```

### Ejemplo 03 - Interacción con objetos

En este ejemplo se detecta si el `player` está apuntando a un objeto interactuable y si es así, se llama a la función `Interact()` de dicho objeto.

```c#
public class PlayerController : MonoBehaviour
{
    public float distancia = 3f;

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distancia))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    // Interactuar con el objeto
                    Interactable interactableObject = hit.collider.GetComponent<Interactable>();
                    if (interactableObject != null)
                    {
                        interactableObject.Interact();
                    }
                }
            }
        }
    }
}

//Clase que porta el objeto interactuable
public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        // Aquí se implementa la lógica de interacción específica para cada objeto
        Debug.Log("Interactuando con " + gameObject.name);
    }
}
```

### Ejemplo 04 - Detección de plataformas

En este ejemplo se lanza un rayo hacia abajo para comprobar si el jugador esta o no en el suelo.

```C#
public class PlayerController : MonoBehaviour
{
    public float distanciaAlSuelo = 0.1f;    //Distancia del raycasta hasta el suelo

    void Update()
    {
        
        RaycastHit hit;
        
        //Comprobamos si el jugador esta en el suelo o no
        //-Vector3.up apunta al suelo
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, distanciaAlSuelo))
        {
            // El jugador está en el suelo
            // ...
        }
        else
        {
            // El jugador está en el aire
            // ...
        }
    }
}
```

### Ejemplo 05 - Apuntando con el ratón

En este ejemplo lanzamos un rayo desde la camara y se determina el punto de impacto del cursor del raton en la escena

```C#
public class PunteriaScript : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        RaycastHit hit;

        //Lanzamos el rayo desde la camara y vemos donde impacta, segun la posicion donde se encuentra el raton
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            // Mostrar el rayo cuando impacte con algun gameObject de la escena
            Debug.DrawLine(cam.transform.position, hit.point, Color.red);
        }
    }
}
```

### Ejemplo 06 - Navegación

En este ejemplo, el enemigo lanza un raycast hacia delante para detectar un obstaculo y cambiar de dirección si es necesario.

```C#
public class EnemyAI : MonoBehaviour
{
    public float distancia = 5f;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distancia))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                // El enemigo ha detectado un obstáculo, cambiar de dirección
                // Ejecutar codigo para cambio de direccion
            }
        }
    }
}
```

### Ejemplo 07 - Combinando Raycast con OverlapSphere

En este ejemplo hacemos uso combinado del raycast y de OverlapSphere para detectar multiples enemigos dentro de un radio de alcance y que estén dentro de su linea de visión.

```C#
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float radious = 10f;       //Radio de distancia de deteccion de enemigos
    public float damage = 20;       //Cantidad de daño
    public LayerMask enemyLayer;    //Layer de los enemigos para filtrar las detecciones

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Detectar enemigos cercanos usando OverlapSphere
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radious, enemyLayer);

            //Bucle para recorrer el array de Colliders
            foreach (Collider collider in hitColliders)
            {
                //Para cada enemigo detectado, lanzar un Raycast para verificar si está en la línea de visión
                RaycastHit hit;

                //Comprobamos si esta en la linea de vision del player
                if (Physics.Raycast(transform.position, (collider.transform.position - transform.position).normalized, out hit, radious))
                {
                    if (hit.collider == collider)
                    {
                        // El enemigo está en la línea de visión, infligir daño
                        Enemy enemy = hit.collider.GetComponent<Enemy>();
                        if (enemy != null)
                        {
                            enemy.TakeDamage(damage);   //Aplica daño al enemigo
                        }
                    }
                }
            }
        }
    }
}
```
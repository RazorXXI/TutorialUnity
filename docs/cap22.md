# Capítulo 8 - Patrones de Diseño
Bueno, pues siguiendo con los patrones de diseño, hoy vamos a ver uno de los mas utilizados en el desarrollo de juegos, y para eso estamos hablando de la piscina de objetos u `Object Pool`. Tachaaaan!!! Como te has quedado?

## Piscina de Objetos (Object Pool)
Hasta el momento, siempre que hemos querido usar mas de un mismo objeto en un juego, por ejemplo los disparos, hemos recurrido a los métodos `Instantiate();` y `Destroy()`.

Esto está bien si no tenemos muchas cosas en la jerarquia de nuestro juego, pero cuando tenemos muchos objetos, el uso de los métodos `Instantiate();` y `Destroy();` nos va a afectar directamente al rendimiento de nuestro juego. En resumen, crear y destruir objetos, no es muy optimo, lo mejor es **activar** y **desactivar** objetos.

El concepto de `Object Pooling`, lo que hace es tener varios `prefabs` del mismo tipo, los cuales están previamente desactivados. Cuando lo vamos a usar, lo que hacemos es `activarlo`, `posicionarlo` donde queramos y hacer con el lo que vayamos a hacer, bien sea dispararlo u otra cosa y cuando no sea necesario, `desactivarlo` y devolviendolo de nuevo a la piscina, para ser utilizado mas tarde.

Espero que hasta aquí el concepto vaya quedando algo mas claro, de lo que consiste el `Object Pooling`.

Lo que podemos tener en la piscina de objetos pueden ser muchas cosas:
 * Balas
 * Proyectiles
 * Enemigos
 * Coleccionables
 * Particulas
 * Obstaculos
 * Elementos del escenario (decoraciones del escenario)
 * Etc...

En resumen, todo aquello que pueda aparecer multiples veces en la escena y tenga que ser reutilizado.

El problema de instanciar y destruir, es la necesidad de almacenar previamente espacio en la memoria para poder guardar los objetos creados, pero, en el momento de destruir el objeto y liberar la memoria, entra en funcionamiento el `Garbage Collector` o **Recolector de Basura** para poder eliminar el objeto de la memoria. Cuando esto ocurre, se pueden producir picos de la CPU los cuales pueden resultar en una bajada de FPS del juego, lo cual es malo en relación a la experiencia de juego del usuario. Es por eso que decimos que *Instanciar* y *Destruir* es mucho mas costoso que activar o desactivar.

Cuando activamos un objeto previamente creado en el juego, lo que estamos haciendo es haciendolo visible, pero no se produce un consumo de la memoria RAM, dado que este recurso ya ha sido creado y reservado en memoria. En el momento de desactivar, no necesitamos llamar al *Recolector de Basura*, puesto que solamente vamos a dejar de hacer visible el objeto para volverlo a utilizar mas tarde. Entendiendo esto, veremos que en este caso no se producen picos de CPU con la consiguiente bajada de FPS en tiempo de ejecución.

Con lo cual, las ventajas de usar el `Object Poolin` son entre otras:
 * Evita el uso del `Garbage Collector`.
 * Mejora la velocidad a la hora de llamar al objeto.
 * Consume menos recursos en tiempo de ejecución (Importante en juegos para móviles).

Para poder hacer un `Object Pooling`, podemos emplear diferentes tipos de estructuras tales como:
  * Arrays
  * Listas
  * Colas

Si pensamos en cuestiones de rendimiento, podemos decir que la estructura de datos para construir la piscina de objetos que consume menos recursos y menos tiempo de procesador, son los `arrays`, aunque por ahí podremos ver ejemplos en los que se emplearan listas o colas.

Bien, pues soltada toda esta parrafada, vamos a ir al lío. Vamos crear una piscina de objetos. Para ello, vamos a crear un pequeño proyecto muy simple en donde vamos a simular una nave espacial que dispara laseres (muy original el ejemplo...).

No te preocupes, porque te voy a enseñar todo el proceso poco a poco, así que no te agobies.

Primero que nada, vamos a crear un proyecto en 2D de Unity al que yo he llamado `Object Pooling` (seguimos con una imaginación desbordante).

En dicho proyecto, voy a emplear un sprite en forma de triangulo para simular nuestra nave, voy a crear un material para aplicarselo al disparo laser y al que llamaré `laserMaterial`, una zona en la parte superior donde colisionarán los laseres, el contenedor para la piscina de objetos, el prefab para el disparo laser, y si se me olvida algo más, pues te lo iré contando aquí mas abajo.

Para ver una forma y otra, he preparado dos escenas, en las cuales en una hacemos los disparos sin `Object Pooling` y en la otra usando el `Object Pooling`

Ahora te voy a enseñar como queda la escena con y sin object pooling que he preparado para el ejemplo, que a efectos de diseño visual no afecta para cada caso, asi que, queda tal que así en ambos casos. La diferencia va estar en los `scripts` para poder disparar nuestro *laser*.

![Escena para ejemplo con y sin object pool](/img/_EscenarioEjemploConYSinObjectPool.png)

Ahora veremos lo que lleva cada cosa.

En la parte superior y de verde he definido un muro donde impactará el laser y el cual he llamado `TopWall`. Este además, tiene los siguientes componentes.

![Detalle del TopWall](/img/_DetalleTopWall.png)

Por otro lado, tenemos al *Player*, el cual está configurado de la siguiente manera, con un script que he creado para que pueda moverse y disparar (sin hacer uso del `Object Pooling`) y que tiene la siguiente pinta.

![Detalle del Player](/img/_DetalleDelPlayer.png)

Por último, he creado el prefab del laser, el cual tiene la siguiente pinta.

![Detalle Prefab del Laser](/img/_DetallePrefabLaser.png)

Los scripts que tengo básicamente uno es para el player y otro para el prefab del laser, los cuales ahora los pongo aquí.

```c#
using UnityEngine;

public class PlayerSinObjectPooling : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float laserOffset;
    [SerializeField] float playerSpeed;
    Rigidbody2D rbPlayer;
    float horizontalInput;
    float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlDelPlayer();
        DispararLaser();
    }

    private void FixedUpdate()
    {
        MovimientoDelPlayer();
    }
    void ControlDelPlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void DispararLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserPrefab, transform.position + Vector3.up * laserOffset, Quaternion.identity);
        }
    }

    void MovimientoDelPlayer()
    {
        Vector2 movimiento = new Vector2(horizontalInput, verticalInput) * playerSpeed * Time.fixedDeltaTime;
        rbPlayer.MovePosition(rbPlayer.position + movimiento);
    }
}
```

Y ahora el del laser.

```c#
using UnityEngine;

public class laserScript : MonoBehaviour
{
    [SerializeField] float laserSpeed;
    [SerializeField] Rigidbody2D rbLaser;

    // Start is called before the first frame update
    void Start()
    {
        rbLaser = GetComponent<Rigidbody2D>();
        rbLaser.velocity = Vector2.up * laserSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TopWall")
        {
            Destroy(gameObject);
        }
    }
}
```
Como vemos, hasta ahora es todo tal y como lo hemos venido haciendo, creando y destruyendo objetos. Pues bien, el frotar se va a acabar por que vamos a _activar_ y _desactivar_.

Vamos a ver ahora como sería usando una piscina de objetos.

Si nos fijamos en la escena a primera instancia, todo parece igual en la escena.

![Escenario Con Object Pooling](/img/_EscenarioEjemploConObjectPulling.png)

Aquí no vemos nada diferente verdad?? Obviamente, lo gordo está por detras de las bambalinas y ahora te lo enseño... (que mal ha sonado eso).

Pues bien, si vemos un poco de que está compuesta esta escena, veremos lo siguiente.

![Escena con Piscina de Objetos](/img/_DetalleEscenaConObjectPool.png)

Aquí podemos ver, que tenemos un objeto llamado `LaserPool` el cual es un objeto vacio al cual le hemos añadido un script llamado `LaserPooling`. Este será el encargado de crear la piscina de objetos. Si nos fijamos en la escena, al principio no hay nada, pero si ejecutamos la escena veremos como se nos crean los objetos del laser.

![Piscina Cargada con los laser](/img/_DetallePiscinaCargada.png)

Aquí es donde hemos creado los objetos y desactivado, ahora mostraré el código de como está hecha la piscina.

El codigo que se muestra a continuación se añade a un objeto vacio que yo he llamado `LaserPool` que es el va a ser la piscina de objetos.

Aquí en este código, es donde se van a crear las instancias de los lasers que vamos a ir disparando. La implementación de este código lo hemos hecho con una lista, pero se podía haber hecho igualmente con un `array`, la única diferencia entre el usar una lista o un array, es que la lista nos permite aumentar dinámicamente su tamaño en tiempo de ejecución tal y como hacemos en la función `RequestLaser`, la cual al final de esta, se amplia el tamaño de la lista en un elemento, para el caso de quedarnos sin laseres suficientes.

La condición expuesta al final del parrafo anterior, es debido a contemplar que en el caso de que la lista no cuente con elementos suficientes para activar, mientras los elementos de la piscina están activos, se incluye un nuevo laser, para no producir una condición `null` por desbordamiento en el tamaño de la lista.

```c#
using System.Collections.Generic;
using UnityEngine;

/*Aqui ademas de la piscina de objetos, vamos a usar el patron SINGLETON*/
public class LaserPooling : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] List<GameObject> laserList;
    [SerializeField] int poolSize = 10;

    //Aqui comienza el SINGLETON
    private static LaserPooling laserPoolingSingleton;
    public static LaserPooling Instance { get { return laserPoolingSingleton; } }

    private void Awake()
    {
        if (laserPoolingSingleton == null)
        {
            laserPoolingSingleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //Fin del SINGLETON

    void Start()
    {
        AddLaserToPool(poolSize);   //Cargamos la piscina con todos los lasers
    }

    //Funcion para ir creando instancias en la lista
    void AddLaserToPool(int amount)
    {
        //Bucle para cargar la lista
        for (int i = 0; i < amount; i++)
        {
            //Creo la instancia del laser
            GameObject laser = Instantiate(laserPrefab);
            //Desactivo la instancia
            laser.SetActive(false);
            //Meto la instancia en la lista
            laserList.Add(laser);
            //Hago hijos de la piscina a los lasers creados
            laser.transform.parent = transform;
        }
    }

    //Funcion para solicitar un laser
    public GameObject RequestLaser() 
    {
        //Recorro toda la lista creada
        for (int i = 0; i < laserList.Count; i++)
        {
            //Busco el primer laser desactivado
            if (!laserList[i].activeSelf)
            {
                //Activo el primer laser encontrado
                laserList[i].SetActive(true);
                //Devuelvo el laser
                return laserList[i];
            }
        }
        //Lo siguiente lo hacemos, por si nos quedamos sin suficientes elementos 
        //en la lista, para que no nos de error.
        AddLaserToPool(1);                              //Meto un elemento mas en la lista
        laserList[laserList.Count - 1].SetActive(true); //Lo activo
        return laserList[laserList.Count - 1];          //Y lo devuelvo para ser usado
    }
}
```

El siguiente código importante, es el que porta el `prefab` del laser, el cual queda de la siguiente forma.

```c#
using UnityEngine;

public class LaserScriptPooling : MonoBehaviour
{
    [SerializeField] float laserSpeed;      //La velocidad que tendra el laser al salir disparado
    [SerializeField] Rigidbody2D rbLaser;   //El rigidbody del laser

    void Start()
    {
        rbLaser = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()                         //Funcion que salta al activar el laser
    {
        rbLaser.velocity = Vector2.up * laserSpeed; //La velocidad del laser al ser activado
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TopWall") //Cuando el laser colisiona con el muro superior
        {
            gameObject.SetActive(false);           //Al colisionar con el muro, se desactiva el laser
        }
    }
}
```

Y por último, tenemos el código que llevará el player, que es el que va a usar el disparo del laser.

```c#
using UnityEngine;

public class PlayerConObjectPooling : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float laserOffSet = 0.5f;
    [SerializeField] Rigidbody2D rbPlayer;
    float horizontalInput;
    float verticalInput;
    
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlDelPlayer();
        DispararLaser();
    }

    private void FixedUpdate()
    {
        MovimientoDelPlayer();
    }

    void DispararLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Asignamos a un GameObject lo devuelto por la piscina de lasers
            GameObject laser = LaserPooling.Instance.RequestLaser();
            //Lo posicionamos para que salga desde delante de la nave
            laser.transform.position = transform.position + Vector3.up * laserOffSet;
        }
    }

    void MovimientoDelPlayer()
    {
        Vector2 movimiento = new Vector2(horizontalInput, verticalInput) * playerSpeed * Time.fixedDeltaTime;
        rbPlayer.MovePosition(rbPlayer.position + movimiento);
    }

    void ControlDelPlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}
```

Si nos fijamos en el código del player, veremos que es practicamente igual que el anterior sin `Object Pooling`, la única diferencia la vemos a la hora de instanciar el laser, que en este caso, no lo instanciamos, sino que lo llamamos desde la clase `LaserPooling`, la cual tiene hecho un `Singleton` para acceder a su método `RequestLaser`, el cual nos activa un laser de la piscina de objetos.

En resumen, podemos ver que el concepto de piscina de objetos no es realmente complejo, simplemente se trata de tener en consideración ciertas cuestiones, tales como el código que llevará la piscina, ademas del código que llevará el objeto que vaya en la piscina para que al colisionar se desactive. Obviamente, tambien es importante el código que llamará al objeto de la piscina, bien sea un `player`, un `npc` u otro caso.

Así que espero que te haya quedado claro mi joven *Skywalker*.

Se que este capítulo ha sido un poco denso, pero no tenía otra forma de hacerlo, así que espero te haya resultado útil.
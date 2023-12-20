# Capítulo 2: Scripting en Unity
## 2.8 - La Clase Padre Monobehaviour

Lucke, yo, soy tu Padre!!

Bien, pues es cierto, es el padre. `Monobehaviour` es la clase de la que hereda cualquier `script` en Unity. Obviamente si lo queremos usar de componente, debe heredar de `Monobehaviour`.

### 2.8.1 - Ciclo de vida de Monobehaviour
---  
  El ciclo de vida de `Monobehaviour` es como se muestra a continuación:
  
  ![Ciclo de Vida de Monobehaviour](https://i.stack.imgur.com/gmvWn.png)
  
  Yo se que ahora viendo el gráfico no entiendes mucho, pero no te agobies que te lo voy a ir explicando para que te quede clarito.
  
  Si nos fijamos, al comienzo de todo nos encontramos con el método `Awake`, este método se ejecuta antes que nada en Unity. Se ejecuta antes del método `Start`, si el `GameObject` esta activo. `Awake` se suele emplear para inicializar o referenciar.
  
  A continuación, nos encontramos con el método `OnEnable`, el cual es llamado cada vez que el objeto que porte el `script` sea activado.
  
  El siguiente método es `Start`, este método es llamado antes del primer *frame*, si el `script` esta activo (que también puede estar desactivado, que lo tengo que decir todo).
  
  A partir de aquí, la cosa empieza a enrevesarse un poco. Si nos fijamos en el gráfico, veremos que tenemos un apartado que pone `Physics`. Este es el correspondiente a las físicas del juego (movimiento, colisiones, saltos, etc...). Aquí es donde entran en juego algunas cosas vistas  antes, como `OnTrigger`, `OnCollision`. El encargado de las actualizaciones de las físicas, es el método llamado `FixedUpdate`, este va actualizando las físicas del juego una vez por frame, pero eso ya lo veremos un poco mas adelante. Para que lo pilles con mas claridad, es simplemente   el que actualiza todo aquello que tiene que ver con las físicas y punto.
  
  Ahora vamos a ver un método también muy importante, el cual vemos en el gráfico con el nombre `Update`. Este método es el encargado de actualizar todo aquello que tiene que ver con el renderizado (- Ya lo se... que es el renderizado?? Cuando pintas las cosas que hay en tu juego. Nubes,  moñecos, bichos chungos, elementos coleccionables, chascas varias, etc... - A que ya has pillado lo del renderizado??). He decirte, que este método se llama también una vez por frame, al igual que el `FixedUpdate`.
  
  Seguimos para bingo. A continuación, otro método que te voy a mencionar y que también es muy importante, es `LateUpdate`. Este se llama una vez por frame, peeero, siempre y cuando hayan sido ejecutados todos los métodos `Update`.
  
  Ahora vamos abajo del todo, porque los métodos del medio, no lo voy a explicar todavía, así que ya si eso mas adelante te los cuento, de momento solamente los mas importantes.
  
  Otro método importante es `OnDisable`, este se llama cada vez que el objeto que lleve el `script` sea desactivado. Vamos, como el método `OnEnable` pero al revés. Ya está.
  
  Y por último y no por ello menos importante, tenemos el método `OnDestroy`. Si, este es el Destructor de Mundos, el es Thanos!!!... Dejemos a los Marvel de lado un rato. El método `OnDestroy` es ejecutado justo en el momento antes de la destrucción del `GameObject` que porta el `script`.  Justo antes de destruirse el objeto, este es el método que se ejecuta (Lo vas pillando Lucke??).
  
  Bueno, hasta aquí hemos visto los métodos mas relevantes de `Monobehavior`, ahora te voy a poner una pequeña lista explicándote otros que verás en el gráfico:
  - `Reset()`: Se ejecuta cuando "*Component*" es añadido al *GameObject*.
  - Métodos `OnCollision`:
    - `OnCollisionEnter()`: Se ejecuta cuando se detecta una colisión entre objetos (Aquí es donde entra en juego las físicas).
    - `OnCollisionStay()`: Se ejecuta mientras dura la colisión entre objetos.
    - `OnCollisionExit()`: Se ejecuta cuando dejan de colisionar dos objetos.
  - Métodos `OnTrigger`:
    - `OnTriggerEnter()`: Se ejecuta, cuando un objeto que tiene activado su *trigger* colisiona.
    - `OnTriggerStay()`: Se ejecuta, mientras un objeto que tiene activado su *trigger* siga colisionando.
    - `OnTriggerExit()`: Se ejecuta, cuando un objeto que tiene activado su *trigger* deja de colisionar.
  - Métodos de renderizado de escena:
    - `OnBecomeVisible()`: Actua, cuando el componente "*Mesh Renderer*" está activo. También se activa, cuando la cámara muestra el objeto en la escena de juego[^1].
    - `OnBecomeInvisible()`: Actua, cuando el componente "*Mesh Renderer*" está desactivado. Tambien se activa, cuando la cámara deja de enfocar el objeto[^1].
  [^1]: Siempre que el objeto salga del campo de visión de la cámara mediante su componente "*Transform*".
  - `OnApplicationQuit()`: Es llamado justo antes de borrar todos los *GameObjects* y cerrar el juego o la aplicación.
  - `OnMouseDown()`: Se ejecuta, cada vez que se pulsa el botón izquierdo del ratón.
  
Bien, ahora que ya mas o menos lo tienes claro, te voy a dar una serie de Briconsejos para que seas un Mostro de la Programación de Juegos en Unity3D.
  
  Comenzamos.
  
  **BRICONSEJO 1**: 
  Para una buena practica de programación, usaremos:
  - `Awake()`: Siempre para referenciar los objetos.
  - `Start()`: Siempre para inicializar las variables.
  - Las entradas de datos **SIEMPRE** irán en el método `Update()`.
  - Las animaciones, movimientos y demás cosas que tengan que ver con físicas, **SIEMPRE** irán en el `FixedUpdate()`.
  
  **BRICONSEJO 2**:
  Los *trigger*, son muy útiles para hacer que salte una acción cuando pasemos de una habitación a otra.
  No se te olvide nunca que **UN OBJETO CON TRIGGER ACTIVADO SIEMPRE ES TRASPASABLE**.  
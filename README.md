# Scripting en C# Unity - Guía SuperCondensada de Programación en C# Unity

La idea de realizar esta guía es que pueda servir a otros, tal y como me ha servido a mi, a la hora de aprender a programar en Unity3D.
Estos apuntes han sido realizados por mi, durante la realización del curso de Programación de Videojuegos con Unity3D de Tokio School.

## Indice de Capítulos

* [Capítulo 1: Una breve introducción](./docs/cap01.md)
* [Capítulo 2: Variables y Tipos de datos](./docs/cap02.md)

## Mostrar Información por Consola

La consola de `Unity` nos va a resultar de gran utilidad para poder depurar nuestros `Scripts`, dado que vamos a poder lanzar mensajes para ver si se va ejecutando correctamente nuestro `script`.

La instrucción que nos va a servir para poder mostrar información por la consola es:

```
Debug.Log(<Variable o Valor>);
```

A continuación un ejemplo para entenderlo mejor:

```c#
string playerName = "Michael";
Debug.Log(playerName); //Esto nos mostrará el nombre del Jugador por consola
```

**NOTA**

**Es importante indicar, que si no se especifica el modificador de acceso de una variable, C# toma por defecto este como private.**

Otro dato importante que debemos saber, es que C# por defecto inicializa las variables por defecto según el tipo de dato:

| Tipo de Dato | Valor Inicializado |
| :--- | :--- |
| int | 0 |
| bool | false |
| float | 0.0 |
| string | null |


Como hemos ido viendo, los `scripts` son componentes que nosotros creamos, para darle comportamientos y funcionalidades a los **GameObjects** de nuestro juego o aplicación.

  ## Arrays

  Los `Arrays` son un tipo de estructura que permite almacenar un conjunto de datos.

  El modo de declarar un `array` es:

  ```
  tipoDatos[] NombreArray;
  ```

  Es importante indicar, que todo `array` debe ser inicializado para poder usarse.

  Las dos maneras de inicializar un array en C# son:

  - Primera Forma:
  ```
  tipoDato[] nombreArray = {valor1, valor2,..., valorN};
  ```

  - Segunda Forma:
  ```
  tipoDato[] nombreArray = new tipoDato[dimension];
  ```
  
  Debemos tener presente, que un `array` puede estar declarada pero no inicializada. Si la declaramos y queremos inicializarla posteriormente, lo haremos según la segunda manera que hemos visto anteriormente.

  Es muy importante tener en cuenta, que hast que un `array` no está inicializado, no puede ser utilizado. 

  **NOTA: Un array SOLO guarda valores de un mismo tipo.**

  Un detalle importante a mencionar es que, si no inicializamos un array y lo ponemos como *public* o lo indicamos como *[SerilizeField]*, siempre podemos inicializarlo, añadiendo valores desde el editor de Unity.

  **IMPORTANTE: Un array NO PUEDE cambiar de tamaño NUNCA en tiempo de ejecución.**

  Podemos asignar valores a una posición del `array`, para ello, simplemente deberemos indicar su indice de posición y asignar el valor (*Los verdaderos programadores y C# empiezan a contar desde 0 hasta n-1. Con lo cual, el primer elemento de un array siempre estará en la posición 0.*)

  Veamos un ejemplo de asignación:

  ```c#
  int[] nombresPersonajes = new int[5]; //Array desde [0] hasta [4]
  ...
  nombrePersonajes[1] = "Mago Merlín"; //He asignado una nueva string a una posición del array
  ```

  También podemos asignar valores entre `array`.

  ```c#
  int[] magiasJugadoresEquipoA = new int[5];
  int[] magiasJugadoresEquipoB = new int[5];

  //Aqui vamos a asignar valores entre dos posiciones de arrays
  magiasJugadoresEquipoA[2] = magiasJugadoresEquipoB[3];
  ```

  **TRUCO DEL ALMENDRUCO**

  **Si no inicializamos ni definimos el tamaño del array en nuestro script, lo podemos definir mediante el editor, siempre y cuando el array este como [SerializeField], de ese modo, podemos añadir la dimensión y los elementos directamente mediante el editor de Unity.**

  Siguiendo con los `arrays`, otra cosa interesante es el saber el tamaño del array. Para ello, utilizaremos su método `length`:

  ```c#
  int[] miArray = new int[5];
  ...
  Debug.Log(miArray.Length); //Esto nos devolverá la dimensión del array (el numero de elementos que puede almacenar)
  ```

  El uso que podemos hacer de los `arrays` es muy amplio. Podemos también declarar `arrays` de GameObject, lo cual es muy util para poder guardar referencias de objetos de nuestro juego.

  ```c#
  GameObject[] enemiesArrays = new GameObject[5]; //Array para almacenar referencias a 5 GameObjects
  ```

## Declaración y uso de funciones

En C# podemos crear nuestras propias funciones, es eso mismo lo que va a ampliar la funcionalidad de lo que queramos hacer en nuestros juegos gracias a nuestros *scripts*.

La forma de declarar una función en C# es del siguiente modo:

```
ValorDevuelto NombreFuncion(<parámetros>)
{
  //Aquí vendría el código de nuestra función.
}
```

Vemos en el esquema de arriba, que indicamos un valor de devolución como "*ValorDevuelto*", pero, una función puede devolver un valor o directamente no devolver nada, en cuyo caso el valor de devolución se conoce como `void`.

A continuación un ejemplo de una función real que no devuelve nada.

```c#
void funcionSaludame()
{
  Debug.Log("Hola Muchacho, bienvenido a Unity");
}
```

En la función anterior, vemos que el valor que devuelve la función es `void` lo cual indica que no devuelve nada. En este ejemplo, simplemente se mostraría un mensaje en la consola de Unity tal y como se indica en nuestra función.

Si queremos que una función devuelva un valor, para ello debe tener en algún punto de su código una llamada a `return`, el cual indica que devolverá lo que esté a la derecha de el. Vamos a ver un ejemplo.

```c#
int SumarDosNumeros(int num1, int num2)
{
  int sumatorio;
  sumatorio = num1 + num2;

  return sumatorio;
}
```

En el ejemplo, vemos que le pasamos dos números como parámetros a nuestra función, la cual sumará ambos y lo devolverá mediante la variable `sumatorio` y la llamada del `return`.

Creo que hasta aquí de momento claro el concepto de función, tranquilo que esto se puede complicar tanto como quieras, de momento estamos empezando con lo facilito.

## Estructuras de Control

Las estructuras de control, nos van a permitir controlar y dirigir el flujo de ejecución de nuestros scripts. De ese modo podemos imponer condiciones, manejar el flujo de nuestro script mediante la comparación de valores, etc.

### Estructura if/else

Esta estructura nos permite ejecutar un fragmente de código siempre que se cumpla una condición dada.

La sintaxis es:

```c#
if (condicion)
{
  //Acciones a realizar dentro si se cumple la condición
}
else
{
  //Acciones a realizar en caso de que no se cumpla la condición
}
```

Veamos un ejemplo:

```c#
if (numA > numB)
{
  Debug.Log("NumA es mayor que NumB");
}
else
{
  Debug.Log("NumB es mayor que NumA");
}
```

### Estructura if/else if/else

Esta estructura es igual que la anterior, pero podemos especificar mas de una condición para controlar.

La sintaxis es:

```c#
if (condicion1)
{
  //Acciones si se cumple condicion1
}
else if (condicion2)
{
  //Acciones si se cumple condicion2
}
else
{
  //Acciones a ejecutar si no se cumple nada de lo anterior
}
```

Veamos un ejemplo:

```c#
if (numA > numB)
{
  Debug.Log("NumA es mayor que NumB");
}
else if (numB > numA)
{
  Debug.Log("NumB es mayor que NumA");
}
else
{
  Debug.Log("NumA y NumB son iguales");
}
```

### Bucle While

El bucle While del paraguail...

Este bucle nos permite ejecutar un fragmente de código mientras se cumpla su condición y se repetirá mientras la condición sea cierta.

Su sintaxis es:

```c#
while (condicion)
{
  //Codigo a ejecutar mientras se cumpla la condición
}
```

Veamos un ejemplo:

```c#
int valor = 0; //Variable inicializada a 0

while (valor<5)
{
  Debug.Log("El valor es: " + valor); //Muestro un mensaje por consola indicando cuanto vale la variable mientras la condición del while sea cierta
  valor++; //Incremento el valor de la variable en 1 unidad cada vez. Cuando llegue a 5 se dejará de cumplir la condición y saldrá del bucle.
}
```

**OJO AL MANOJO: Es muy importante controlar que la condición se cumpla en algún momento, dado que si no se cumple entraremos en una mierda muy gorda que en informática se conoce como BUCLE INFINITO o THE FUCKING LOOP OF DEATH, el cual permanecerá dentro del bucle toda la eternidad, dejandonos el ordenador bloqueado, con el consiguiente fallo de nuestro juego o aplicación. Así que mi "Joven Palawan", no se te olvide de hacer que se cumpla la condición.**

### Estructura Switch

Este tipo de estructura, nos permite ejecutar una acción desde una lista de posibles opciones.

Su sintaxis es:

```c#
switch (variableDeComparacion)
{
  case valor1:
    //Instrucciones
    break; //Es necesario el break para una vez se ejecute salga
  case valor2:
    //Instrucciones
    break; //Si no se pone break, continuará ejecutando las opcciones
  case valorN:
    //Instrucciones
    break;
  default: //Esto se ejecuta si no se cumple nada de lo anterior
    //Instrucciones
    break;
}
```

Vamos a ver un ejemplo para entenderlo mejor:

```c#
int diaSemana;

//...haciendo cosas...

switch (diaSemana)
{
  case 1:
    Debug.Log("Es Lunes");
    break;
  case 2:
    Debug.Log("Es Martes");
    break;
  case 3:
    Debug.Log("Es Miercoles");
    break;
  case 4:
    Debug.Log("Es Jueves");
    break;
  case 5:
    Debug.Log("Es Viernes");
    break;
  case 6:
    Debug.Log("Es Sabado");
    break;
  case 7:
    Debug.Log("Es Domingo");
    break;
  default:
    Debug.Log("El valor no corresponde a ningun dia de la semana");
    break;
}
```

### Bucle For

Este bucle es ampliamente empleado para recorrer estructuras de datos, como por ejemplo los `arrays`.

Un detalle importante, es que en este bucle no tenemos el problema que teníamos en el `while` de que no se cumpliera la condición y nos quedáramos atrapados en un Bucle Infinito, ya que para poder emplear el bucle `for`, debemos definir previamente la longitud del bucle.

Su sintaxis es:

```c#
for (inicializacion; condicion; incremento)
```

Vamos a ver un ejemplo para entender mejor esto:

```c#
string[] nombre = {"Juan", "Miguel", "Carlos", "Ricardo"};
//Otras acciones del codigo...

for(int i = 0; i<nombre.Length; i++)
{
  Debug.Log(nombre[i]); //Esto nos ira mostrando los nombres del array por pantalla.
}
```

Como podemos comprobar, la gran utilidad de este bucle es la de iterar con los elementos de un `array`, aunque se puede emplear para otros fines, el principal que veréis es este.

### Bucle Foreach

Este bucle es parecido al `for`, pero esta orientado para iterar con colecciones de datos.

Un dato curioso que lo diferencia con respecto al `for` es que con este bucle, no vamos a iterar con un indice, con lo cual no podremos realizar operaciones como asignaciones en las posiciones indicadas por el indice.

Este bucle nos irá devolviendo en una variable los datos que vaya recogiendo de la estructura de datos en cuestión.

Su sintaxis es:

```c#
foreach(variableADevolver in Coleccion);
```

Vamos a ver un ejemplo:

```c#
string[] nombres = {"Juan"; "Miguel", "Carlos", "Ricardo"};
//Otras operaciones...

foreach(string nombreDevuelto in nombres)
{
  Debug.Log(nombreDevuelto);
}
```

## Control de Componentes

### Como se comunican los Objetos a través del código

Un detalle importante para poder acceder a un componente, es que es necesario tener una referencia al mismo.

Para obtener una referencia a un componente, debemos acceder a este, del siguiente modo:

```c#
GetComponent<Componente>();
```

Lo vamos a entender mejor con un ejemplo:

```c#
public Rigidbody rig = GetComponent<Rigidbody>();
```

Con la variable `rig` podemos cambiar los valores de las propiedades del `Rigidbody` referenciado.

Por lo tanto y para que quede completamente claro, la manera de comunicarse con los `GameObjects` es mediante **referencias**.

La manera mas común de referenciar un GameObject, es mediante su asignación (arrastrarlo) en el editor de Unity. Aunque también se pueden referenciar mediante código, eso lo veremos mas adelante, la mas común y cómoda es mediante el arrastrar en el editor.

**OJO AL MANOJO**

**Cuando creemos un script con una funcionalidad para un objeto, no debemos olvidar REFERENCIARLO para poder usarlo, ya que de lo contrario, el compilador de Unity nos dará un error.**

Acabamos de ver, la primera manera de comunicarnos con los `GameObjects` mediante la referencia a estos, pero también, nos podemos comunicar gracias a los eventos de tipo `colisión`.

Por ejemplo, un método que nos permite comunicar con un `GameObject`, sería el método `OnTriggerEnter`.

Este método, se ejecuta cuando dos objetos se superponen. Una condición para esto, es que el objeto que porte el `script`, tenga activado en su `Collider`, la propiedad `Is Trigger`.

La sintaxis de este método es:
 
```c#
void OnTriggerEnter(Collider other)
{
  //Acciones a ejecutar al producirse el método
}
```

Un uso para este método, sería el poner un `Collider` que no se vea y al traspasarlo, se desencadene una acción en nuestro juego.

**IMPORTANTE**

**"Is Trigger" hace que los objetos sean traspasables, no colisionan o se detienen al chocar.**

Como ya sabemos, para comunicar un objeto con otro, debe tener en su código, una `referencia`, como variable de clase con la que quiera operar.

Vamos a ver esto mejor con un ejemplo:

```c#
//Archivo Enemy.cs
public class Enemy : MonoBehaviour
{
  [SerializeField] int life;

  //Otras cosas de la clase
}
```

```c#
//Archivo Warrior.cs
public class Warrior : MonoBehaviour
{
  [SerializeField] Enemy enemies; //Referencia a la clase Enemy
}
```

Desde el código, podemos acceder a los componentes propios del objeto que tenga aplicado el `script` o a los de otro objeto al que hagamos referencia desde el código.

Una cosa que debemos saber, es que para acceder a los componentes propios debemos realizarlo mediante el siguiente formato de instrucción:

```c#
GetComponent<COMPONENTE>().Atributo;
```

Por ejemplo:

```c#
GetComponent<Rigidbody>().mass = 20; //Hemos accedido al atributo mass del Rigidbody del objeto
```

De un modo parecido, para acceder a los componentes y atributos de otro objeto, lo haremos mediante su referencia:

```c#
objeto.GetComponent<COMPONENTE>().Atributo;
```

Lo vamos a entender mejor con un ejemplo:

```c#
public Enemy enemies;

//Otras acciones y funciones

enemies.GetComponent<Rigidbody>().mass = 5;
```

Que locura PACO!!! pero aun queda mas, que esto está empezando a ponerse divertido.

También podemos acceder a los atributos de otro objeto, mediante su clase (COMO??!!! AQUI ES CUANDO TE ESTALLA EL CEREBRO!!!)... Pues claro que mediante su clase!!! No se te vaya de vista, que un `Script` es otro componente mas... (LO VAS PILLANDO??).

Bien, ahora te voy a poner un ejemplo de esto que te acabo de contar, para que lo vayas asimilando un poquito mejor:

```c#
GameObject enemy;
//Otras chascas varias

enemy.GetComponent<Enemy>().life;
//Enemy es el Script donde esta la clase
//Te acuerdas que puse Enemy.cs un poco mas arriba??

//Y life, es un atributo de la clase Enemy
```

Chian Ta Ta Chiaaaaan....!!! Ahora si te acabo de dejar con las patas colgando de la silla, verdad??

Bueno, ahora que lo has empezado a flipar, te diré, que hay también otros métodos muy útiles para localizar `GameObjects` dentro de la escena de juego. Estos son los métodos `Find`, estos nos permiten encontrar y referenciar `GameObjects` dentro de nuestra escena, pero claro... es demasiado bonito para que sea perfecto. Y porque no es perfecto, te estarás preguntando... ("PREGUNTATELO LEÑE, QUE TE VOY A DAR LA PARRAFADA DEL PORQUE...").

El problema de los `métodos Find` es que para encontrar un objeto, ha de recorrer todos los objetos de la escena. Vas pillando por donde voy?? Y que pasa que tenga que hacer eso?? Pues depende... si solo tienes 3 objetos en la escena (cosa poco probable... ya que tendrás por lo general el ciento y la madre) no es problema, lo va a encontrar rápido, pero como tengas chorrocientos objetos, es un problema, dado que va a tener que recorrerlos todos para encontrar uno en concreto, y cual es la pega...?? Pues muy fácil, que te va a bajar los FPS y el rendimiento se te va a ir a por tabaco a Logroño.

Si mi querido amigo, los `find` te petan el rendimiento de tu juego que es cosa mala.

(Jorobas Cuasimodo... Te estarás diciendo... OOOH... SI QUIERO BUSCAR ALGO ME LAS VOY A VER NEGRA... TENGO QUE TENER POCAS COSAS... NO PUEDO USAR FIND... NOOOOO!!!) Tranquilo hombre... no te desesperes, te voy a contar otras formas de localizar objetos en la escena de juego mucho mejores y mas optimas de usar la mierda del `find`, para que tu juego no se vea afectado por la maldición de FPS (**Faraón Posiblemente Solterón...** No significa eso, pero a mi me gusta mas).

Vamos a ver, de mas peor a mas mejor la manera de localizar objetos (OK Joven Lucke??):
- Forma 1: La mas chunga y que te peta el rendimiento.

```c#

[SerializeField]
GameObject objetoBuscado;

objetoBuscado = GameObject.Find("MainCamera");
```

- Forma 2: Esta tambien es chunga, pero no tan chunga como la primera.

```c#

[SerializeField] Camera cam;

cam = FindObjectOfType<Camera>();
//Aquí va a buscar un objeto de tipo Cámara
//Lo pillas Lucke??
```

- Forma 3: Esta ya va siendo menos chunga, pero no es la mas mejor, tampoco es la mas peor. Es la del medio.

```c#

[SerializeField]
GameObject cam;

cam = GameObject.FindGameObjectWithTag("Cam03");
```

Vamos acercándonos a la perfección, pero no del todo. Este forma de buscar un objeto tiene una pega... (UNA PEGA??!!! PERO QUE ME ESTAS CONTANDO... ESTO ES PERFECTO, LA OCTAVA MARAVILLA, ES UN OBRA DE ARTE PARA BUSCAR...!!) Dejame decirte que NO!!.

Piensa un poco. Aquí como ves en la instrucción, estamos buscando la referencia de un objeto, mediante su "TAG"... Bien!!! Si te has dado cuenta de ese detalle, es que eres un portento!!! Maaaaquina!!!. Sigamos...

Que sucedería si tuviéramos varios objetos con el mismo "TAG"?? (Y PORQUE TENDRIA QUE TENER VARIOS OBJETOS CON EL MISMO TAG?? SEGURO QUE TE LO ACABAS DE PREGUNTAR...) bien, yo te doy la respuesta, tu tranquilo PORTENTO... comete un Osito de Haribo para lo que te voy a contar.

Es muy común tener varios objetos con el mismo "TAG" por ejemplo, para identificar tipos de enemigos... cámaras... etc... Entonces, esta forma de localizar objetos por su "TAG", puede ser un marrón, ya que nos devolverá un objeto que coincida con el "TAG" le hemos dicho, pero no necesariamente tiene que devolvernos el que nosotros queremos, seguramente nos devolverá cualquier otro que no nos sirva...

- Forma 4: Aquí ya lo bordamos, con este nos hacen capitán de fragata.

```c#

[SerializeField] GameObject[] enemigos;

enemigos = GameObject.FindObjectsWithTag("Enemy");
//Aunque te parezca igual que el otro, no lo es, fijate que este tiene una 's' antes del With
```

Con esta forma, ya nos importa todo un pedo... Aquí buscamos todos los objetos con un tipo de "TAG" y los vamos a cargar en un `array` para después recorrer el array y buscar y operar con el que queramos... AHORA SI!!! 

Te has dado cuenta "Michael" como este si es el suyo... (DE NADA MAJETE, SE QUE ACABO DE CAMBIAR TU VIDA...).

Como hemos visto, hay muchas formas de buscar objetos dentro de nuestra escena, ya en tu mano está usar una forma u otra. Lo mas importante siempre, es que prestes atención a usar la que menos estropicio te haga al rendimiento de tu juego, ya que como te he comentado, no es lo mismo buscar un objeto entre 10 objetos que haya en la escena (ESO ES POCA COSA...) que ponerse a buscar en una escena donde puedes tener 2000 objetos... ya la cosa cambia.

UPS!!! Que se me olvidaba decirte una cosa MUY IMPORTANTE

`MUY IMPORTANTE`

`NO METAS NUNCA UN MÉTODO FIND DENTRO DEL "UPDATE". SI LO HACES, YA ENTONCES SI QUE VAS A TIRAR EL RENDIMIENTO A LA CLOACA!!!`

Advertido quedas... Luego no me cuentes que no te dije nada.

## La Clase Padre Monobehaviour

Lucke, yo, soy tu Padre!!

Bien, pues es cierto. `Monobehaviour` es la clase de la que hereda cualquier `script` en Unity. Obviamente si lo queremos usar de componente, debe heredar de `Monobehaviour`.

El ciclo de vida de `Monobehaviour` es como se muestra a continuación:

![Ciclo de Vida de Monobehaviour](https://i.stack.imgur.com/gmvWn.png)

Yo se que ahora viendo el gráfico no entiendes mucho, pero no te agobies que te lo voy a ir explicando para que te quede clarito.

Si nos fijamos, al comienzo de todo nos encontramos con el método `Awake`, este método se ejecuta antes que nada en Unity. Se ejecuta antes del método `Start`, si el `GameObject` esta activo. `Awake` se suele emplear para inicializar o referenciar.

A continuación, nos encontramos con el método `OnEnable`, el cual es llamado cada vez que el objeto que porte el `script` sea activado.

El siguiente método es `Start`, este método es llamado antes del primer *frame*, si el `script` esta activo (que también puede estar desactivado, que lo tengo que decir todo).

A partir de aquí, la cosa empieza a enrevesarse un poco. Si nos fijamos en el gráfico, veremos que tenemos un apartado que pone `Physics`. Este es el correspondiente a las físicas del juego (movimiento, colisiones, saltos, etc...). Aquí es donde entran en juego algunas cosas vistas antes, como `OnTrigger`, `OnCollision`. El encargado de las actualizaciones de las físicas, es el método llamado `FixedUpdate`, este va actualizando las físicas del juego una vez por frame, pero eso ya lo veremos un poco mas adelante. Para que lo pilles con mas claridad, es simplemente el que actualiza todo aquello que tiene que ver con las físicas y punto.

Ahora vamos a ver un método también muy importante, el cual vemos en el gráfico con el nombre `Update`. Este método es el encargado de actualizar todo aquello que tiene que ver con el renderizado (- Ya lo se... que es el renderizado?? Cuando pintas las cosas que hay en tu juego. Nubes, moñecos, bichos chungos, elementos coleccionables, chascas varias, etc... - A que ya has pillado lo del renderizado??). He decirte, que este método se llama también una vez por frame, al igual que el `FixedUpdate`.

Seguimos para bingo. A continuación, otro método que te voy a mencionar y que también es muy importante, es `LateUpdate`. Este se llama una vez por frame, peeero, siempre y cuando hayan sido ejecutados todos los métodos `Update`.

Ahora vamos abajo del todo, porque los métodos del medio, no lo voy a explicar todavía, así que ya si eso mas adelante te los cuento, de momento solamente los mas importantes.

Otro método importante es `OnDisable`, este se llama cada vez que el objeto que lleve el `script` sea desactivado. Vamos, como el método `OnEnable` pero al revés. Ya está.

Y por último y no por ello menos importante, tenemos el método `OnDestroy`. Si, este es el Destructor de Mundos, el es Thanos!!!... Dejemos a los Marvel de lado un rato. El método `OnDestroy` es ejecutado justo en el momento antes de la destrucción del `GameObject` que porta el `script`. Justo antes de destruirse el objeto, este es el método que se ejecuta (Lo vas pillando Lucke??).

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

## Gestión de GameObjects mediante Scripts
Aquí ya empieza la chicha buena. Vete por un cafelito, cola-cao o lo que te guste, que aquí hay para rato.

Y volviste con algo para meter al estomago? Pues comencemos.

Como ya hemos visto, un `script` nos permite hacer cosas con nuestros `GameObjects`, pero ademas, nos permite *instanciar* (crear) y destruir `GameObjects` en tiempo de ejecución.

El método que nos permite crear `GameObjects` es **`instantiate`**. Para usarlo, es necesario una referencia al `GameObject` que se va a crear (*instanciar*).

La sintaxis de `instantiate` es la siguiente:
```c#
instantiate(prefabReferencia, posicion, rotacion);
```

Ahora vamos a explicar sus parámetros:
- prefabReferencia: Es una referencia al `GameObject` o `Prefab` que queremos crear.
- posicion: Es un `vector3` el cual va a indicar el punto de aparición del `GameObject`que vamos a crear.
- rotacion: Es un `Quaternion` que va a indicar la rotación con que aparecerá en la escena nuestro objeto.

Para entender esto mejor, que se que puede ser lioso, vamos a ver un ejemplo y a explicarlo paso a paso.

```c#
public GameObject personajeEnemigo;
//Aqui hay mas cosas que no interesan

void Star()
{
  Instantiate(personajeEnemigo, transform.position, Quaternion.identity);
  //Mas cosas para inicializar
}
```

Bien, vamos por partes:

1. `personajeEnemigo` es un `GameObject` que hemos declarado como publico, el cual va a tener la referencia del `prefab` que vamos a querer instanciar. La referencia se la damos a través del editor de Unity, arrastrando el `prefab` o el `GameObject`.
2. `transform.position` es un `Vector3` de posición. En el ejemplo, la orden `transform.position` indica que la posición donde se va a crear el nuevo `GameObject` será justo en la posición donde se encuentra el `GameObject` que porta el `script`.
3. `Quaternion.identity`, es una variable de tipo `Quaternion`, la cual indicar la rotación. Para este ejemplo, la instrucción `Quaternion.identity`, indica que el nuevo `GameObject` se creará con la misma rotación que el objeto que porta el `script`.

De momento hasta aquí fácil verdad??

Bien, pues como hemos visto como se crean nuevos objetos en la escena, ahora vamos a ver lo divertido. Como se destruyen objetos en la escena de juego.

Para destruir un `GameObject` se usa el método `Destroy()`.

Vamos a ver como se destruye algo con un ejemplo y lo comentamos:

```c#
void OnCollisionEnter(Collision coll)
{
  if(coll.GameObject.tag == "bullet")
  {
    Destroy(gameObject, 0.5f);
  }
}
```

Vamos a ver que ha pasado aquí y que hace este ejemplo:
1. Primero, el `script` comprueba si un objeto cuyo **TAG** es "*bullet*", colisiona con el `GameObject` que tiene añadido el `script`.
2. Si el objeto cuyo "*tag*" es "*bullet*" colisiona con el `gameObject` que tiene el `script`, entonces:
  - El `gameObject` que tiene el `script` será destruido al transcurso de medio segundo (indicado como el parámetro 0.5f).

Hasta aquí no debe haber problema no?? Esto es mas simple que el mecanismo de un chupete.

Ahora vamos a ver otro ejemplo guapo. Vamos a crear un objeto, cuando presionemos una tecla.

```c#
[SerializeField]
GameObject miNuevoObjeto; //No olvidemos de referenciar a un prefab

//Aquí se están haciendo cosas... pasa mas abajo

void Update()
{
  if(Input.GetKeyDown(KeyCode.Space)) //Cuando pulsemos la barra espaciadora
  {
    Instantiate(miNuevoObjeto, transform.position, Quaternion.identity);
  }
}
```

Voy a explicarte como funciona:
1. La condición de nuestro `if` comprueba si pulsamos (`Input.GetKeyDown()`) la tecla barra espaciadora (`KeyCode.Space`).
2. En caso afirmativo de pulsar la barra espaciadora, crearemos un nuevo `GameObject`, el cual hemos referenciado previamente en la variable `miNuevoObjeto`.

Ves que facilito es esto.

Vale, ahora te voy a dar una serie de **TRUCONSEJOS** para que te ayuden a hacerte una idea de algunas cosas que podemos hacer.

**TRUCONSEJO 1**

**Cuando queramos generar nuevos objetos, como por ejemplo, balas, monedas u otra cosa, crearemos un objeto vacío "`Empty Object`", al cual se vamos a aplicar el `script` con el que crearemos los objetos que queramos.**


**TRUCONSEJO 2**

**Si queremos crear una vista en primera persona, tenemos que crear una nueva Cámara, y la pondremos de hija del objeto que queramos que tenga ese punto de visión.**

Bueno, vamos a seguir con el turrón.

Ahora vamos a ver un ejemplo de como generar objetos en un área del espacio de juego, pero de manera aleatoria.

```c#
//Estamos haciendo cosas no moleste y vaya abajo

void Update()
{
  InstantiateMyObject(miObjeto);
}

void InstantiateMyObject(GameObject obj)
{
  int x = Random.Range(18,24);
  int z = Random.Range(78,84);

  Instantiate(obj, new Vector3(x,transform.position.y,z), Quaternion.identity);
}
```

Ostras Pedrín!!! Que hemos hecho aquí??!! Naaa, tranquilo, ahora te cuento:
1. Hemos creado un método al que hemos llamado `InstantiateMyObject` y al cual le vamos a pasar como parámetro un `GameObject` al que indicamos como `obj` en su lista de parámetros.
2. Dentro del método que hemos creado, declaramos dos variables a las cuales hemos llamado `x` y `z`. A su vez, a cada una le hemos asignado un valor de manera aleatoria, el cual es aportado por la función `Random.Range`.
3. Los parámetros de `Random.Range`, nos indican que esta va a generar un número aleatorio el cual este comprendido entre un "mínimo" y un "máximo" que son indicados mediante los parámetros de esta (como por ejemplo 18,24).
4. Por último, llamamos al método `Instantiate` pasando como parámetros lo siguiente:
  - obj: El `GameObject` que vamos a crear y que es suministrado mediante el parámetro de entrada `obj` de nuestro método.
  - `new Vector3(x, transform.position.y,z)`: Estamos indicando una posición para crear el objeto en la cual se define mediante los valores que le pasamos a `Vector3`:
    - x: Variable x la cual tiene un valor aleatorio generado previamente.
    - transform.position.y: El valor de la coordenada `y` que tiene el `gameObject` que porta el `script`.
    - z: Variable z la cual tiene un valor aleatorio generado previamente.
  - Quaternion.identity: Valor de la rotación que tiene el `gameObject` que porta el `script`.

Ya ves que no es tan complicado de entender. Se que acabamos de ver muchos conceptos de golpe y porrazo, pero tranquilo que con paciencia y practica los vas a ir pillando rápido y bien.

Bueno, vamos a seguir viendo ejemplos para ir metiéndonos en la mollera todo esto. Ahora vamos a hacer algo mas chupi pirulí, vamos a ver un ejemplo de como disparar una bala cuando pulsemos una tecla (esto ya te gusta mas eeehh... que eres John Wayne...).

Antes de ver el ejemplo, voy a dar una serie de pautas a tener en cuenta:
1. Debemos tener en nuestra escena un objeto que sea el que dispare la bala (el jugador, un `prefab`, un cañón, algo...).
2. Debemos aplicar al `prefab` que vaya a corresponder con la bala, un `Rigidbody` (**ESTO ES MUY IMPORTANTE QUE NO SE TE OLVIDE DE HACER**, que después me vienes con que no te funciona... avisado quedas).
3. Tenemos que crear el `script` que va a efectuar el disparo de la bala.

Bien, ya que te he explicado como hay que hacerlo, vamos a meternos en el fregao:

```c#
public class DispararBala : MonoBehaviour
{
  [SerializeField] Rigidbody bala;
  [SerializeField] Transform salidaDeBala;
  [SerializeField] float velocidadDisparo;
  [SerializeField] float retardoSalidadBala;
  float intervaloDisparo;

  //Vete para abajo que aqui no hay nada que te interese

  void Update()
  {
    Rigidbody laBala;

    if(Input.GetKeyDown(KeyCode.Space) && Time.time > intervaloDisparo)
    {
      intervaloDisparo = Time.time + retardoSalidadBala;
      laBala = Instantiate(bala,salidaDeBala,Quaternion.identity) as Rigidbody;

      laBala.AddForce(salidaDeBala.forward * 100 * velocidadDisparo);
    }
  }
}
```

Seguro que te estas preguntando (Madre mía... pero que ha hecho este aquí??!!). Es poca cosa realmente, ahora te voy a ir explicando primero para que sirve cada cosa y que hace el código, que realmente es mu simple.

Veamos las variables, para que sirve cada una:
- `bala`: Es la referencia que vamos a realizar desde el editor de Unity al `prefab` que represente nuestra bala.
- `salidaDeBala`: Es la referencia de la posición del objeto que va a crear la bala (a partir de aquí, a los objetos que crean objetos, vamos a darles su nombre técnico correcto que es `spawner`, así que a partir de aquí acostumbrate a verlo y usarlo, vamos a ser un poco profesionales).
- `velocidadDisparo`: Va a representar un valor que será la velocidad con la que saldrá la bala una vez creada.
- `retardoSalidaBala`: Indica un tiempo de retardo, desde que se dispara una bala y hasta que se pueda disparar la siguiente. Para que no salgan todas juntas, vamos.
- `intervaloDisparo`: Es la cadencia de disparo, la cual es un valor calculado en función al tiempo.

Vale, ahora que ya sabes que es cada variable y para que sirve, te voy a explicar un poquito que hace este código:

1. Ni que decir tiene, que lo primero que hacemos es declarar las variables que vamos a usar... Yo te lo digo por si acaso.
2. Dentro de nuestro maravilloso método `Update`, creamos un objeto `Rigidbody` al cual hemos llamado `laBala` y que va a ser el que porte el `Rigidbody` del objeto instanciado.
3. Con nuestro `if` comprobamos si hemos pulsado la barra espaciadora y si el tiempo transcurrido es mayor que el valor del intervalo que hemos indicado para que salga una bala.
4. Si la condición del `if` se cumple:
  - Primero asignamos el intervalo aplicando una suma del tiempo transcurrido y del retardo de la salida de la bala.
  - Instanciamos la bala.
  - Aplicamos una fuerza a la bala con los siguientes parámetros:
    - La bala saldrá hacia delante (`salidaDeBala.forward`).
    - Multiplicado por un valor que hemos decidido que sea 100 y por el valor de la variable `velocidadDisparo`.

Realmente simple verdad? De este modo, creamos el disparo de la bala con muy pocas líneas de código y ya podemos ponernos a crear nuestro propio **Doom**. (Tranquilo Lucke, que para eso aun te queda un rato, pero vas por buen camino).

Bueno, vamos a seguir haciendo cosas con los `scripts`. Ahora vamos a crear un `script` que mueva o rote un objeto (Si ya vamos a empezar a mover cosas... poco a poco leñe, que Roma no se construyó en 3 días).

Vamos al lio, pero primero, vamos a ver que necesitamos hacer para mover o rotar un objeto:
1. Tenemos que declarar 2 variables de clase, una para los ángulos de rotación y la otra para el movimiento.
2. Tenemos que crear una función para mover y otra para rotar.

Al turrón:

```c#
public class moveAndRotate : MonoBehaviour
{
  [SerializeField] float angleOfRotation;
  [SerializeField] float distanceToMove;  

  //Otra vez mirando aquí... tira para abajo, que aquí se hacen otras cosas

  void FixedUpdate() //Acuérdate que dijimos que usamos este para mover cosas
  {
    RotateObject(); //Llamamos al método para rotar el objeto
    MovingObject(); //Llamamos al método para mover el objeto
  }

  void MovingObject() //Nuestro método para mover
  {
    if(Input.GetKey(KeyCode.UpArrow)) //Vamos a comprobar si pulsamos la flecha arriba
    {
      transform.Translate(vector3.forward * distanceToMove * Time.deltaTime);
    }
    else if(Input.GetKey(KeyCode.DownArrow)) //Comprobamos si pulsamos la flecha abajo
    {
      transform.Translate(vector3.back * distanceToMove * Time.deltaTime);
    }
  }

  void RotateObject() //Nuestro método para rotar
  {
    if(Input.GetKey(KeyCode.LeftArrow))
    {
      transform.Rotate(new Vector3(0, -angleOfRotation,0) * Time.deltaTime);
    }
    else if(Input.GetKey(KeyCode.RightArrow))
    {
      transform.Rotate(new Vector3(0, angleOfRotation,0) * Time.deltaTime);
    }
  }
}
```

Bien, que hace todo esto que hemos puesto aquí? Pues es muy simple. Básicamente lo que hace es mover un objeto por el plano horizontal hacia adelante y hacia atrás, y cuando llamamos al método `RotateObject` hace que el objeto gire hacia la izquierda o la derecha. 

Ahora voy a explicarte, que hace algunas de las funciones de nuestro `script`.

Comenzamos:
- `transform.Translate(vector3.forward * distanceToMove * Time.deltaTime)`: Básicamente esta función lo que hace es mediante `vector3.forward` es desplazar el objeto, el cual calculamos su desplazamiento, multiplicando la distancia que queremos que se mueva (`distanceToMove`) por el tiempo (`Time.deltaTime`). Acuérdate que Espacio = Velocidad * Tiempo. Aquí la velocidad la calculamos con `vector3.forward * distanceToMove` y el tiempo pues creo que queda claro cual es no? (Por si no lo tienes claro, el tiempo lo da `Time.deltaTime`).

**NOTA**

**No te voy a explicar lo que hace el if siguiente no?? Ya sabes, con DownArrow vamos a mover hacia atrás el objeto, igual que antes, pero en vez de adelante, hacia atrás (vector3.back)**

- `transform.Rotate(new Vector3(0, -angleOfRotation,0) * Time.deltaTime)`: Aquí lo que hacemos es llamar al método `Rotate`, al cual le pasamos como parámetros la rotación que queremos hacer en función del tiempo. Para ello creamos un `Vector3` cuyos parámetros los indicamos como (0,-angleOfRotation,0), esto lo que hace, es que solamente rote en torno al eje `y`, dejando fijo los otros dos. El valor de `angleOfRotation` es negativo, dado que estamos realizando un giro hacia la izquierda (sentido anti horario), para un giro a la derecha, ya habrás deducido que el valor de `angleOfRotation` es positivo, ya que gira en sentido horario. Si no lo tienes claro, imaginate un reloj de pulsera, lo normal es que las manecillas giren hacia la derecha (sentido horario, giro positivo, hacia la derecha...), con lo cual para girar a la izquierda tenemos que indicar su valor como negativo (sentido antihorario, giro negativo, hacia la izquierda...).

Ves como no era tan difícil de entender... Vamos bien mi joven amigo... Here we go, que vienen curvas.

Bueno, de momento hemos visto varias cosas:
- Como instanciar objetos.
- Como destruir objetos.
- Como mover objetos.
- Como girar objetos.

Pues bien, ahora vamos a seguir viendo como instanciar objetos... ¿Otra vez? A que te lo has preguntado mi joven Peregrin Tuk... Pues bien, la respuesta es si, otra vez pero, esta vez vamos a ver como instanciar `GameObjects` y asignarlos a un `array` de `GameObjects`, dado que hasta ahora hemos visto como hacerlo con objetos individuales, ahora vamos a rizar un poco el rizo y vamos a crear `arrays` a la vez que instanciamos.

Nada mejor que un buen ejemplo para verlo mas mejor:

```c#
//Aquí se están haciendo cosas...

[SerializeField] GameObject vehicle; 
//Array para almacenar 10 GameObjects
[SerializeField] GameObject[] createdVehicle = new GameObject[10];
int n; //Lo vamos a usar como indice de nuestro array

void Update()
{
  if(Input.GetKey(KeyCode.Space)) 
  {
    createNewVehicle();
  }
}

void createdNewVehicle()
{
  int x = Random.Range(18,24); //Posición aleatoria en el eje x
  int z = Random.Range(78,84); //Posición aleatoria en el eje z

  createdVehicle[n] = Instantiate(vehicle, new Vector3(x,transform.position.y,z), Quaternion.identity);

  n++; //Incrementamos n cuando creamos un nuevo objeto
}
```

Creo que de momento con lo que te he explicado hasta ahora, este ejemplo no es necesario que te diga lo que hace no?? o Si??...

Bueno, te haré un breve resumen.
1. Hemos creado una variable para referenciar el `prefab` que hemos llamado `vehicle`.
2. A continuación hemos creado un `array` de `GameObject` al cual hemos llamado `createdVehicle` el cual guardará un máximo de 10 `GameObject`.
3. Hemos creado una función que hemos llamado `createdNewVehicle`, la cual lo que hace es, crear un `GameObject`de `vehicle`, en una posición aleatoria y cuya rotación es la del `spawner`[^2] que porta el `script`, donde una vez instanciado el nuevo objeto, es asignado al `array` llamada `createdVehicle` en la posición indicada por `n` y una vez creado y asignado, incrementamos `n` para el siguiente objeto que se cree.
4. Como dijimos, las entradas de datos irán en el `Update`, es por ello que es aquí donde detectamos si se pulsa una tecla o no, en cuyo caso positivo, será llamada nuestro método y creando un nuevo objeto.

[^2]: Acuérdate que te dije que un `spawner` era un objeto que instanciaba `GameObjects`.

Pues ya esta, aquí te he explicado básicamente como funciona y lo que hemos hecho. Todo claro mi joven aprendiz??

Uff... mucho tute con esto de crear, destruir, mover... jope, que de cosas podemos hacer y todo lo que hemos visto en un ratito. Tranquilo, que aun queda mas, así que yo que tu me iba por un chupachups de Koyak, que esto aun va para largo.

Bueno, seguimos con lo que estamos. Recordamos cuando hablamos de los métodos `Find` para localizar cosas en nuestra escena? Pues bien, también podemos buscar objetos como ya dijimos por su clase, o buscar varios objetos y devolverlos en un `array`, pues teniendo esto claro, podemos usar ese `array` para destruir los objetos. Y como? Te estarás preguntando. Pues fácil, simplemente haciendo lo siguiente:

```c#
Destroy(variableArray[indice].gameObject);
```

Tan fácil como eso. De esa forma, localizamos el `GameObject` dentro del array y lo destruimos.

Esta vez la explicación ha sido corta.

## Otros aspectos de C#

### Corrutinas

Las corrutinas son métodos de Unity, a los cuales se les puede poner un retardo de tiempo, con el fin de pausar su funcionalidad en una parte de la ejecución, durante una serie de segundos y *frames*.

Las corrutinas se diferencian del resto de métodos que creemos en Unity, porque su valor devuelto es un `IEnumerator`.

```c#
IEnumerator myFirstCoroutine()
{
  //Estamos haciendo cosas, no moleste...
}
```

Otra cosa muy importante, es que una corrutina debe incorporar en algún punto de su código una devolución de tipo `yield return`.

Con el siguiente ejemplo, veremos mucho mejor como se define una corrutina:

```c#
IEnumerator sayHelloAfterTime()
{
  yield return new WaitForSeconds(5f); //Esta linea hace que se esperen 5 segundos antes de mostrar el mensaje
  Debug.Log("Hello Michael"); //Transcurridos los 5 segundos, se muestra el siguiente mensaje
}
```

Vamos a ver una imagen del ciclo de vida de una **corrutina**:

![Ciclo de Vida de Una Corrutina](https://i.ytimg.com/vi/n_sr1CtYi6I/maxresdefault.jpg)

De momento no es preciso que entiendas el esquema este, pero tenlo en tu cabeza, que te va a ser útil y poco a poco, mas adelante lo iras pillando.

Bueno, ya sabemos como se crea una corrutina, pero claro, ahora la pregunta es... ¿Como se llama a una corrutina?. Pues bien mi brillante amigo, simplemente añadiendo una llamada con el método `StartCoroutine(corrutina());`.

Con el ejemplo lo vas a pillar mejor. En este ejemplo, vamos a llamar a la corrutina anterior (`sayHelloAfterTime`), en nuestro método `Start()`.

```c#
private void Start()
{
  StartCoroutine(sayHelloAfterTime());
}
```

Voila!!! Tan sencillo como eso. No creo que necesite mucha explicación, no?

Si te estas preguntando si dentro de una corrutina puede haber mas de un `yield return`, la respuesta es que si. Te lo voy a poner con un ejemplito guapo guapo:

```c#
IEnumerator sayHelloAfterTime()
{
  yield return new WaitForSeconds(5f); //Esta linea hace que se esperen 5 segundos antes de mostrar el mensaje
  Debug.Log("Hello Michael"); //Transcurridos los 5 segundos, se muestra el siguiente mensaje
  yield return new WaitForSeconds(3f); //Esperamos 3 segundos antes de pasar a la siguiente línea de código
  Debug.Log("Donde vamos hoy?"); //Transcurridos 3 segundos se muestra este mensaje.
}
```

Es que estamos hoy que lo petamos. Te quejarás de todo lo que te estoy enseñando eeeh piratilla...

Como hemos visto en los ejemplos anteriores, con `yield return new WaitForSeconds(segundos)`, detenemos la ejecución un tiempo que es pasado como segundos por parámetro. Pero este no es el unico return, tambien tenemos `yield return null`, que lo que hace es pausar la ejecución un *frame* antes de ejecutar la línea de código que se encuentre a continuación de este.

Un ejemplo con `yield return null`:

```c#
IEnumerator waitForAFrame()
{
  yield return null;
  Debug.Log("Despues de un frame esperando te puedo saludar");
}
```

Las corrutinas son muy útiles para facilitarnos la vida, cuando tenemos que hacer cosas que queremos que se pausen. Pero como detalle diré que, las corrutinas no afectan al rendimiento de nuestro programa o juego (ni lo mejora, ni lo empeora), simplemente nos da una cierta comodidad para hacer cierto tipo de cosas mucho mas fáciles que si lo tuviéramos que hacer sin corrutinas.


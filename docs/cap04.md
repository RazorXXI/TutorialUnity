# Arrays

  Los `Arrays` son un tipo de estructura que permite almacenar un conjunto de datos.

  El modo de declarar un `array` es:

  ```
  tipoDatos[] NombreArray;
  ```

  Es importante indicar, que todo `array` debe ser inicializado para poder usarse.

  Las dos maneras de inicializar un array en C# son:

  - Primera Forma:

    ```c#
      tipoDato[] nombreArray = {valor1, valor2,..., valorN};
    ```

  - Segunda Forma:

    ```c#
      tipoDato[] nombreArray = new tipoDato[dimension];
    ```
  
Debemos tener presente, que un `array` puede estar declarada pero no inicializada. Si la declaramos y queremos inicializarla posteriormente, lo haremos según la segunda manera que hemos visto anteriormente.

Es muy importante tener en cuenta, que hast que un `array` no está inicializado, no puede ser utilizado. 

| **NOTA: Un array SOLO guarda valores de un mismo tipo.** |

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
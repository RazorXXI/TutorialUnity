# Capítulo 2 - Constantes y Enumeraciones
Bueno, siguiendo con lo que estabamos, vamos a ver ahora el concepto de constante y enumeración, el cual nos va a resultar muy util para hacer nuestros futuros pequeños juegos, o lo que nosotros queramos en C#.

Vamos al lio.

## Constantes
 Las constantes son datos los cuales no van a variar su valor durante la ejecución de nuestro código, al contrario que sucede con las variables.

 La forma de declarar una variables es la siguiente:

 ```
 modificador_de_acceso const tipo_dato identificador = valor_asignado;
 ```

 Si lo vemos con un ejemplo lo veremos mas claro.

 ```c#
 public const float PI = 3.14f;
 ```

 En algunos lenguajes de programación se suele poner el identificador todo en mayuscula, pero para no liarnos usaremos la misma nomenclatura que para la declaración de varibles, aunque si tu prefieres poner el identificador en mayusculas todo, no te va a dar fallo el compilador.

 Las tres razones principales para el uso de las variables son:


  * __Facilidad de Lectura:__ Si alguien ajeno a nosotros tiene que modificar nuestro código, rapidamente podrá identificar que el valor declarado como constante, será inamovible.
  * __Optimización:__ El compilador reservará una cierta cantidad de memoria durante toda la ejecución de nuestro programa, permitiendo centrar recursos en otros procesos.
  * __Seguridad:__ Al no poderse modificar su valor en tiempo de ejecución, evitaremos cambiar dicho valor por error durante la ejecución o bien por equivocación mientras escribimos el código, ya que el compilador nos informará de un error informando que estamos tratando de cambiar el valor de una constante.

## Enumeraciones
 Las enumeraciones son un tipo de variable la cual poseera un conjunto de valores constantes.

 Sé que ahora no queda muy claro, pero en breve lo pillaras rápido.

 Las enumeraciones se pueden declarar fuera o dentro de la clase, pero para seguir un orden, nosotros las declararemos dentro de la clase que estemos creando.

 La forma de declarar una enumeración será del siguiente modo:

  1 - _**Modificador de Acceso**_: 'public' o 'private'.

  2 - _**Palabra reservada**_: 'enum'.

  3 - _**Identificador de la enumeración**_: 'NumeroDeJugadores'.

  4 - _**Constantes separadas por comas y entre llaves**_: '{onePlayer, twoPlayers, noPlayers}

 Con un ejemplo lo veremos mas claro:

  ```c#
  public enum NumeroDeJugadores {onePlayer, twoPlayers, noPlayers};
  ```

 Una cosa importante a la hora de declarar una enumeración, es comenzar su identificador en mayúsculas, a fin de respetar las reglas de estilo. Y si te preguntas porque esto es así... pues sencillo, **NO ESTAMOS DECLARANDO UNA VARIABLE**, estamos declarando un tipo de dato.

 Vamos a ver otro ejemplo.

 ```c#
 public enum ObjetosInventario { Money, Food, Health, Weapon, Magic };
 ```

Todas las constantes declaradas dentro de la enumeración (*Money, Food, Health, Weapon, Magic*) tendran un valor asignado por defecto, que será un número entero, el cual comenzará por 0. Este valor se irá incrementando en 1 de izquierda a derecha (como en los indices de los arrays).

Según lo anterior, *Money* tendrá el valor 0, *Food* el valor 1 y así sucesivamente.

Por supuesto, estos valores se pueden modificar, si por ejemplo a *Money* le asignamos el valor 1, *Food* por defecto pasará a tomar el valor 2 y el resto de constantes, se verán incrementadas igualmente en 1.

Una manera común entre los programadores, es colocar las enumeraciones del siguiente modo.

```c#
 public enum ObjetosInventario {
  Money = 1,
  Food,
  Health,
  Weapon,
  Magic
 };
```

 Esta forma vista no es obligatoria, pero la mayoria de programadores la usan, asi que es aconsejable a que te acostumbres a usarla, para que tu código se vea como un autentico *"pofesional"*.

 Otro dato que te tengo que contar es que podemos asignar las constantes de la enumeración, los valores que queramos. Y para muestra un botón.

 ```c#
 public enum ObjetosInventario {
  Money = 50,
  Food = 10,
  Health = 20,
  Weapon = 15,
  Magic = 5
 };
```

 Bueno, si te estas preguntando como usar la enumeración una vez que la tengas declarada, pues facil, como cualquier otro tipo de dato.

 ```c#
 private ObjetosInventario objeto;
 ```
 Por defecto, `objeto` será `Money`, aunque también podemos asignarle en la declaración o en cualquier otro momento que queramos, un valor diferente entre los que tengamos en la enumeración, puesto que `objeto` es una variable de tipo `ObjetosInventario`.

 Te lo enseño mejor con un ejemplito bueno.

 ```c#
 private ObjetosInventario objeto = ObjetosInventario.Health;
 ```

 Mira que fácil.

 Por supuesto, también podemos hacer comparaciones con la variable o hacer asignaciones numéricas de tipo entera, usando el valor numérico asignado para el valor de la variable tipo `enum`.

 Con un ejemplo lo vamos a entender mejor.

 ```c#
 void functionWhatever()
 {
    if((int)objeto == 0)
    {
       /*
        Si suponemos que tenemos los valores por defecto 0, 1, 2, 3.
        si el valor de objeto fuera 0, el cual corresponde a Money, se ejecutarian las 
        instrucciones dentro de la condición.
       */
    }
 }
```

Bueno y ahora vamos a ver dos maneras de cambiar el valor asignado a las constantes de la enumeración.

 ```c#
 void funcionCualquiera()
 {
    //Forma 1
    objeto = ObjetosInventario.Weapon;

    //Forma 2
    objeto = (ObjetosInventario)3; //Tambien elegiria Weapon, el cual estaba numerado inicialmente como 3, numerados de 0 a n-1
 }
 ```
# Estructuras de Control

Las estructuras de control, nos van a permitir controlar y dirigir el flujo de ejecución de nuestros scripts. De ese modo podemos imponer condiciones, manejar el flujo de nuestro script mediante la comparación de valores, etc.

Así que este capítulo te va a ser realmente importante, ya que gracias a las estructuras de control que vamos a ver aquí, es como vamos a poder construir nuestros `scripts` en un futuro. Así que ponte cómodo, relajate, que este capitulo, va a ser un pelín largo, aunque trataré de condensarlo todo lo que pueda hasta la mínima expresión.

  ## Estructura if/else
  
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

  ## Estructura if/else if/else
  
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

  ## Bucle While
  
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

  | **OJO AL MANOJO:** |
  |---|
  | **Es muy importante controlar que la condición se cumpla en algún momento, dado que si no se cumple entraremos en una mierda muy gorda que en informática se conoce como BUCLE INFINITO o THE FUCKING LOOP OF DEATH, el cual permanecerá dentro del bucle toda la eternidad, dejándonos el  ordenador bloqueado, con el consiguiente fallo de nuestro juego o aplicación. Así que mi "Joven Palawan", no se te olvide de hacer que se cumpla la condición.** |

  ## Estructura Switch
  
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

  ## Bucle For
  
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

  ## Bucle Foreach

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

Bueno, como habrás podido comprobar en este capítulo, hay mogollón de estructuras para controlar lo que queremos que haga nuestro `script`, seguramente ahora no tendrás muy claro cuando emplear una u otra, pero tranquilo, que con practica y todo lo que vamos a ir viendo lo vas a tener cada día mas clarito. Y hasta aquí el capítulo de hoy, que ha sido algo espeso pero increíblemente necesario.
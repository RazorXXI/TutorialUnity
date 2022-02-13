# Otros aspectos de la programación en C#

  ## Corrutinas
  
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
  

   ### Ciclo de vida de una corrutina
   Vamos a ver una imagen del ciclo de vida de una **corrutina**:
    
   ![Ciclo de Vida de Una Corrutina](https://i.ytimg.com/vi/n_sr1CtYi6I/maxresdefault.jpg)
  
  De momento no es preciso que entiendas el esquema este, pero tenlo en tu cabeza, que te va a ser útil y poco a poco, mas adelante lo iras pillando.
  
  Bueno, ya sabemos como se crea una corrutina, pero claro, ahora la pregunta es... ¿Como se llama a una corrutina?. Pues bien mi brillante amigo, simplemente añadiendo una llamada con el método `StartCoroutine(corrutina());`, donde `corrutina()` será el nombre que le hayamos dado nosotros a la **corrutina** que hayamos creado.
  
  Con el ejemplo lo vas a pillar mejor. En este ejemplo, vamos a llamar a la corrutina anterior (`sayHelloAfterTime`), en nuestro método `Start()`.
  
  ```c#
  private void Start()
  {
    StartCoroutine(sayHelloAfterTime());
  }
  ```
  
  Voila!!! Tan sencillo como eso. No creo que necesite mucha explicación, no?
  
  Si te estas preguntando si dentro de una corrutina puede haber mas de un `yield return`, la respuesta es que SI. Te lo voy a poner con un ejemplito guapo guapo:
  
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
  
  Como hemos visto en los ejemplos anteriores, con `yield return new WaitForSeconds(segundos)`, detenemos la ejecución un tiempo que es pasado como segundos por parámetro. Pero este no es el único `return`, también tenemos `yield return null`, el cual lo que hace es pausar la ejecución un *frame* antes de ejecutar la siguiente línea de código a continuación de este.
  
  Un ejemplo con `yield return null`:
  
  ```c#
  IEnumerator waitForAFrame()
  {
    yield return null;
    Debug.Log("Despues de un frame esperando te puedo saludar");
  }
  ```
  
  Las corrutinas son muy útiles para facilitarnos la vida, cuando tenemos que hacer cosas que queremos que se pausen. Pero como detalle diré que, las corrutinas no afectan al rendimiento de nuestro programa o juego (ni lo mejora, ni lo empeora), simplemente nos da una cierta comodidad para  hacer cierto tipo de cosas mucho mas fáciles que si lo tuviéramos que hacer sin corrutinas.

  Como detalle curioso, cabe mencionar que podemos convertir el método `Start` de Unity, en una corrutina. Para ello, tan solo tenemos que cambiar `void` por `IEnumerator` y añadir `yield return` en algún punto del `Start`.

  Vamos a verlo con un ejemplito:

  ```c#
  IEnumerator Start()
  {
    yield return new WaitForSeconds(3);
    Debug.Log("Ejecutando desde Start");
  }
  ```

  ## Invoke. Que es y como se usa

  `Invoke` es un método heredado de `MonoBehaviour`, el cual básicamente lo que hace es, encontrar una función que coincide con el nombre dado y ejecutarla transcurridos un número de segundos proporcionados.

  Su sintaxis es:

  | `Invoke("NombreDeFuncion", segundos);` |
  |:---|

  Vamos a ver un ejemplo y a comentarlo para entenderlo mejor:

  ```c#
    Invoke("MiFuncion", 10f);
  ```

  En el ejemplo, el método `Invoke` está llamando a una función que le hemos pasado por parámetro como una `String` la cual hemos llamado *`MiFuncion`* y la cual se ejecutará cuando transcurran 10 segundos, los cuales hemos indicado en su paso de parámetros como `10f`.

  El método `Invoke`, tiene dos problemas fundamentales:

  * Si escribimos mal el nombre exacto de la función, `Invoke` jamas se ejecutará. Para solucionar este problema, podemos ejecutar `Invoke` de una manera mas elegante:
      | `Invoke(nameof(MiFuncion), 10f);` |
      |:---|

  De esta forma, la función `nameof` nos ayuda a autocompletar la función, evitando así el cometer fallos a la hora de escribir el nombre de esta.
   
  * Empeora el rendimiento. Ello es debido a que el uso de parámetros de entrada de tipo `String` a métodos, esta penado con una disminución del rendimiento.

Llegados a este punto, aun no quedará claro la diferencia entre la corrutina y el `invoke`, lo entiendo y es normal, de momento lo visto en esencia es lo mismo, ambos lo que hacen es temporizar la ejecución de acciones en función al tiempo. Pero hay un factor que es realmente importante y que marca la diferencia entre ambas y es que, el uso de `Invoke` no permite el paso de parámetros de entrada a la función que esté llamando, mientras que la corrutina si lo permite.

Vamos a ver un ejemplo para tener claro esto:

```c#
//Aquí también estamos haciendo cosas...

Invoke("MiFuncionTeSaluda", 5f);

//Aquí hay cosas que se están haciendo... tira para abajo

void MiFuncionTeSaluda()
{
  Debug.Log("Hola... como estas...");
}
```

Y ahora con corrutinas:
```c#
//Estamos ocupados trabajando, siga un poco mas abajo por favor
StartCoroutine(MiFuncionTeSaluda("Miguel"));

//Estamos definiendo funciones, no moleste
IEnumerator MiFuncionTeSaluda(string nombre)
{
  yield return new WaitForSeconds(5f);
  Debug.Log("Hola... como estas... " + nombre);
}
```

Como vemos en ambos ejemplos, estamos realizando lo mismo, pero con la salvedad de que al realizar la llamada con `invoke` no podemos pasarle parámetros a la función, cosa que si hacemos con la corrutina, a la cual le pasamos un parámetro de tipo `string` con el nombre de la persona a la que va a saludar.

Bueno, hasta lo que hemos visto, ya creo que podemos tener mucho mas claro la diferencia entre `invoke` y `corrutina`. He de mencionar, que a la hora de usar una u otra, es mucho mas correcto usar `corrutinas` en lugar de `invoke`, siendo mas extendido el uso de las primeras.

Así que, llegados aquí tu te estarás diciendo... (LO TENGO CLARO, A POR TABACO EL `INVOKE` Y `CORRUTINAS LOVE FOREVER`), dejame que te cuente mi joven e impetuoso amigo, que no todo son desventajas. Y si te dijera, que ademas de retrasar la ejecución de una función, también podemos hacer que cada cierto tiempo se ejecute la función que hemos creado, de manera continua en el tiempo, cada cierto tiempo... Pues si, eso si lo podemos hacer con `Invoke`, para ello usaremos `InvokeRepeating`, que justamente hace esto que te acabo de comentar.

Su sintaxis es:
|`InvokeRepeating("MiFuncion", tiempoRet, tiempoRep);`|
|:---|

Donde:
  - _tiempoRet_: Es el tiempo que transcurrirá en segundos, hasta que la función sea llamada.
  - _tiempoRep_: Es el tiempo que transcurrirá en segundos, hasta que se vuelva a ejecutar nuevamente la función.

Aquí ya la cosa se pone interesante, por ejemplo imagina, que cada cierto tiempo quieras que en un punto de tu juego, salgan enemigos cada 10 segundos  cada vez. Pues esto lo haría `InvokeRepeating`. Pero... y si en un momento determinado queremos parar esto... No supondría un problema, ya que para ello, tenemos la función `CancelInvoek` que hace justo esto que hemos comentado.

`CancelInvoke`, tal y como acabamos de decir, detiene los `Invoke` que estén en ejecución, pero ojo al dato _DETIENE TODOS LOS INVOKES QUE ESTEN EN EJECUCION_, así que si por ejemplo la vas a usar para detener un `Invoke` en concreto, ten presente de volver a activar todos los demás que realmente necesites que estén en ejecución, ya que al llamar a `CancelInvoke`, estos habrán sido detenidos igualmente.


  
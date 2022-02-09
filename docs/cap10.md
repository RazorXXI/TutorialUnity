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

  El método `invoke`, puede resultarnos muy similar a la corrutina, dado que lo que hace es al igual que las corrutinas, el temporizar la ejecución de código. Y tu te preguntaras... ¿Cual es la diferencia? Bueno, la diferencia aparte del rendimiento (`invoke` tiene peor rendimiento que una corrutina), es que permiten temporizar la llamada a métodos, ofreciendo así un mecanismo sencillo para construir temporizadores y ejecutar acciones que se van a repetir cada cierto tiempo.

  En esencia, básicamente son casi iguales, aunque la corrutina es mucho mas potente, ya que la corrutina a diferencia de `invoke`, puede crear metodos con mas de una interrupción.

  Pero, que nos desviamos del tema. 

  Para usar un `invoke`, tan solo deberemos crear nuestras funciones como ya sabemos hacer, y si no lo sabes, entonces vas a tener que revisar el [Capítulo de Funciones](./cap05.md). 

  Para invocar una función, tan solo tendremos que emplear la siguiente sintaxis en el lugar del código que vayamos a emplear `invoke`.

  Vamos a ver un ejemplo:

  ```c#
  public class EjemploUsoInvoke : MonoBehaviour
  {
    void Start()
    {
      Invoke("SaludandoConInvoke", 5f);
    }

    void SaludandoConInvoke()
    {
      Debug.Log("Hola, te estoy saludando y me han llamado con Invoke");
    }
  }
  ```

  Bien, como funciona esto.

  1. Tenemos una función, que se llama `SaludandoConInvoke`, la cual lo que hace es mostrar un mensaje por la consola de Unity.
  2. Dentro del `Start`, nos encontramos la llamada al método `Invoke`, al cual se le pasan como parámetros lo siguiente:
    - Un `string` con el nombre de la función que queremos invocar (_fijate bien, que esta pasado solo el nombre como string_).
    - El segundo parámetro, es el tiempo que va a tardar `Invoke` en llamar a la función, en este caso, la función `SaludandoConInvoke`.

Si nos fijamos, el concepto es bastante similar a las corrutinas. El uso de una manera u otra de temporizar, es elección tuya. Ahora, que como ya te he comentado, las `corrutinas` tienen un rendimiento mas óptimo que el uso de `invoke`. Tambien es cuestión de legibilidad, y las corrutinas favorecen mucho mas el orden en nuestro código. Ahora es cuestión tuya de usar una u otra, tu mismo con tu mecanismo.


  
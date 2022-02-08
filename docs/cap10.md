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
  
  Como hemos visto en los ejemplos anteriores, con `yield return new WaitForSeconds(segundos)`, detenemos la ejecución un tiempo que es pasado como segundos por parámetro. Pero este no es el unico return, tambien tenemos `yield return null`, que lo que hace es pausar la ejecución un *frame*  antes de ejecutar la línea de código que se encuentre a continuación de este.
  
  Un ejemplo con `yield return null`:
  
  ```c#
  IEnumerator waitForAFrame()
  {
    yield return null;
    Debug.Log("Despues de un frame esperando te puedo saludar");
  }
  ```
  
  Las corrutinas son muy útiles para facilitarnos la vida, cuando tenemos que hacer cosas que queremos que se pausen. Pero como detalle diré que, las corrutinas no afectan al rendimiento de nuestro programa o juego (ni lo mejora, ni lo empeora), simplemente nos da una cierta comodidad para  hacer cierto tipo de cosas mucho mas fáciles que si lo tuviéramos que hacer sin corrutinas.
  
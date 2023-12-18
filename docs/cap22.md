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

En dicho proyecto, voy a emplear un sprite cuadrado para simular nuestra nave, voy a crear un material para aplicarselo al disparo laser y al que llamaré `laserMaterial`, una zona en la parte superior donde colisionarán los laseres, el contenedor para la piscina de objetos, el prefab para el disparo laser, y si se me olvida algo más, pues te lo iré contando aquí mas abajo.

Para ver una forma y otra, he preparado dos escenas, en las cuales en una hacemos los disparos sin `Object Pooling` y en la otra usando el `Object Pooling`

Ahora te voy a enseñar como queda la escena con y sin object pooling que he preparado para el ejemplo, que a efectos de diseño visual no afecta para cada caso, asi que, queda tal que así en ambos casos. La diferencia va estar en los `scripts` para poder disparar nuestro *laser*.





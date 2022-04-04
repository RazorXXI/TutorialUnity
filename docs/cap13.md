# Capítulo 1 - Físicas en Unity 3D

Una de las partes importantes de cualquier juego, es el uso y comportamiento de las físcias. Esto es basicamente todo aquello relacionado con la emulación de las caracteristicas físicas del mundo real (choques, velocidad, aceleración, grabedad, etc...).

Unity tiene un potente motor de físicas, el cual nos permite emular todo esto con relativa facilidad (tranquilo, que lo vamos a ver... o a caso te pensabas que esto habia terminado? Pues NO). Resumiendo todo un poco, podemos llegar a la conclusión, que en cualquier juego, por simple que sea, hay que tirar de físicas si o si, ya que una de las cosas mas importantes para controlar un juego o tener un cierto comportamiento, son las colisiones.

Pues bien, que me voy por las ramas. Como hemos visto antes, tenemos varios componentes que nos permiten hacer cosas o dotar de un comportamiento a un GameObject. Los dos que van a permitirnos que dicho `GameObject` tenga físicas van a ser dos:
 
 * El componente `Rigidbody`.
 * El componente `Collider`.

## El Componente Rigidbody

El componente `Rigidbody` es el que nos va a permitir simular comportamientos físicos en nuestro `GameObject`, permitiendo así a este último, el ser afectado por la gravedad o responder a las colisiones.

El componente `Rigidbody` tiene una serie de parámetros que serán los que modifiquemos para hacer que el objeto tenga una serie de caracteristicas físicas. A continuación vamos a enumerarlos y comentarlos brevemente, para posteriormente ampliar un poco mas sobre ellos.

 - **Mass**: Representa la masa del objeto en Kilos.
 - **Drag**: Es la resistencia al aire, cuando el objeto es movido al aplicar una fuerza. Gracias a el, el objeto podrá frenar su velocidad al aplicarle una fuerza lineal.
 - **Angular Drag**: Es la resistencia al aire cuando el objeto es girado por una fuerza.
 - **Use Gravity**: Permite que la gravedad afecte al objeto, si esta activada esta opción.
 - **Is Kinematic**: Si la opción está activada, las físicas del motor dejaran de afectar a nuestro `GameObject`, el cual solo podrá moverse, empleando su componente `Transform`.
 - **Interpolate**: Sirve para que cuando estemos usando físicas, al mover el objeto, notemos un comportamiento extraño, como por ejemplo ir a tirones o que vibra al desplazarse, podemos usarlo para suavizar esto. Este parámetro, tiene 3 valores que podemos aplicar:
     - **None**: Interpolación desactivada.
     - **Interpolate**: El movimiento será suavizado basandose en la posición del *Transform* del frame anterior.
     - **Extrapolate**: El movimiento será suavizado basandose en la posición del *Transform* del frame siguiente.
 - **Collision Detection**: Sirve para que los objetos que se mueven a mucha velocidad (mediante la aplicación de fuerzas físicas), no atraviesen otros objetos, al no detectar la colisión. Sus valores son:
     - **Discrete**: Es el valor por defecto, para detectar colisiones. Es utilizado para colisiones normales.
     - **Continuous**: Se emplea para la detección de colisión contra colisionadores dinámicos (aquellos que tienen Rigidbody).
     - **Continuous Dynamic**: Se emplea para evitar que el objeto con el Rigidbody, pueda atravesar el `Mesh Renderer` y a través de otros objetos con `Rigidbody` los cuales tienen configurada su `Collision Detection` como `Continuous`, cuando se mueven muy rápido. 
     | **IMPORTANTE** |
     |---|
     | Este método de detectar colisiones es el mas lento y solo se deberá usar en objetos que se tengan que mover muy rápido |

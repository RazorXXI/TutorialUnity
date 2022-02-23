# Una Breve Introducción

El lenguaje de programación empleado en Unity es C#. C# es un lenguaje de programación orientado a Objetos.

![Unity](http://www.mac-torrent-download.net/wp-content/uploads/2015/04/Unity_3D_Pro_icon.jpg)  ![C Sharp](https://i.pinimg.com/originals/1f/f7/2b/1ff72b4775783f3308b44b3a916eb437.png)

Una cosa que debemos tener clara a la hora de programar en Unity, es el concepto de `GameObject`, dado que esto no es un objeto al uso como se entiende en programación.

A la hora de desarrollar scripts en C# para Unity, debemos tener algunas cosas claras:
- El nombre del archivo será algo descriptivo sobre la funcionalidad que vaya a tener.
- El nombre del archivo será por defecto el nombre de la clase.
- Si cambiamos el nombre del archivo, deberemos cambiar manualmente y de manera obligatoria el nombre de la clase.

Teniendo presente esto, vamos a entrar en materia.

La clase fundamental y principal de la cual heredan todos en Unity, es la clase `MonoBehaviour`. Esta clase permite que podamos poner nuestros scrits, como componentes de un `GameObject`.

A modo de detalle, podemos indicar, que la clase `MonoBehaviour` está indicada para realizar juegos pequeños y medianos, dado que para juego grandes triple A, no se utiliza tanto.

# El Componente Script

Los `scripts` son componentes que nos permiten definir un comportamiento específico para nuestra aplicación o juego.

Como hemos indicado al principio, los `scripts`en Unity, están escritos en el lenguaje C#. Todos los `scripts`son tratados como `assets` que pueden ser añadidos a nuestro juego o aplicación.

Cuando se crea un script, por defecto Unity incluye dos métodos:
- `Start`: El cual es llamado por Unity una sola vez al comienzo del juego y cuando se crea un `GameObject` en tiempo de ejecución. Este método es usado por lo general, para inicializar valores o encontrar asignaciones.
- `Update`: Este método es llamado cada `frame`, y se suele emplear para aplicar:
  - Movimiento.
  - Controlar un cronómetro.
  - Para respuestas a entradas de usuario (`inputs`).

En cada `script`y clase, lo ideal es que se haga unicamente una sola funcionalidad concreta.

Se pueden crear tantos `scripts` como comportamientos queramos que tenga nuestro `GameObject` (saltar, correr, disparar, etc...)

Una cosa que debemos tener presente, es que un mismo `script`puede estar incluido a mas de un `GameObject` distinto. Por ejemplo, un enemigo puede saltar, al igual que puede saltar nuestro personaje o morir, `es algo muy común el reutilizar para mas de un GameObject un script`.

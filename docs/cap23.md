# Capítulo 5: Conceptos de Programación Avanzada
## 5.9 - Patrones de diseño III (Singleton)

Este patrón de diseño es de los mas utilizados en el desarrollo de videojuegos.

El `Singleton` tiene tanto admiradores como detractores, a continuación veremos cuando usarlo, como hacerlo y sobre todo sus pros y sus contras, ya tú decidirás si lo usas o no.

### 5.9.1 - Definición y usos
---
En su defición por defecto, un `singleton` es una clase que cumple las siguientes dos condiciones:

 * Es accesible globalmente.
 * Solo puede existir una única instancia de esta clase.

Al cumplirse estas dos condiciones, el `singleton` permite acceder facilmente desde cualquier parte del juego que estemos desarrollando, desde cualquier otro objeto.

Un ejemplo muy común del uso del `singleton` es un `AudioManager`. Al hacer al `AudioManager` como un `singleton`, este podrá ser accedido desde cualquier parte del juego, a una única instancia del mismo. Por ejemplo, si este manager tiene un método para reproducir sonido llamado `PlaySound`, este podrá ser utilizado desde cualquier parte del juego, bien desde un player, bien desde un objeto, etc.

Sigamos con el ejemplo del `AudioManager`.

Supongamos que tenemos a nuestro *AudioManager* como `singleton`, y que nuestro `player`, debe reproducir un sonido, al chocar con algo. Esto, será llamado desde nuestro manager de audio en cualquier punto del juego, directamente por nuestro player, ya que al ser `singleton` dicho `AudioManager`, podrá ser globalmente accedido por cualquier objeto del juego, en este caso el `player`.

Y tal y como hemos indicado en el parrafo anterior, esto también podrá ser accedido por un `enemy`, un `canvas`, un `GameManager` o cualquier otro objeto que necesite reproducir un sonido en nuestro juego.

Seguimos explicando donde normalmente se usa el `singleton`, y sus usos más habituales son en:

 * Game Managers
 * Audio Managers
 * User Interface Manager (menus del juego)
 * Spawners (enemigos, objetos u otro spawner)
 * Camera Managers
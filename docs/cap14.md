# Mas Física. Joint que te Joint y Character Controller

Bueno mi joven padawan, vamos a seguir ahora viendo mas sobre las físicas, dado que esto es lo que va a permitir dotar a nuestro juego de realismo y funcionalidad (por supuesto, siempre apoyados sobre nuestros Scripts, que son los que van a producir la autentica magia).

Como ya sabemos, una cosa fundamental de los juegos, es detectar colisiones, dado que gracias a estas, podemos saber si estamos sobre algo, si nos da algo o si le damos un impacto a algo (bala que mata a malo malote o malo malote que te mata a ti). Siendo un poco, o bastante pesado en esto, vuelvo a recalcar que para poder detectar colisiones es necesario tener dos cosas:

 - Rigidbody
 - Collider

Sin estos dos elementos, es imposible el poder detectar ninguna colisión usando el motor de físicas de Unity.

Bueno, vamos a dejar un rato las colisiones y vamos a empezar con una cosa nueva... Tatachiaaan!!! `Joints`.

## Joints

Bueno, vamos a ver, si vamos literalmente a la traducción de su significado al español, esto significa `Uniones`... Y para que sirven, que son exactamente, se comen...?? Voy a ir por partes, respondiendo a la última pregunta... No son comestibles, pero si son muy útiles. Sobre que son, pues bien, tal y como hemos dicho son uniones, basicamente lo que hacen es unir un objeto de tipo `Rigidbody` con otro o directamente a un punto que sea fijo, para esto se usan los componentes `Joint` los cuales sirven para dar una cierta libertad de movimiento al `Rigidbody` en cuestión.

Supongo que tu cerebrito habrá empezado a cabilar y a ver que se puede unir, que no, como cuando, que fue primero la gallina o el huevo?? Tranquilo, ahora te lo explico para que no tengas angustia existencial.

Unity dispone de varios tipos de `Joints` tanto para 3D como para 2D. Yo te voy a contar sobre los de 3D, pero básicamente los de 2D son iguales o casi iguales y su nombre de componente termina en 2D, no hay mucho que pensar.

Los tipos de `Joints` que tenemos son:

 - Fixed Joint: Este tipo de `Joint`, sirve para mantener unidos dos objetos. Este `joint` restringe el movimiento de un objeto al ser dependiente de otro. Obviamente, podemos conseguir que ambos objetos rompan la unión del `fixed joint` si se da un cierto suceso, como puede ser una colisión u otra cosa.
  En la [documentación de Unity](https://docs.unity3d.com/Manual/class-FixedJoint.html), podemos conocer todas las opciones de este tipo de unión. Aunque te pondré un ejemplito to guay para que lo pilles mejor.

 - Hinge Joint: Este `Joint` su traducción significa `Unión Bisagra`. Así que partiendo de esto, en definitiva lo que hace, es conectar a dos `Rigidbody` y limitar su movimiento como si estuvieran unidos por una bisagra. En mogollón de juegos se usan para puertas, pendulos de la muerte, cadenas, trampillas... en fin, en un montón de cosas. Y al igual que en el anterior, te voy a invitar a que te acostumbres a visitar la [documentación de Unity](https://docs.unity3d.com/Manual/class-HingeJoint.html), para saber que opciones tiene, que todo no te lo voy a dar mascado no??.

 - Spring Joint: Pues `Spring` es muelle en inglés, asi que esta unión se comporta como un muelle, ya está, así de simple. Te lo vuelvo a repetir, se que soy muy pesado, pero revisa la [documentación de Unity](https://docs.unity3d.com/Manual/class-SpringJoint.html) para enterarte bien de los parámetros de esta unión. Que si, que está en ingles. Pero es que en informática la gran mayoría de las cosas están en inglés, así que ya sabes, toca ponerse las pilas con el inglés o tirar del traductor de Google.

 - Character Joint: Aquí no te voy a traducir esto, y mejor te explico de que va esta unión. `Character Joint` básicamente su función es relajar completamente las articulaciones de un personaje 3D, haciendo el `efecto Ragdoll`[^1]. Y para que sirve? Pues un ejemplo sería cuando muere el personaje. Igualmente, puedes consultar toda su información, en la [documentación de Unity](https://docs.unity3d.com/Manual/class-CharacterJoint.html).

 - Configurable Joint: Este `joint` se usa para tocarle los bajos al motor de Unity para personalizar a tope el `joint`. No lo voy a explicar aquí, pero si te dejo un enlace a la [documentación de Unity](https://docs.unity3d.com/Manual/class-ConfigurableJoint.html), para que lo veas y conozcas mas en profundidad.

## Character Controller

Y seguimos metiendo conceptos en tu cerebro, asi a cascoporro. Ahora es el turno del componente `Character Controller`.

Este componente básicamente es usado para los controles de jugador en tercera o primera persona y que no usa la física del `Rigidbody`.

Sus parámetros son:
  
 - [Slope Limit]: 

 [^1]: Efecto que se utiliza para animar de forma no manual a personajes, generalmente cuando mueren. Sirve para darles un efecto como de muñeco de trapo, de manera que al caer muertos, caigan de diferentes maneras. Un ejemplo de esto, lo podemos ver en las muertes de los personajes de los juegos GTA a partir del IV.
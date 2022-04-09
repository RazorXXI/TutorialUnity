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
  
 - Hinge Joint:
 - Spring Joint:
 - Character Joint:
 - Configurable Joint:
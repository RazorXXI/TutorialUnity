# Capítulo 5: Conceptos de Programación Avanzada
## 5.7 - Patrones de Diseño I (Definición)
Bueno mis queridos amiguitos, en este capítulo vamos a ver una cosa muy util a la hora de realizar nuestros juegos, es lo que se conoce como `Patrones de Diseño`.

Para que se entienda mas o menos claro que son los patrones de diseño, voy a intentar dar una explicación mas o menos resumida de que son y cual es su propósito.

### 5.7.1 - Definición de Patrón de Diseño
---
Un patrón de diseño, es una solución habitual a un problema que ocurre con frecuencia en el diseño de un software.

Son una serie de soluciones de código que se pueden personalizar para solucionar un problema recurrente.

La idea de un patrón de diseño, no es un bloque de código específico, sino un concepto general para poder implementar una solución que encaje con las necesidades de nuestro juego, software, etc...

### 5.7.2 - Clasificación de los Patrones de Diseño
---
Hay varias maneras de clasificar a los patrones de diseño, pero para nuestro caso, que es el que nos importa, los vamos a catalogar según su propósito:

 * **Patrones Creacionales**: Son aquellos que proporcionan mecanismos de creación de objetos, incrementando la flexibilidad y reutilización del código existente.

 * **Patrones Estructurales**: Explican como ensamblar objetos y clases en estructuras mas grandes, a la vez que se mantiene la flexibilidad y eficiencia de la estructura

 * **Patrones de Comportamiento**: Se encargan de una comunicación efectiva y de la asignación de responsabilidades entre objetos.

Se que ahora todo lo que he escrito en la clasificación te suena a chino, soy consciente de ello. Pero una vez termine con esto, vas a ser un `'fucking god'` en estos menesteres, ya verás.

### 5.7.3 - Ampliación de la clasificación de Patrones
 ---
 En este punto, vamos a enumerar algunos de los distintos tipos de patrones de diseño. Obviamente no los vamos a ver todos, aunque si los mas importantes que nos van a facilitar la vida para realizar juegos o aplicaciones con Unity.

 Según los tipos de patrones, podemos identificar los siguientes.

 1. **Patrones Creacionales**:
  
     * _Factory Method_
     * _Abstract Factory_
     * _Builder_
     * _Prototype_
     * _Singleton_
     * _Monostate_
     * _Object Pool_

 2. **Patrones Estructurales**:
 
     * _Adapter_
     * _Bridge_
     * _Composite_
     * _Decorator_
     * _Facade_
     * _Flyweight_
     * _Proxy_

 3. **Patrones de Comportamiento**:

     * _Chain of Responsability_
     * _Command_
     * _Iterator_
     * _Mediator_
     * _Memento_
     * _Observer_
     * _State_
     * _Strategy_
     * _Template Method_
     * _Visitor_

Seguramente si te has puesto a indagar un poco, el que mas te sonará sera el `Singleton`, este junto al `Object Pool` son los dos mas conocidos en el desarrollo de videojuegos, pero eso, ya lo iremos viendo mas adelante. Sin prisa mi joven Skywalker.

En el siguiente capítulo te enseñaré como implementar el `Object Pool` y el `Singleton`. Y si se me ocurre algún otro que pueda ser interesante, pues lo incluiré, pero eso ya me lo iré pensando sobre la marcha, que prisa no hay y ademas `la prisa mata, amigo`.
# Capítulo 3 - Materiales, Texturas y Shaders

Bueno mi joven padawan, hoy toca hablar sobre los materiales. Te voy a dar primero la explicación de lo que son los materiales en unity y después vamos a profundizar un poco mas. En principio este capítulo no va a ser demasiado extenso o al menos es lo que voy a intenar, pero claro lo mas importante es dejar todo clarito y muy mascadito para que no haya dudas, que sino despues me dices que no te has enterado.

## Materiales y Texturas

Los **materiales** son archivos que van a definir como se va a comportar visualmente una superfice cuando la luz incida en ella y a la hora de ser renderizada.

Las opciones de los materiales van a depender del `shader` que este usand.

Para crear un material en Unity lo podemos hacer de dos maneras:

 1 - Desde el menú principal de Unity: Assets -> Create -> Material
 2 - Desde la ventana Project, dentro de la carpeta Assets con el botón izquierdo del ratón: Create -> Material

Una vez creado, tendremos un archivo al cual le habremos dado el nombre que nosotros queramos y en la venta inspector, tendremos todas sus propiedades.

![Material Inspector](/img/15_InspectorMaterial.png)

Por defecto Unity usa el `shader Standard` cuando creamos un material, el cual tiene las propiedades que vemos en la imagen anterior y que ahora explicaremos detalladamente:

 - Rendering Mode: Este parámetro sirve para elegir si el objeto usa transparencia. Podemos elegir de una lista de valores.
     
     * **Opaque**: Es el valor predeterminado y es el que normalmente se usa para objetos solidos sin areas transparentes.
     * **Cutout**: Nos permite crear un efecto de transparencia que tiene bordes duros entre las áreas opacas y transparentes. Si elegimos este modo, no hay zonas semitransparentes, siendo la textura 100% opaca o invisible. Es muy empleado cuando se quiere usar la transparencia para crear materiales como hojas, telas con agujeros o similares.
     * **Transparent**: Esta opción nos permite crear renderizados de materiales transparentes bastante realistas, tales como plastico transparente o vidrio. En este modo, el material si tendrá valores de transparencia (basados en el canal alfa de la textura y el alfa del color del tinte), pero los reflejos y las luces serán visibles con plena claridad, tal y como sucede con los materiales transparentes de la vida real.
     * **Fade**: Permite que los valores de transparencia desvanezcan por completo un objeto, incluyendo los reflejos que este pueda tener. Se suele emplear para hacer desvanecerse un objeto, por ejemplo para simular a un holograma.
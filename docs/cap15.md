# Capítulo 3: Físicas, Inputs y Otros Menesteres
## 3.3 - Materiales, Texturas y Shaders

Bueno mi joven padawan, hoy toca hablar sobre los materiales. Te voy a dar primero la explicación de lo que son los materiales en unity y después vamos a profundizar un poco mas. En principio este capítulo no va a ser demasiado extenso o al menos es lo que voy a intenar, pero claro lo mas importante es dejar todo clarito y muy mascadito para que no haya dudas, que sino despues me dices que no te has enterado.

### 3.3.1 - Materiales y Texturas
---
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

 - Albedo: Es el parámetro encargado de controlar el color base de la superficie del material que estemos creando. El albedo es usado para asignar una textura, la cual será la base de nuestro material. También se puede asignar un color sólido al albedo.
 
 Es importante indicar, que si hemos seleccionado como rendering mode `transparent`, el valor alfa del Albedo será el encargado de controlar el nivel de transparencia del material.

 ![Canal Alfa](/img/15_CanalAlfa.png)

 - Metallic: Es el parámetro encargado de controlar sobre la metalicidad de la superficie. Este hace que simule una superficie parecida al metal. Una superficie metálica refleja mas luz del ambiente y el valor de su albedo se hace menos visible. Si el valor de metallic esta al 100%, el color de la superficie será controlado completamente por las reflexiones del ambiente. La reflectividad y la respuesta a la luz serán modificadas por sus controles deslizantes `Metallic` y `Smoothness`, este último controlará la suavidad de la superficie.

 Si asignamos una textura al parámetro Metallic, el control `Metallic` desaparecerá y los niveles metálicos serán controlados por el canal rojo de la textura.

 - Normal Map: Esto son un tipo de texturas especiales que permiten agregar detalles a las superficies, como bultos, rayones, surcos y otros. En este, la luz es atrapada como si estuviera representado por un objeto geométrico real en la escena.

 - Height Map: Este parámetro se usa con una textura para HeightMap, la cual sirve para usar una técnica conocida como `paralax height mapping`. Esto consiste en dar una definición adicional a una superfice, de manera que en un golpe o bulto, el material tendrá un detalle en su lado mas cercano a la cámara, mas expandido o exagerado, mientras que esos detalles mas alejados de la cámara, se verán mas reducidos según lo miremos. Los `height maps` son archivos con una textura en escala de grises, donde las zonas blancas representan las zonas elevadas y las areas negras, representan las zonas mas bajas.

 - Occlusion Map: Se usa para para dar información sobre las sombras en el modelo. Básicamente lo que hace es decidir en que áreas se debe recibir iluminación indirecta fuerte o debil. La iluminación indirecta viene de la iluminación ambiente y de los reflejos, de manera que por ejemplo, una zona concava en la realidad, no recibiría mucha luz indirecta (por ejemplo una grieta). En un mapa de oclusión se definen que zonas estan expuestas y cuales ocultas a la iluminación ambiente.

 - Detail Map: Se emplea para poder aplicar una textura que nos dé un detalle más nítido al ver el objeto de cerca (por ejemplo poros en la piel de un personaje), al mismo tiempo que tiene un nivel de detalle normal cuando es visto desde lejos. El uso de este  parámetro, es por ejemplo para agregar poros o pelos en la piel de un personaje, grietas en una pared de piedra, arañazos o desgastes en una superfice metálica, el veteado en una superficie de madera, entre otros.

 - Emission: Sirve para controlar el color y la luz emitada desde la superficie de un objeto. Funciona como una fuente de luz en la escena. De este modo el objeto parece estar iluminado. Se puede emplear, para simular objetos que emiten luz, como por ejemplo, la pantalla de un televisor, una bombilla, un farol, un panel de control con controles luminosos como botones o indicadores, unos ojos en la oscuridad o un sable laser. Para activar la emisión, simplemente marcamos la casilla que viene al lado. Tambien podemos definir materiales emisivos con un solo color basico y ajustar su color y nivel de intensidad. También, podemos asignar una textura con un mapa de emisión, de esta manera se puede tener un control mas ajustado de que áreas parecerán que estan emitiendo luz. También disponemos de otra opción más para controlar la emision, esta es `Global Illumination`, que permite especificar como afecta la luz emitida a la iluminación de otros `Game Objects` que estén cerca. `Global Illumination` dispone de dos opciones para seleccionar:

     * Realtime: Esta opción hace que Unity agrege la luz emitida del material a los cálculos de iluminación global de la escena, en `tiempo real`. Esto hace que la luz emitida, afecte a la iluminación de los `Game Objects` que esten cerca, includos aquellos que estén en movimiento.
     * Baked: En esta opción, la luz emitida se incorpora en los mapas de luz estáticos de la escena, de este modo otros `Game Objects` estáticos de la escena parecen estar iluminados por este material.

Hay otras opciones al hora de definir el material, pero las mas importantes son todas estas anteriores. De todas formas, si tienes curiosidad e interes, siempre te puedes dar una vuelta por la página de documentación de Unity, donde encontraras respuestas a estas y otras cuestiones.

Y hasta el momento, hemos hablado de materiales, pero el título de este apartado también indica `Texturas`, así que por eso vamos a explicar ahora sobre que es una textura.

Las `texturas` no son otra cosa que imágenes que se aplicaran a una malla 3D. Tal y como hemos visto antes con los materiales, estos pueden tener una o mas texturas, de forma que el `shader` elegido para este material, será el que se encargue de usarla para poder calcular su apariencia visual. Las texturas pueden representar otros aspectos tales como la reflectividad o rugosidad de una superfice.

Si estuvieramos hablando del modo 2D, estas texturas las habriamos llamado `Sprites` que aunque siguen siendo imagenes, estas son utilizadas de manera distinta al modo 3D. Con `sprites`, se puede animar un personaje en 2D o también crear escenarios completos.

### 3.3.2 - Shaders
---
Hasta el momento, hemos solo nombrado a los `shaders` pero aun no hemos definido que son y que hacen. Es aquí donde te va a quedar bastante claro de que se trata el tema.

Un `Shader` es un código que contiene una serie de cálculos matemáticos que van a servir para calcular el color de cada pixel a la hora de ser renderizado. Esto se basa en el *input* de la iluminación y de la configuración del material. Gracias al `Shader` obtendremos el resultado final que queremos mostrar por pantalla.

Por defecto Unity, trae una serie de `Shaders` incluidos cuando se instala. Estos vienen en varias categorias las cuales son:

 - FX: Iluminación y efectos de cristal.
 - GUI y UI: Para los gráficos relacionados con la interfaz de usuario.
 - Mobile: Adaptado a los dispositivos moviles, con un rendimiento menos exigente.
 - Nature: Para arboles y terrenos.
 - Particles: Para efectos de sistemas de particulas.
 - Skybox: Para entornos de fondos tales como, montañas, cielos, ciudades, fabricas o cualquier cosa que este al fondo de toda la geometría de la escena.
 - Sprites: Empleado para Sprites 2D.
 - Unlit: Para renderizados donde se ignora toda luz y sombreado.
 - Legacy: Shaders antiguos de Unity.

### 3.3.3 - Información sobre la luz
---
Ya para acabar este capítulo vamos a tratar dos puntos que creo son importantes estos son:

 - Conservación de Energia (Energy Conservation).
 - Alto Rango Dinámico (HDR).

#### 3.3.3.1 - Conservación de Energia
---
Esto es un concepto de física el cual dice que, los objetos no pueden reflejar mas luz de la que reciben.

Con la base de esta explicación, Unity nos dice que, cuanto menos "*specular*" sea un material, menos difuso debe ser, y que cuanto mas suave es una superficie, mas fuerte y pequeño será el resalte de la luz.

#### 3.3.3.2 - Alto Rango Dinámico
---
El `Alto Rango Dinámico`, es una técnica que trata de simular el comportamiento del ojo humano en los motores gráficos. Y esto como es? Pues te voy a dar una explicación del estilo del **Hombre y la Vida**.

Cuando el ojo humano está mirando un objeto en la vida real, el ojo trata de ajustarse a las condiciones de la luz en la zona donde se encuentra el observador y hacia la zona a la que está mirando. Por ejemplo, si estas en la calle en un dia soleado tu pupila se contraera para ajustarse a la iluminación de donde estas, pero si al mismo tiempo miras hacia una zona que se encuentra en la sombra, el ojo reajustará la pupila para poder ver mas detalle de la zona que está en la sombra, la cual está menos iluminada que en la zona que se encuentra el observador y que está plenamente iluminada por la luz solar.

Y hasta aquí el capítulo de hoy, espero que haya sido productivo y didactico. De todas formas, no seas vago y tómate la molestia de buscar por ti mismo sobre estos temas si te entra curiosidad, cosa que deberias. Asi que por hoy, colorín colorado, este cuento se ha acabado.
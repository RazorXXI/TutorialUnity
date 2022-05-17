# Animaciones. Animation y Animator

Y es en este punto que vamos a aprender a que los muñecos se mueva.

Si Michael, vamos a darle vida a nuestros pobres seres innanimados para convertirlos en seres vivientes.

Como dijo el doctor Frankenstein:

 > Vive, Igor!!! Mi criatura vive!!!

Pues eso... vamos a ver como hacer que vivan.

Antes de proseguir, hemos de contar lo siguiente. Para crear animaciones, Unity dispone de un motor de animaciones el cual se divide en dos partes bien diferenciadas:

 - Animations
 - Animator

Serán estas dos partes las que nos van a permitir poder crear nuestras animaciones, así como el comportamiento de estas. Se que ahora mismo suena a chino, pero pronto cobrará mas sentido.

## Animation

En `Animation` será donde se vayan generando nuestro clips de animación a partir de un modelo 3D o bien de otro objeto.

Aquí, podremos modificar propiedades como el `transform` o las propiedades de otros componentes. A continuación vamos a ver el panel `Animation`.

Para poder acceder al panel animation, simplemente haremos click en `Window -> Animation -> Animation`, también podemos acceder a este mediante su método abreviado (`Ctrl+6`)

![Panel Animaciones](/img/16_PanelAnimation.png)

Llegados a este punto seguro que estarás diciendo... (si, todo esto esta muy bien, pero como puñetas se crea una animación??!!). Tranquilo, no desesperes, voy a ello, pero antes te tenia que presentar nuestro querido panel *Animation* ya que en el vas a pasar muchas horas.

### Creando nuestra primera animación

Para este ejemplo, voy a explicar como crear una animación en 2D ya que será mas sencillo y tocaremos un par de puntos interesantes en el proceso.

De punto de partida, diré que antes tenemos que tener una serie de sprites para animar, ya que serán la base de nuestras animaciones 2D. Si los descargas del Asset Store de Unity, por lo general traeran ya sus archivos de animación asi como códigos asociados. Es por ello es que yo te voy a contar como hacer el proceso totalmente a mano, que es como si tu te hubieras creado tus personajes y ahora te toca crear la animación.

Para nuestro ejemplo vamos a usar los siguientes sprites, los cuales los hemos sacado de [itch.io](https://itch.io).

Te puedes descargar los archivos [PersonajeIdle](/resources2D/HostileIdleReaper-Sheet.png) y [PersonajeRun](/resources2D/HostileRunningReaper-Sheet.png) por si quieres hacer pruebas con esto.

Bueno, vamos a pringarnos las manos y vamos con la animación.

 - Lo primero que tenemos que hacer es copiar nuestros archivos con los sprites a nuestro Unity, tal y como tenemos en la imagen.

    ![sprites_in_project](/img/16_SpritesCopiadas.png)

 - Lo siguiente que tendremos que hacer es recortar los sprites, ya que estos vienen como una unica imagen en los archivos. Para ver el ejemplo, lo haremos sobre el archivo HostileIdleReaper-Shet, pero el mismo proceso habria que repetirlo con el otro archivo o con cuantos archivos tengamos.

     * Seleccionamos con un click el archivo en el panel project y nos vamos al Inspector. Aquí tendremos que modificar algunas cosas para preparar el archivo de sprites.
     * Primero cambiaremos la propiedad *Sprite Mode* de `Single`a `Multiple`.

        ![SingleToMultiple](/img/16_SpriteSingleToMultiple.png)

     * A continuación cambiamos el valor de Pixels Per Unit de 100 a 16, ya que nuestros sprites tienen esa proporción. Este no es un valor fijo, vendrá determinado por tus sprites, pero para este ejemplo, este es el valor optimo.

        ![PixelsPerUnit](/img/16_SpritesPixelsPerUnit.png)

     * El siguiente parámetro que debemos cambiar es `Filter Mode`, dado que nuestro sprite es de tipo pixel art, tenemos que cambiar su propiedad de `Bilinear` a `Point No Filter`, a modo que no nos suavice los bordes. Si por el contrario, tu imagen es diferente y quieres los bordes suavizados, puedes dejarlo como está, pero en este ejemplo lo vamos a cambiar.
     
        ![PointNoFilter](/img/16_SpritesPointNoFilter.png)



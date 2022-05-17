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

 - Antes de nada, tenemos que configurar los sprites, para poderlos recortar:

     * Seleccionamos con un click el archivo en el panel project y nos vamos al Inspector. Aquí tendremos que modificar algunas cosas para preparar el archivo de sprites.
     * Primero cambiaremos la propiedad *Sprite Mode* de `Single`a `Multiple`.

        ![SingleToMultiple](/img/16_SpriteSingleToMultiple.png)

     * A continuación cambiamos el valor de Pixels Per Unit de 100 a 16, ya que nuestros sprites tienen esa proporción. Este no es un valor fijo, vendrá determinado por tus sprites, pero para este ejemplo, este es el valor optimo.

        ![PixelsPerUnit](/img/16_SpritesPixelsPerUnit.png)

     * El siguiente parámetro que debemos cambiar es `Filter Mode`, dado que nuestro sprite es de tipo pixel art, tenemos que cambiar su propiedad de `Bilinear` a `Point No Filter`, a modo que no nos suavice los bordes. Si por el contrario, tu imagen es diferente y quieres los bordes suavizados, puedes dejarlo como está, pero en este ejemplo lo vamos a cambiar.
     
        ![PointNoFilter](/img/16_SpritesPointNoFilter.png)

     * El penultimo paso es cambiar el parámetro `Compression` de `Normal Quality` a `None`. El motivo, es exactamente que el del paso anterior, ya que no queremos que le aplique compresión a la imagen, ya que queremos que tenga ese aspecto de pixel art.

        ![SpriteCompression](/img/16_SpritesCompression.png)

     * A continuación, le damos al botón `Apply` para aplicar todos los cambios. No se te olvide de hacerlo o no se aplicaran los cambios que hayas hecho. De todas formas, como Unity es muy seguido el se encargará de recordarte que tienes cambios por aplicar, pero de cualquier forma, no te cuesta nada acordarte y darle.

        ![SpritesApplyChanges](/img/16_SpriteApplyChanges.png)

     * Cuando tengamos hecho todo lo anterior, le damos al botón `Sprite Editor`, el cual nos abrirá la ventana del editor de Sprites, que será donde vayamos a recortar nuestro sprite.

        ![OpenSpriteEditor](/img/16_OpenSpriteEditor.png)
 
 - En la ventana de Sprite Editor, tendremos que configurar una serie de parámetros para recortar nuestros sprites:

    ![WindowSpriteEditor](/img/16_SpriteEditorWindow.png)
    
     * Lo primero que haremos será darle a `Slice` y cambiaremos el valor de `Automatic` a `Grid By Cell Size` aquí le daremos un valor de 32 x 48 y donde pone `Slice` para poder generar el recorte de las imagenes.
    
     ![Automatic_TO_GridSize](/img/16_SpriteEditor_SliceSprite.png)

     ![Size Slide](/img/16_SpriteSizeSlide.png)

     * Ahora se nos habrán creado los marcos de recorte, los cuales tendrán un aspecto semejante a esto.

     ![SliceFrames](/img/16_SpriteSliceFrame.png)

     * Lo que tendremos que hacer es cuadrar los marcos con las imagenes y eliminar aquellos que no nos sirvan. Para cuadrar los marcos, los seleccionaremos con el raton y los iremos moviendo hasta dejar algo parecido a la imagen de a continuación. Y para eliminar aquellos que nos sobran, los seleccionamos con el raton y le damos a Suprimir.

     ![SliceAndSorted](/img/16_SpritesSlicesAndSorted.png)

     * Una vez que ya los tengamos listos, le damos al boton que esta en la parte superior y que pone Apply para aplicar los cambios y ya con esto, podemos cerrar la ventana `Sprite Editor`.

 - Si nos vamos al panel project, veremos que se nos han generado 5 imágenes dentro de nuestro archivo. Estas serán las imagenes que vamos a usar para poder crear nuestra animación.

    ![SpritesInProject](/img/16_SpritesReadyToAnimate.png)

 - Ya con todo esto listo, vamos a elegir el primer sprite, el que termina en Sheet_0 y lo vamos a arrastrar a la ventana de escena.

    ![Sprite In Scene](/img/16_Sprite_In_Scene.png)

 - Con nuestro sprite seleccionado, vamos a abrir la ventana Animation tal y como dijimos (`Ctrl+6`) y le vamos a dar al botón `Create` que nos aparece en la zona central, para crear nuestra primera animación.
 - Esto nos abrirá una ventana donde nos preguntará donde se van a guardar las animaciones. Yo te aconsejo que te crees una carpeta dentro de nuestro proyecto a la cual yo le suelo poner `Animations`.
 - A esta animación le daremos el nombre de `ReaperIdel.anim`.
 - Si has hecho todo esto bien, verás que tienes activa la parte central del panel `animation` que será donde tengamos que soltar nuestros frames.
 - Asi que lo siguiente que vamos a hacer es seleccionar las imagenes que recortamos con nuestro sprite editor y las arrastraremos a la zona central.

    ![Sprites Drops](/img/16_Sprites_DropInAnimation.png)

 - Una vez hecho esto, podemos darle al botor play del control de animación para ver como se comporta. En nuestro caso, esto irá demasiado rapido, por ello con todos los key frames seleccionados estiraremos del control del final del último keyframe hasta conseguir que la animación sea mas o menos coherente. En nuestro caso, ha quedado así.

    ![Key Frames in Position](/img/16_Sprites_KeyFrames_InPosition.png)

 - Llegados a este punto, habremos creado nuestra primera animación. Felicidades Igor, si has llegado hasta aquí has logrado darle vida a tu criatura.


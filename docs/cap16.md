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

## Panel Animation

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

Pues bien, ya sabemos como crear nuestra primera animación, asi que vamos a crear la siguiente que será la de nuestro amigo corriendo. Obviamente no voy a repetir todo el proceso, pero si te voy a decir como hacerlo. Para crear una nueva animación para nuestro simpatico personaje, le daremos a `Create New Clip`, tal y como nos muestra la imagen que tienes a continuación. A esta animación, ponle el nombre de ReaperRun. La idea es que puedas seguir estos pasos hasta que tu te hagas las tuyas ya solito. Pero como esto es para que aprendas, ponle como te digo, porque será como me vaya a referir a ellas en los ejemplos que vayamos viendo.

![New Animation Clip](/img/16_Sprite_Animacion_Create_NewClip.png)

Pues bien, supongo que habras sido buen chico y te habrás creado la última animación, tal y como te he dicho no?? verdad?? A que has sido un chico aplicado y lo has hecho...?? En caso contrario, ya estas tardando en hacerla, puesto que vamos al siguiente punto que es `El Panel Animator`, y a partir de aquí agarrate que vienen curvas, porque vamos con el código.

## Panel Animator

Pues bien, si en el panel `animation` creabamos nuestras animaciones según ibamos necesitando para nuestro personaje, en el panel `animator` vamos a definir cuando se van a activar y por ello, vamos a definir el comportamiento de las animaciones en nuestro pequeño amigo pixelado.

Para abrir el `panel animator` ve a `Window -> Animations -> Animator` y se nos abrirá la ventana de `Animator`. Yo un consejo que te doy, es acoplarlo en un sitio donde lo puedas tener accesible, del mismo modo que te digo lo mismo para el panel `Animation`. Te dejo una imagen de como lo tengo yo, que para mi es bastante comodo tenerlo así. Tu puedes ponerlo como mejor te venga en gana.

![MyLayoutToAnimate](/img/16_MyDesktopForAnimate.png)

Pues bien, en el panel `animator` vamos a encontrar varias partes y cosas. Tranquilo que ahora te digo que es cada una de ellas, o al menos las que nosotros vamos a usar.

![PanelAnimator_Detail](/img/16_PanelAnimator_00.png)

Si nos fijamos en la imagen, veremos que tenemos dos partes muy diferenciadas. Por un lado está el área donde estan las animaciones y los diferentes estados, y por el otro tenemos la columna donde encontramos `Layers` y `Parameters`, siendo este último el que nos va a servir para definir variables, las cuales se comunicarán con nuestro código.

Actualmente, tal y como están las animaciones en nuestro `animator`, no van a hacer demasiado. Si le damos a `Play Mode`, veremos que se nos activa la animación `ReaperIdle`, pero `ReaperRun` no hace nada. Ello es porque no hemos definido una transición entre ellas para que puedan cambiar de una a otra. Para hacer esto, vamos a crear estas transiciones. 

Nos colocamos encima de la animación que está en nuestro `animmator` como `ReaperIdle`y le damos al botón derecho del ratón, y a continuación seleccionamos `Make Transition` y arrastramos hasta `ReaperRun`, hacemos click encima de `ReaperRun` y listo. Ya tenemos creada nuestra primera transición, la cual irá desde `ReaperIdle` a `ReaperRun` o siendo un poco mas claros, vamos a pasar de estar parados a estar moviendonos. Del mismo modo, haremos el proceso contrario, pero desde `ReaperRun` hasta `ReaperIdle`, asi crearemos el cambio de estar moviendonos a pararnos.

![MakeTransitionOne](/img/16_Animator_MakeTransition_01.png)

Si has seguido mis pasos, mi joven aprendiz, te ha tenido que quedar algo muy parecido a esto.

![MakeTransitionTwo](/img/16_Animator_MakeTransition_02.png)

Este proceso, lo haremos con todas las animaciones que tengamos, eso si, con la lógica que queramos que tengan nuestras animaciones, por ejemplo: queremos que nuestro personaje pase de estar parado a estar corriendo (eso es una transición), que de estar corriendo este parado (otra transición), que ataque cuando este parado (seria otra transición), que si esta corriendo salte (otra transición mas), y así con todas las que tengas y que tenga el comportamiento que quieras.

Para este ejemplo, no nos vamos a complicar mucho y vamos a tener solo dos, Quieto y Moviendose, pero podriamos tener mas...

Pues bien, una vez definidas las transiciones, debemos configurarles a estas una serie de parámetros para que no se vean raras ni tengan comportamientos extraños. Para ello, vamos a hacer click encima de una de las líneas de las transiciones y nos vamos a ir al panel `Inspector`.

![MakeTransitionThree](/img/16_Animator_MakeTransition_03.png)

Para ello, primero daremos click en el desplegable de *Settings*, para acceder a sus parámetros. A continuación, vamos a desmarcar la casilla superior que pone `Has Exit Time`, ya que vamos a hacer que pase de un estado a otro mediante código. El siguiente parámetro a modificar será `Transition Duration`, el cual cambiaremos su valor a 0. Si has seguido estos pasos al pie de la letra, te debería quedar tal que así.

![MakeTransitionFour](/img/16_Animator_MakeTransition_04.png)

Pues lo mismo que hemos hecho con la transicion de parado a moverse, haremos exactamente igual con la que va de `ReaperRun` a `ReaperIdle`.

Bueno, esto va cogiendo forma. Lo siguiente que vamos a hacer es crear parámetros para cambiar de una animación a otra. Para ello seguiremos los siguientes pasos:

 1 - Iremos al apartado `Parameters` del `Animator` y daremos sobre el signo mas para que se nos despliegue el menu.

 ![Parameters01](/img/16_Animator_Parameters_01.png)

 2 - Elegiremos un tipo `bool` y le daremos el nombre de `EstaQuieto`.

 ![Parameters02](/img/16_Animator_Parameters_02.png)

 3 - A continuación, vamos a indicar que valor debe tener dicho valor en cada una de las transiciones. Para eso vamos a plantear lo siguiente:
     
     * De quieto -> En movimiento => EstaQuieto = Falso
     * En Movimiento -> Quedarse quieto => EstaQuieto = Verdadero.

Como vemos, la logica es bastante sencilla no?? Si estas parado y te empiezas a mover, el parámetro EstaQuieto serà falso y si te estas moviendo y te paras, pues EstaQuieto pasa a verdadero. 

Pero, te estaras preguntando como le damos esa información a nuestras animaciones. Pues bien. Recuerdas que desactivamos el parámetro `Has Exit Time`, pues es llegado a este punto que vamos a definir nuestra propia condición de salida. Para ello:
 
 1 - Hacemos click primero en la transición de `ReaperIdle` a `ReaperRun` y vamos a donde nos aparece `Conditions`. Aquí le damos al `+` para crear una nueva condición. Te dejo una imagen de como debe quedar.

  ![Parameters03](/img/16_Animator_MakeTransition_03.png)

  ![Parameters03](/img/16_Animator_MakeTransition_04.png)
  
  ![Parameters03](/img/16_Animator_MakeTransition_05.png)

 2 - Haremos los mismos pasos para con la transición de `ReaperRun` a `ReaperIdle`, pero en este caso, definiremos el valor de `EstaQuieto` a `true`.

  ![Parameters03](/img/16_Animator_MakeTransition_06.png)

Pues llegados a este punto, ya hemos definido las condiciones mediante las cuales pasaremos de una animación a otra. Lo que queda ahora, es hacerlo a traves del código.

Para ello, vamos a realizar un cambio de un estado a otro, cuando presionemos una tecla. Esto será igualmente valido para el caso en el que hagamos una función que mueva al personaje, cosa que no vamos a hacer en este ejemplo y que te lo dejo a ti a fin de que uses tu materia gris. Yo te voy a explicar como se activa una animación u otra.

Supongamos que creamos un script al cual llamaremos AnimarPersonaje:

```c#
using UnityEngine;

public class AnimarPersonaje : MonoBehaviour
{
    [SerializeField] Animator anPlayer;


    void Start()
    {
        anPlayer = GetComponent<Animator>();    //Referencia al Animator del Personaje
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) anPlayer.SetBool("EstaQuieto", false);
        else anPlayer.SetBool("EstaQuieto", true);
    }
}
```

Si vemos el código, es bastante sencillo. Lo primero que hacemos es referenciar el componente `Animator` del personaje. Este se crea, en el momento que creamos la primera animación y se le asigna automaticamente.

A continuación y dentro del método `Update`, hemos definido que, si pulsamos la tecla `A`, se supone que esto haría que nuestro muñeco ande, con lo cual, a traves del `Animator` referenciado, le asigno un valor al parámetro `EstaQuieto`, mediante el método `SetBool`, haciendo que este sea falso (con lo que haria la animación de moverse) y si dejamos de pulsar la tecla `A`, hariamos `EstaQuieto` verdadero, pasando de ese modo a la animación `ReaperIdle`.

Si has seguido el proceso, y lo has ido haciendo conmigo, puedes darle al `Play` para que veas como cambia de uno a otro.

*IMPORTANTE: EL SCRIPT QUE HEMOS CREADO, LO TIENES QUE AÑADIR AL MUÑECO, SI NO, NO FUNCIONA. CREO QUE LLEGADOS A ESTAS ALTURAS, NO TENGO QUE DECIRLO. PERO POR SI ACASO.*




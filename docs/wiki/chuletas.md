# 1 - Configurar PICO 4 para Unity 2D

Pasos para configurar PICO 4 para desarrollar en Unity:

 1 - Descargar el [SDK](https://developer-global.pico-interactive.com/sdk?deviceId=1&platformId=1&itemId=12) de PICO 4 para Unity.
 
 2 - Descomprimir el SDK descargado para importarlo en Unity.

 3 - Comprobar que Unity tiene instalado para construir en Android, en caso contrario, iremos al Unity Hub y le diremos que lo descargue.

 4 - Instalamos los modulos de Unity para Android:
     
   * Android Build Support:
   * Android SDK & NDK Tools
   * Open JDK

 5 - Dentro de Unity nos vamos a File -> Build Settings y seleccionamos Android y le damos a *Switch Platform*.

 6 - Nos vamos al Package Manager para instalar el SDK de PICO 4 que previamente hemos descargado.

   * Package Manager -> **Add package from disk** y buscamos la carpeta donde hemos descomprimido el SDK de PICO 4 y seleccionamos el archivo .JSON
 
 7 - Instalamos desde el Package Manager el XR Manager (Para versiones de Unity inferiores a la 2021).
 
 8 - Nos vamos a Edit -> Project Settings y nos vamos a la parte donde pone XR Plug-in Management y seleccionamos PICO Para poder usar el visor PICO 4 (En el setting de Android IMPORTANTE).
 
 9 - Despues nos vamos al apartado *Player* aquí vamos a *Other Settings* y cambiamos los siguiente:
 
   * Identification -> Minimum API Level: **_API Level 27 (Android 8.1 'Oreo')_**.
   * Configuration -> Scripting Backend: **_IL2CPP_**.
   * Target Architecture -> Desactivamos **_ARMv7_** y marcamos **_ARM64_**.
 
 10 - Nos vamos a Package Manager y descargamos *XR Interaction Toolkit*:
  
   - Descargamos también los siguientes **Samples**:

     - Starter Assets.
     - Tunneling Vignette.

 11 - Vamos a configurar la escena en Unity para poder emplear VR.
  
   1. Creamos un plano para el terreno.
   2. Creamos un Game Object XR Origin VR.

      - Le agregamos un componente PXR_Manager.
   3. Seleccionamos el objeto XR Origin de la escena y lo desplegamos:

      - Seleccionamos el LeftHand Controller y en las propiedades del componente XR Controller, seleccionamos el preset XRI Default Left Controller.
      - Repetimos la operación anterior para el RightHand Controller y seleccionamos el preset XRI Default Right Controller.
      - Tanto para LeftHand Controller como para RightHand Controller, bajamos en las propiedades de sus XR Controller hasta donde pone Model Prefab le cargamos a cada uno su LeftControllerModel o RightControllerModel desde `Packages -> Pico Integration SDK -> Assets -> Resources -> Prefabs`.
 
 12 - Descargamos el [SDK Platform Tools](https://developer.android.com/studio/releases/platform-tools) de Android.

 13 - Descomprimimos el archivo descargado con el **SDK Platform Tools** de Android y abrimos el `CMD` de Windows. Nos vamos a la ruta donde este el **Platform Tools**, conectamos nuestro visor PICO 4 al ordenador y desde la linea de comando ejecutamos el comando `adb devices` (*Previamente debemos haber activado el modo Developer del visor PICO4*), si todo ha ido bien, debemos tener una respuesta del comando donde nos salga:

 ```
 List of devices attached
 <CODIGO_DEL_VISOR>     device
 ```

 14 - Abrimos File -> Build Settings y en **Run Device** desplegamos y seleccionamos el visor PICO 4.

 15 - Para comprobar si todo funciona, le daremos a Build and Run, seleccionaremos una carpeta donde generar el APK y observaremos en el visor si vemos el entorno de Unity.

 # 2 - Movimiento con XR Interaction Toolkit

 Primero y antes de nada, vamos a borrar el XR Origin si tenemos un puesto, a continuación nos vamos a Project, y allí nos vamos a `Assets -> Samples -> XR Interaction Toolkit -> (La version que tengamos) -> Starter Assets` y seleccionamos **XRI Default Continuous Move** y en el *Inspector* le damos en **Add to ActionBasedContinuousMoveProvider defaul** hacemos lo mismo con **XRI Default Snap Turn**, con **XRI Default Continuous Turn**, con **XRI Default Left Controller** y con **XRI Default Right Controller**. Controller*.

 Despues nos vamos a *Project Settings* y alli nos vamos a *Preset Manager* y comprobamos que los Presets de los XRI Controllers han sido cargados. En la parte de `ActionBasedController` indicamos en Filter `Right` para el *Right Controller* y `Left` para el *Left.

 Seguidamente creamos un objeto XR Origin VR, y lo abrimos para acceder a sus objetos hijos. Procediendo a cargar los *Model Prefabs* tanto al `Left` como al `Right` controller.

 A partir de aquí crearemos nuestro `Locomotion System`, para ello creamos un GameObject `XR -> Locmotion System`, con esto podremos movernos por la escena que hayamos creado.

 Seleccionamos en nuestra jerarquia el objeto Locomotion System y en su componente `Locomotion System`, le añadimos nuestro `XR Origin` en donde pone `XR Origin`. A continuación, le agregaremos un componente `Continuous Move (Action-Based)`, el cual configuraremos algunos de sus parametros, primero referenciaremos el `Locomotion System` arranstrando este en el apartado `System` del componente `Continous Move`. Despues controlaremos el movimiento con el controlador derecho, para ello, en el componente `Continuous Move` desmarcamos la casilla `Use Reference` del apartado `Right Hand Move Action`. En el componente `Snap Turn Provider` desmarcamos la casilla `Use Reference` del `Left Hand Snap Turn Action` para asi controlar el giro con el controlador izquierdo.
 
 Para usar el tipo de desplazamiento por **Teleport**, agregaremos al `Locomotion System` un componente `Teleportation Provider`. A este, deberemos adjuntarle el componente `Locomotion System` en su apartado `System`. Ademas de esto, para poder saltar de un punto a otro, deberemos de seleccionar nuestro plano, que será donde queremos teleportarnos, y le añadiremos un componente `Teleportation Area`. Este último componente lo que hace es definir la zona o zonas donde podemos teleportarnos. 
 
 Si por el contrario, queremos teleportarnos a puntos concretos, en lugar del componente `Teleportation Area`, usaremos el componente `Teleportation Anchor`. Este compontente permite desplazarnos a puntos definidos en una zona concreta y no por toda la superficie del plano. Definiremos tantos puntos de **Teleportación** como queramos en nuestro terreno. 

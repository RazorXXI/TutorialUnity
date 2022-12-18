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
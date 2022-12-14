# Nuevo Sistema de Inputs de Unity

El nuevo sistema de Inputs de Unity, nos permite definir una serie de acciones y comportamientos para uno o varios controles totalmente distintos, como por ejemplo (teclado, gamepad, joystick, etc...)

Para poder emplear el nuevo sistema de inputs de Unity, lo primero que debemos hacer es ir al Package Managar, en Unity Registry e instalar el paquete.

Cuando se instale, nos aparecerá el siguiente mensaje:

 ![Mensaje input system instaldo](imgWiki/04_AvisoInputSystem.png)

Le daremos a `Yes` y se nos reiniciará Unity, de modo que ya podremos utilizar el nuevo sistema de Inputs. Peeero, quieto `parao` que antes tendremos que configurar algunas cosas "*como dijo Jack el Destripador...*"
> Vayamos por partes.

Pues bien, una vez instalado el paquete del `Nuevo Input System` de Unity, lo siguiente que tendremos que hacer, es irnos a `Edit -> Project Settings` y una vez en la ventana de `Project Setting` nos iremos a donde pone Input System Package (si no lo tienes clarinete, te dejo una imagen, que siempre vale mas que mil palabras o al menos eso dicen).

 ![Package Manager Input System](imgWiki/04_InputSystemPackage.png)

Una vez que estemos ahí, le daremos a `Create Settings Asset` y con esto, se nos creará el archivo de configuración que será el que controle como queramos que se comporten nuestros inputs.

Si has seguido todos los pasos correctamente, se te ha tenido que crear un archivo dentro de tus `Assets` del proyecto tal y como este.

 ![Archivo Configuracion Input System](imgWiki/04_ArchivoConfigInputSystemNuevo.png)

Lo siguiente que haremos será crear un `Input Actions`, y para ello, nos vamos a la pestaña `Project` y damos click derecho para mostrar el menu, damos a `Create -> Input Actions`.

 ![Crear Input Actions](imgWiki/04_CreateInputActions.png)

Este asset que hemos creado, será el que tenga definidas todas las acciones que queramos que sean controladas como por ejemplo, andar, saltar, atacar, etc... para el ejemplo, yo he llamado al asset `PlayerActions`, pero tu puedes ponerle el nombre que te salga de la pera.

 ![Player Actions](imgWiki/04_PlayerActions.png)

Si le damos doble click al asset que hemos creado (`PlayerActions` por si se te habia olvidado...) se nos abrirá una ventana para configurar nuestras acciones.

La ventana se compone de 3 partes bien definidas:
 - Action Maps: Aquí crearemos el mapa de acciones que vayamos a utilizar, para el ejemplo yo lo voy a llamar personaje.
  
  ![Ventana Acciones](imgWiki/04_VentanaAcciones.png)

 - Actions:

 - Properties:
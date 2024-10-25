# Guía SuperCondensada de Programación en C# Unity
## Presentación e Introducción
La idea de realizar esta guía es que pueda servir a otros, al igual que a mi, a aprender a programar en Unity3D.

Me decidí crear este documento, con la premisa de tener mis apuntes en algún sitio donde los pudiera consultar cada vez que los necesitara, estuviera donde estuviera.

He de decir, que esto no es otra cosa que mis propios apuntes manuscritos, plasmados aquí y de una manera accesible y ordenada.

Cualquiera que tenga ganas de aprender a programar en Unity3D, esto le puede servir como fuente de consulta, ya que está todo lo necesario pero de una manera muy condensada, sin irse por las ramas. Directo al grano y con mogollon de fragmentos de códigos de ejemplo o directamente códigos completos, los cuales también son ejemplos de mis apuntes escritos previamente en papel y lápiz.

Espero que te sirva y te ayude, pues se lo complicado que es encontrar en internet información concisa y clara en webs sobre este tema.

## Indice de Capítulos

 * **Capítulo 1: Unity Instalación y Presentación**
     * [1.1: Instalación de Unity](/docs/cap00A.md)
     * [1.2: Entorno de Unity](/docs/cap00B.md)
     * [1.3: Unity Asset Store](/docs/cap00C.md)
 * **Capítulo 2: Scripting en Unity**
     * [2.1: Una breve introducción](/docs/cap01.md)
     * [2.2: Variables y Tipos de datos](/docs/cap02.md)
     * [2.3: Mostrando Información por Consola](/docs/cap03.md)
     * [2.4: Arrays](/docs/cap04.md)
     * [2.5: Funciones](/docs/cap05.md)
     * [2.6: Estructuras de Control](/docs/cap06.md)
     * [2.7: Control de Componentes](/docs/cap07.md)
     * [2.8: La Clase Padre Monobehavior](/docs/cap08.md)
     * [2.9: Gestión de GameObjects mediante Script](/docs/cap09.md)
     * [2.10: Otros aspectos de la programación en C#](/docs/cap10.md)
     * [2.11: Cosas interesantes para hacer con C#](/docs/cap11.md)
     * [2.12: Atributos para personalizar el Inspector de Unity](/docs/cap12.md)

 * **Capítulo 3: Físicas, Inputs y Otros Menesteres**
     * [3.1: Físicas en Unity 3D. Rigidbody y Colisiones Varias](/docs/cap13.md)
     * [3.2: Mas Física. Joint que te Joint y Character Controller](/docs/cap14.md)
     * [3.3: Materiales, Texturas y Shaders](/docs/cap15.md)
     * [3.4: Animaciones. Animation y Animator](/docs/cap16.md)
     * [3.5: Sistema de Particulas](/docs/cap81.md)
     * [3.6: Inputs (`INCOMPLETO`)](/)
     * [3.7: Sistema de Navegación (`INCOMPLETO`)](/)
     * [3.8: Audio (`INCOMPLETO`)](/)
     * [3.9: UI y Canvas (`INCOMPLETO`)](/)
     * [3.10: Playerprefs (`INCOMPLETO`)](/)
     * [3.11: Nuevo Sistema de Inputs de Unity (`INCOMPLETO`)](/)

 * **Capítulo 4: Realidad Virtual y Realidad Aumentada (`INCOMPLETO`)**
     * [4.1: Cámara, movimiento e interacciones](/docs/cap80.md)
     * [4.2: Preparación de un Proyecto para VR (`INCOMPLETO`)](/)
     * [4.3: Optimización y creación de nuestro primer proyecto VR (`INCOMPLETO`)](/)
     * [4.4: Introducción a AR (`INCOMPLETO`)](/)
     * [4.5: Preparacion de un proyecto AR en Unity con Voforia (`INCOMPLETO`)](/)
     * [4.6: Nuestro primer proyecto de AR en Unity (`INCOMPLETO`)](/)
     * [4.7: Raycasting (`INCOMPLETO`)](/)
     * [Apendice: Configuración de entorno para VR](/docs/apendiceVR.md)

 * **Capítulo 5: Conceptos de Programación Avanzada**
     * [5.1: Clases Estáticas](/docs/cap17.md) 
     * [5.2: Constantes y Enumeraciones](/docs/cap18.md)
     * [5.3: Máquina de Estados](/docs/cap19.md)
     * [5.4: Funciones Matemáticas Relevantes](/docs/cap12_1.md)
     * [5.5: Delegados (`INCOMPLETO`)](/docs/cap12_2.md)
     * [5.6: Scriptable Objects](/docs/cap20.md)
     * [5.7: Patrones de Diseño I - Definición](/docs/cap21.md)
     * [5.8: Patrones de Diseño II - Object Pooling](/docs/cap22.md)
     * [5.9: Patrones de Diseño III - Singleton](/docs/cap23.md)
     * [5.10: Principios SOLID (`INCOMPLETO`)](/)
     
 * **Capítulo 6: Otras cosas importantes en Unity (`INCOMPLETO`)**
     * [6.1: El Audiomixer (`INCOMPLETO`)](/)
     * [6.2: Cinemachine (`INCOMPLETO`)](/)
     * [6.3: Sistema de Inputs avanzado para movil (`INCOMPLETO`)](/)
     * [6.4: Unity Services (`INCOMPLETO`)](/)
     * [6.5: Unity Analytics (`INCOMPLETO`)](/)
     * [6.6: Arquitectura en juegos de Unity (`INCOMPLETO`)](/)
     * [6.7: Optimización Avanzada (`INCOMPLETO`)](/)
     * [6.8: Montaje de un proyecto con Unity (`INCOMPLETO`)](/)
     * [6.9: Renderización (`INCOMPLETO`)](/)
     * [6.10: Multijugador con Photon Engine (`INCOMPLETO`)](/)

 * **Appendix - Cheat Sheets y Recursos**
     * [Appendix I: Construyendo un juego 2D con Unity (`INCOMPLETO`)](/docs/wiki/README.md)
     * [Appendix II: Configuración de PICO 4 en UNITY (`INCOMPLETO`)](/docs/wiki/chuletas.md)
     * [Appendix III: Cheat Sheet de DoTween](/docs/wiki/05_DoTweenCheatSheet_I.md)
     * [Appendix IV: Cheat Sheet de Raycast](/docs/wiki/06_RaycastCheatSheet_I.md)

 * **Scripts de Ejemplo**
     * [Buscar un player u otro objetivo](/scripts/BuscarPlayer.cs)
     * [Cambiar material en tiempo de ejecución](/scripts/ChangeMaterial.cs)
     * [Comprobar si estamos en suelo](/scripts/CheckGround.cs)
     * [Rigidbody en tiempo de ejecución](/scripts/ControlRigidBody.cs)
     * [Ejemplos de corrutinas](/scripts/Corrutinas.cs)
     * [Cuenta Regresiva (Forma 1)](/scripts/CountDown.cs)
     * [Cuenta Regresiva (Forma 2)](/scripts/CountDownTimer.cs)
     * [Ejemplo de uso de Raycast](/scripts/EjemploBasicoDeRaycast.cs)
     * [Limitar Frames](/scripts/FrameLimiter.cs)
     * [Cambio de propiedades físcas en tiempo de ejecución](/scripts/IgualarMasasDeObjetos.cs)
     * [Cambio de color en tiempo de ejecución](/scripts/MaterialColor.cs)
     * [Movimiento de un objeto](/scripts/MoverCuadrado.cs)
     * [Movimiento de punto de mira con ratón](/scripts/MovimientoMira.cs)
     * [Movimiento y salto de un personaje en 2D](/scripts/MovimientoSalto2D.cs)
     * [Movimiento mediante waypoints](/scripts/MovimientoWayPoint.cs)
     * [Efecto Parallax I](/scripts/ParallaxEffect.cs)
     * [Efecto Parallax II](/scripts/ParallaxScript.cs)
     * [Busqueda de un target](/scripts/Target.cs)
     * [Un script con varias cosas ](/scripts/TipsAndVarious.cs)
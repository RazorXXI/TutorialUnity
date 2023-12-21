# Capítulo 5: Conceptos de Programación Avanzada
## 5.9 - Patrones de diseño III (Singleton)

Este patrón de diseño es de los mas utilizados en el desarrollo de videojuegos.

El `Singleton` tiene tanto admiradores como detractores, a continuación veremos cuando usarlo, como hacerlo y sobre todo sus pros y sus contras, ya tú decidirás si lo usas o no.

### 5.9.1 - Definición y usos
---
En su defición por defecto, un `singleton` es una clase que cumple las siguientes dos condiciones:

 * Es accesible globalmente.
 * Solo puede existir una única instancia de esta clase.

Al cumplirse estas dos condiciones, el `singleton` permite acceder facilmente desde cualquier parte del juego que estemos desarrollando, desde cualquier otro objeto.

Un ejemplo muy común del uso del `singleton` es un `AudioManager`. Al hacer al `AudioManager` como un `singleton`, este podrá ser accedido desde cualquier parte del juego, a una única instancia del mismo. Por ejemplo, si este manager tiene un método para reproducir sonido llamado `PlaySound`, este podrá ser utilizado desde cualquier parte del juego, bien desde un player, bien desde un objeto, etc.

Sigamos con el ejemplo del `AudioManager`.

Supongamos que tenemos a nuestro *AudioManager* como `singleton`, y que nuestro `player`, debe reproducir un sonido, al chocar con algo. Esto, será llamado desde nuestro manager de audio en cualquier punto del juego, directamente por nuestro player, ya que al ser `singleton` dicho `AudioManager`, podrá ser globalmente accedido por cualquier objeto del juego, en este caso el `player`.

Y tal y como hemos indicado en el parrafo anterior, esto también podrá ser accedido por un `enemy`, un `canvas`, un `GameManager` o cualquier otro objeto que necesite reproducir un sonido en nuestro juego.

Seguimos explicando donde normalmente se usa el `singleton`, y sus usos más habituales son en:

 * Game Managers
 * Audio Managers
 * User Interface Manager (menus del juego)
 * Spawners (enemigos, objetos u otro spawner)
 * Camera Managers

 Pues bien, para entender como se hace un `singleton`, vamos a hacer un ejemplo de un `AudioManager`, aunque como ya he dicho antes, lo podemos hacer otros managers. En fin, que no me enrollo mas, vamos al lío.

 Para nuestro `AudioManager`, vamos a partir de la siguiente premisa. Va a ser capaz de reproducir efectos de sonido y música. Para ello y partiendo de un proyecto de ejemplo, vamos a crear un objeto que será nuestro `AudioManager`, tal y como se muestra en la siguiente imagen.

 ![Singleton Audio Manager](/img/_SingletonAudioManager.png)

 Aquí vemos, que nuestro audio manager, tiene dos objetos hijos, uno llamado `SoundEffects` y el otro `Music`. Ambos objetos hijos tienen un componente `AudioSource` el cual será el encargado de reproducir los efectos de sonido y la música respectivamente.

 Seguidamente, vamos a crear un script el cual va a gestionar el `AudioManager` y que llamaremos `AudioManagerSingleton` y que añadiremos a nuestro objeto `AudioManager`, tal y como se muestra en la imagen (tranqui colega, que ahora te enseño el script por dentro, primero quiero que veas como está hecho todo).

 ![Componente Script AudioManagerSingleton](/img/_AudioManagerComponenteScriptSingleton.png)

Ahora es cuando te muestro como esta hecho el script por dentro, aunque advierto que aun no es el definitivo, pero para ir abriendo boca, está bien, además, esta totalmente comentado para que no te pierdas que va haciendo.

```c#
using UnityEngine;

public class AudioManagerSingleton : MonoBehaviour
{
    [SerializeField] AudioSource soundEffects;
    [SerializeField] AudioSource musics;

    //Aqui comienza el Singleton
    //La variable Instance, es la unica instancia de la clase
    //mediante la cual vamos a tener acceso a los metodos de
    //esta clase desde otros scripts
    public static AudioManagerSingleton Instance { get; private set; }

    private void Awake()
    {
        //Con el if nos aseguramos que solo haya una sola instancia
        //de esta clase
        if (Instance != null && Instance != this)
        {
            Destroy(this); //Si hay mas de una instancia de esta clase
                           //las destruye para que exista solo una
        }
        else
        {
            Instance = this; //Esta es la referencia a esta clase
            DontDestroyOnLoad(this);//Esto hace que no se destruya al cambiar de escena
        }
    }

    //Este metodo podra ser llamado por cualquier objeto de nuestra escena
    public void PlayAudioClip(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip);
    }
}
```
Si hacemos un cambio de escena, veremos que el `AudioManager` es persistente al cambio, no perdiendose su objeto entre una escena y otra, tal y como vemos en la siguiente imagene.

![Audio Manager No Destruido](/img/_AudioManagerComponenteScriptSingleton02.png)

Además, para este ejemplo, he creado un script que hace el cambio de escena, además de producir un sonido al hacer click en el botón, el cual tiene la siguiente pinta.

```c#
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerGame : MonoBehaviour
{
    [SerializeField] AudioClip clickButton;

    public void CambioDeEscena()
    {
        //Llamada la instancia del AudioManager para reproducir el sonido
        //al hacer click en el boton
        AudioManagerSingleton.Instance.PlayAudioClip(clickButton);
        SceneManager.LoadScene("EscenaSingleton_02");
    }
}
```

Este script, se lo he aplicado a la cámara, tal y como podemos ver en la siguiente imagen.

![Script SceneManager de la camara](/img/_ScriptGameManagerDeCamara.png)

De esta manera, se lo puedo aplicar al boton mediante un evento. 

Podria haber creado un objeto vacío para que portara el script, pero para el ejemplo he usado la cámara (yo te recomiendo que uses un objeto vacío para estas cosas). Del mismo modo, podría haber creado otro singleton para el SceneManagerGame en lugar de hacerlo así, pero dado que no vamos a andar gestionando mucho más en este ejemplo, tal y como está hecho es suficiente.

Como ya hemos dicho al principio, la principal utilidad de los `singleton` es la de ser empleados en los Managers del juego en cuestión, no olvidar ese punto.

### 5.9.2 - Pros y Contras del Singleton
---
Ahora vamos a hablar de los pros y de los contras de usar `singleton`.

 - Pros:
     * Son muy útiles para tener referencias rápidas y accesibles en nuestro juego.

 - Contras:
     * Provocan acoplamiento de código: Ya que otras clases que los usen, van a tener una increible dependencia de la clase que porte el singleton, provocando que el código sea dificil de cambiar sin afectar a múltiples partes de nuestro juego.

     * Dificiles de debugear: Al ser las instancias accesibles globalmente, se hace mucho mas complicado reconocer que partes del código están cambiando partes del singleton y cuales no.

     * No se pueden crear clases hijas: Esto rompe el principio de herencia de clases. 

     * Esconden dependencias: Al poder usar la instancia del singleton sin crear referencias, hace que el código sea mas dificil de ser leido. Para saber si una parte del código hace uso del singleton, vamos a tener que buscar en todo el código que parte hace uso del singleton y cuales no.

Los contras del uso de los singleton siempre serán mas notables, cuanto mas extenso sea nuestro juego y cuanto más uso hagamos de los singleton en el.

### 5.9.3 - Cuando debemos usar el patrón Singleton
---
Ahora veremos cuando debemos usar un `singleton` y explicaremos porqué, así de este modo evitaremos caer en malas practicas.

 * **Tareas simples y para una única finalidad**: Si pretendemos que nuestro singleton gestione el Audio, evitaremos emplearlo para otras cuestiones que no tengan que ver con el audio. Y del mismo modo, que sea lo mas simple y sencillo posible.

 * **Usarlo solamente para los managers**: Lo ideal es usarlo para gestionar los managers, de forma sencilla y sin que sea una clase gigantesca llena de métodos.

 * **Usarlos solamente cuando sea necesario**: Creo que esto puede sonar un poco ambiguo, pero creeme que no lo es. Piensa antes de hacer un singleton, si es extrictamente necesario, y si no se puede resolver lo que vayas a hacer de otra forma sin tener que hacer uso del `singleton`. 

Asi que mi joven Skywalker, espero que te haya servido este capítulo y te haya quedado algo más claro de que es un `singleton`, como se construye y sobre todo, cuando y como usarlo. Ahora te toca a ti decidir.

Chao pescao y hasta el próximo capítulo.
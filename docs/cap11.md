# Cosas interesantes para hacer con C#

La infinidad de cosas que podemos hacer con C# para darle vida a nuestros juegos, es infinita, el único límite que tenemos es la propia imaginación del desarrollador.

Por ello, en este capítulo, vamos a ver algunas cositas que podemos hacer, algunas serán bastante obvias, pero que seguramente se te puede venir al cerebelo esa pregunta tan puñetera, como es... `Y esto como lo hago???!!`. Pues bien, no sufras, que para eso estamos aquí.

## Como cambiar de escena

El cambio de escena en un juego, es algo muy rutinario, dado que cada escena representa o puede representar un nivel de nuestro juego, obviamente esto puede ser así, si tu juego va a tener varios niveles, en caso contrario, el cambio de escena, puede ser debido a que vayas a entrar en un sitio, presentar algo, el menú de juego es otra escena, los créditos, una fase bonus, todo eso son escenas.

Para que nos enteremos. Un juego está compuesto de escenas. Cuando tu le das a un botón por ejemplo, para abrir las preferencias del juego (ya sabes, eso tipico que te pone activar desactivar sonido, poner o quitar la música del juego, configurar los controles, etc) lo que estas haciendo es mostrar otra escena, que no necesariamente una escena tiene que ser solo y exclusivamente el Game Play del juego. Cada cosa que le muestras al usuario, está contenido en una escena, por ello, los cambios de escena es algo que se hacen continuamente. Espero que te haya quedado mas claro con esta explicación magistral que te acabo de dar.

Que nada, que como ya te he dicho, es un procedimiento rutinario, pero no por ello deja de ser importante.

Ah!!! Leches, que se  me olvidaba decirtelo. Cada escena, tiene asociado un número por Unity, el cual es un indice que indica cual escena, es cual. Por ejemplo, supongamos que tenemos la pantalla de inicio del juego, pues bien, digamos que es nuestra escena 0, mientras que la parte del gameplay del juego, podria ser perfectamente la escena 3, mientras que la escena de la ventanas de opciones del juego sería tranquilamente la dos.

Para ver el número asociado de cada escena, tenemos que dirigirnos en el menú principal de Unity a `File`->`Build Setting`. 

![Pantalla Build Setting](../img/11_Build_Setting.png)

Ahí podremos ver en el apartado que pone **Scenes in Build**, todas las escenas que componen nuestro juego, y justamente al lado derecho, podremos ver el indice que nos indica que número de escena es. Antes de seguir, voy a comentar, que para añadir nuevas escenas, lo podemos hacer de dos formas.


* __Forma 1:__ Arrastramos desde el editor la escena que queramos añadir a `Scenes In Build`.
* __Forma 2:__ Haciendo click en el botón que vemos en Build Setting (`Add Open Scenes`).

Para gestionar las escenas desde nuestros `scripts`, lo primero que debemos hacer es importar la directiva `UnityEngine.SceneManagement`.

```c#
using UnityEngine.SceneManagement;//Directiva a importar para manejar escenas
```

Y una vez importada la directiva, podremos cargar la escena simplemente haciendo lo siguiente:

```c#
SceneManagement.LoadScene(0);//El numero es el indice de la escena que queremos cargar.
```

Asi de facil y simple mis pequeños...

Obviamente, esa instrucción ni que decir tiene, que será incluida dentro de nuestro código para que una vez haga una acción, cargue la escena que nosotros queramos.

También podemos cargar la escena, indicandole el nombre de la escena en cuestión:

```c#
SceneManagement.LoadScene("Fase1"); //Este seria el nombre de la escena que fueramos a cargar
```

Aunque como hemos visto, se puede hacer de las dos maneras, lo mas correcto es hacerlo usando el indice. Pero ya tu eres libre de elegir como lo vas a hacer, mi consejo es usar el valor del indice de la escena.

Y si quisieramos darle un retardo a la hora de cargar una escena...?? __Facil!!!__ usamos una corrutina. Tal cual asi:

```c#
void Update()
{
	StartCoroutine(ChangeSceneWithDelay()); //Llamamos a la corrutina que hace el cambio de escena
}

IEnumerator ChangeSceneWithDelay()
{
	yield return new WaitForSeconds(4f); //La escena va a tardar 4 segundos en cargar
	SceneManagement.LoadScene(0); 
}
```

Magnífico!!! Aplaude Paolo!!! (Aplaude... que despues de todo lo que te estoy enseñando, no me agradeces nada...  XD)


De todas formas, ya veremos un poco mas adelante el cambio de escenas en profundidad. De momento, quedate con esto que te acabo de contar, que es lo básico.

Y siguiendo con las escenas, si cargamos una nueva escena y queremos que se hagan cosas al cargar, para ello tenemos el método `OnLevelWasLoaded`. Este es un método de `MonoBehavior` el cual se llama después de que una nueva escena haya sido cargada. Se le pasa como parámetro el indice de la escena en cuestión.

Vamos a ver un ejemplo de como usarlo.

```c#
void OnLevelWasLoaded(int level) //El parámetro level es el indice de la escena que vamos a comprobar que se ha cargado
{
	if(level == 4) //Comprobamos si la escena que se ha cargado ha sido la escena 4
	{
		Debug.Log("Se ha cargado la escena número 4...");
	}
}
```
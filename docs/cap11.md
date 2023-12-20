# Capítulo 2: Scripting en Unity
## 2.11 - Cosas interesantes para hacer con C#

La infinidad de cosas que podemos hacer con C# para darle vida a nuestros juegos, es infinita, el único límite que tenemos es la propia imaginación del desarrollador.

Por ello, en este capítulo, vamos a ver algunas cositas que podemos hacer, algunas serán bastante obvias, pero que seguramente se te puede venir al cerebelo esa pregunta tan puñetera, como es... `Y esto como lo hago???!!`. Pues bien, no sufras, que para eso estamos aquí.

### 2.11.1 - Como cambiar de escena

El cambio de escena en un juego, es algo muy rutinario, dado que cada escena representa o puede representar un nivel de nuestro juego, obviamente esto puede ser así, si tu juego va a tener varios niveles, en caso contrario, el cambio de escena, puede ser debido a que vayas a entrar en un sitio, presentar algo, el menú de juego es otra escena, los créditos, una fase bonus, todo eso son escenas.

Para que nos enteremos. Un juego está compuesto de escenas. Cuando tu le das a un botón por ejemplo, para abrir las preferencias del juego (ya sabes, eso típico que te pone activar desactivar sonido, poner o quitar la música del juego, configurar los controles, etc) lo que estas haciendo es mostrar otra escena, que no necesariamente una escena tiene que ser solo y exclusivamente el Game Play del juego. Cada cosa que le muestras al usuario, está contenido en una escena, por ello, los cambios de escena es algo que se hacen continuamente. Espero que te haya quedado mas claro con esta explicación magistral que te acabo de dar.

Que nada, que como ya te he dicho, es un procedimiento rutinario, pero no por ello deja de ser importante.

Ah!!! Leches, que se  me olvidaba decírtelo. Cada escena, tiene asociado un número por Unity, el cual es un indice que indica cual escena, es cual. Por ejemplo, supongamos que tenemos la pantalla de inicio del juego, pues bien, digamos que es nuestra escena 0, mientras que la parte del gameplay del juego, podría ser perfectamente la escena 3, mientras que la escena de la ventanas de opciones del juego sería tranquilamente la dos.

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

Así de fácil y simple mis pequeños...

Obviamente, esa instrucción ni que decir tiene, que será incluida dentro de nuestro código para que una vez haga una acción, cargue la escena que nosotros queramos.

También podemos cargar la escena, indicándole el nombre de la escena en cuestión:

```c#
SceneManagement.LoadScene("Fase1"); //Este seria el nombre de la escena que fuéramos a cargar
```

Aunque como hemos visto, se puede hacer de las dos maneras, lo mas correcto es hacerlo usando el indice. Pero ya tu eres libre de elegir como lo vas a hacer, mi consejo es usar el valor del indice de la escena.

Y si quisieramos darle un retardo a la hora de cargar una escena...?? __Fácil!!!__ usamos una corrutina. Tal cual así:

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

Magnífico!!! Aplaude Paolo!!! (Aplaude... que después de todo lo que te estoy enseñando, no me agradeces nada...  XD)


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

Como vemos en el ejemplo, simplemente estamos comprobando dentro del método `OnLevelWasLoaded`, que la escena que se haya cargado sea la escena número 4, en cuyo caso, si efectivamente se carga dicha escena, lo que hacemos es mostrar un mensaje por la consola de Unity, indicando que efectivamente se ha cargado.

Ni que decir tiene a estas alturas, que esto, irá dentro de un `script`, el cual estará aplicado a un `GameObject` de nuestra escena. Y tu mi joven aprendiz, te estarás preguntando... (sino, piénsalo con calma... tómate tu tiempo) si voy a comprobar si la escena que he cargado es la 4, en que `GameObject` o en que escena tengo que aplicar el `script`?? Bien, iré por partes. En cuanto al `GameObject` al que aplicar el `script` te puedo decir, que al que te de a ti la gana... eso es a tu criterio. Y en cuanto a la segunda pregunta (en que escena debo aplicar el `script`?), te respondo con un ejemplo. 

Imaginate, que estas en la escena de tu juego (pongamos que es la escena 2), y que si te metes en una cueva (la cual corresponde a una escena que diremos por ejemplo que es la 3) y si te metes en una casa se cargaría la escena de dentro de la casa (que sería por ejemplo la escena 4), pues bien para aplicar el `script` que usa `OnLevelWasLoad`, deberíamos aplicarlo en la escena actual (recuerda que hemos dicho que es la escena __2__), por lo que si accedemos a la cueva (escena __3__) no saltaría, pero si accedemos a la casa (escena __4__) si nos saltaría. 

En resumen, el script lo aplicamos en la escena donde estemos, para que compruebe que cuando cambiemos de escena, la que se haya cargado sea la que nosotros queremos con nuestro `OnLevelWasLoad`.

Se que ahora mismo quizás, estés hecho la picha un lío. Es normal. Pero voy a ver si consigo que te hagas una idea para que lo pilles mejor.

Imagina, que estas en la pantalla previa a un jefe final, pero que no aparece hasta que no consigas una serie de objetos. Bien, pues si pasamos de la escena previa a la del jefe, mediante `OnLevelWasLoaded` podemos hacer las comprobaciones pertinentes, primero, para verificar que estemos en la escena en concreto y segundo que llevamos todo lo necesario para que nos aparezca el Monstruaco gordo (_Bicho Gordo Cansino que te mata_), en ese caso (llevamos todos los trastos y se ha cargado la escena final), entonces poder instanciar al "__Bicharraco__". 

Que porque no instanciarlo antes?? Simple. Porque a lo mejor, en esa escena queremos poder entrar para hacer cosas antes, y no por ello tiene que aparecer nuestro "__Bicharraco__". 

Lo pillas??

Bueno, creo que ya con esto puede quedar mas clarito para que, cuando, como y donde emplear `OnLevelWasLoad`.
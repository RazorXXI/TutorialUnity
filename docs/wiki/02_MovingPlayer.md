# Movimiento, salto y comprobación de colisiones

Agarrate que vienen curvas... 

En esta parte ya vamos a empezar a escribir código para programar a nuestro "moñeco" para que haga algo, que ahí parado nos queda muy aburrido y si no se mueve, que mierda de juego es este... (Nota mental... Se me ocurre un juego con eso...).

Pues bien, como hemos dicho, ya aquí vamos a empezar a programar para poder hacer cosas, toma lapiz y papel que te voy a dar una explicación magistral, mi joven discípulo.

## Preparando las cosas para mover al muñeco

Comenzemos por crear una carpeta dentro de nuestro proyecto a la que pondremos el nombre de `Scripts`. En ella vamos a guardar nuestros __Scripts__ los cuales van a conseguir que nuestro juego cobre vida. 

De momento y para empezar, vamos a crear el primero de todos ellos, para mover a nuestro "moñeco". Pues bien, ya tienes la carpeta creada (entiendo que eres un buen chico y la has creado cuando te lo he dicho no...???? En caso contrario, ya estas tardando en crearla), nos vamos dentro de ella y con el boton derecho del raton dentro de la carpeta, le damos a `Create` -> `C# Script` y nos creara un archivo C# que serà donde pongamos nuestro script. A este archivo lo vamos a llamar `PlayerController`. 

Muy importante!! Debemos cargar a nuestro personaje, un componente `Rigidbody2D` que será el que nos sirva para moverlo y hacer otras cosas, asi que si aun no lo tiene, ponselo.

Ya aplicado el `Rigidbody2D` a nuestro Player, donde pone `Constraints` abrimos y marcamos la casilla que pone `Z`. De este modo, bloqueamos cualquier giro o rotación del personaje. Esto es muy importante, porque sino, el muñeco se pondrá a hacer cosas rarisimas.

![Freeze Rotation](imgWiki/11_FreezeRotation.png)

Aun no tenemos del todo preparado a nuestro querido amigo, asi que lo siguiente que vamos a hacer, es añadirle un `Capsule Collider 2D`, asi que ya sabes, ponselo para que no se caiga.

Además, vamos a ajustar el `Collider` que le hemos puesto a nuestro player, para ello hacemos click en `Edit Collider`.

![EditCollider](imgWiki/11_EditCollider.png)

Ajustaremos el `Collider` del player, para que nos quede algo parecido a esto.

![PlayerCollider](imgWiki/11_PlayerCollider.png)

Una vez hecho todo lo anterior, nos vamos a la carpeta `Scripts`, seleccionamos nuestro archivo y hacemos doble click o le damos a Intro para que nos abra `Visual Studio` y aquí es donde vamos a hacer cosicas ya para mover al "moñeco". Y aquí es donde empieza el Rock 'n' Roll.

### Preparando propiedades y métodos

Lo primero que vamos a crear, son una serie de propiedades, las cuales nos van a servir para poder mover inicialmente a nuestro personaje horizontalmente.

Para ello vamos a crear dos propiedades:

 - La primera para ajustar la velocidad a la que se va a mover el personaje.
 - La segunda será para refernciar el `Rigidbody` de este.

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocity;
    Rigidbody2D rbPlayer;

```

Lo siguiente que tenemos que hacer es referenciar al `Rigidbody2D` de nuestro Player. Para ello haremos lo siguiente. Dentro del método `Star`, vamos a asignar nuestra variable `rbPlayer`, la cual la definimos anteriormente y mediante `GetComponent` vamos a acceder al componente `Rigidbody2D` de nuestro Player.

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocity;	//Para la velocidad de movimiento horizontal
    Rigidbody2D rbPlayer;		//Para referenciar el Rigidbody2D del player

	private void Start()
    {
    	//Referenciamos el Rigidbody2D del player
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
    }
```

A continuación, lo siguiente que tenemos que hacer, es crear una función para mover horizontalmente a nuestro Player. Así que vamos a crear un método privado al que vamos a llamar `MoveHorizontalPlayer`, el cual basicamente lo va a hacer es aplicar una fuerza horizontal al personaje para moverlo por el terreno. Asi que, sin mas dilación vamos a definir nuestra función.

```c#
void MoveHorizontalPlayer()
    {
        //Aplicamos una fuerza para desplazar al personaje horizontalmente
        rbPlayer.AddForce(Vector2.right * velocity * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
    }
```

Antes de continuar, vamos a explicar un poco que hace esta función.

En primer lugar, accedemos al método `AddForce` del `Rigidbody2D` de nuestro player, al que hemos llamado `rbPlayer`. Despues, le pasamos como parámetros una ristra que basicamente lo que hace es:

 - Un `Vector2.right` que lo que hace es indicar que el desplazamiento será en sentido horizontal.
 - Multiplicamos lo anterior por la propiedad `Velocity` la cual la hemos definido previamente como variable de clase.
 - Multiplicamos por el valor devuelto por la función `Input.GetAxisRaw`, la cual nos devuelve un `float`, que vendrá dado por lo que indique según pulsemos las teclas de manejo `Horizontal`.
 - Y por ultimo, multiplicamos por `Time.deltaTime`, para que así el movimiento resultante sea dependiente de la actualización entre frames.

No se si te queda claro, pero basicamente y en resumidas cuentas, para mover un objeto 2D lo que haces es aplicar fuerza, que iran en un sentido, que estara definido por una velocidad, un tiempo y el valor que devuelva según pulses la tecla para moverte. Se que es un poco lioso, pero con practica lo iras pillando sin muchas complicaciones. Asi que, seguimos.


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

Lo siguiente que tenemos que hacer es referenciar al `Rigidbody2D` de nuestro Player. Para ello haremos el siguiente código.

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

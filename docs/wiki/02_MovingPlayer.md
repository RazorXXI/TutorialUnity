# Movimiento, salto y comprobación de colisiones

Agarrate que vienen curvas... 

En esta parte ya vamos a empezar a escribir código para programar a nuestro "moñeco" para que haga algo, que ahí parado nos queda muy aburrido y si no se mueve, que mierda de juego es este... (Nota mental... Se me ocurre un juego con eso...).

Pues bien, como hemos dicho, ya aquí vamos a empezar a programar para poder hacer cosas, toma lapiz y papel que te voy a dar una explicación magistral, mi joven discípulo.

## Preparando las cosas para mover al muñeco

Comenzemos por crear una carpeta dentro de nuestro proyecto a la que pondremos el nombre de `Scripts`. En ella vamos a guardar nuestros __Scripts__ los cuales van a conseguir que nuestro juego cobre vida. 

De momento y para empezar, vamos a crear el primero de todos ellos, para mover a nuestro "moñeco". Pues bien, ya tienes la carpeta creada (entiendo que eres un buen chico y la has creado cuando te lo he dicho no...???? En caso contrario, ya estas tardando en crearla), nos vamos dentro de ella y con el boton derecho del raton dentro de la carpeta, le damos a `Create` -> `C# Script` y nos creara un archivo C# que serà donde pongamos nuestro script. A este archivo lo vamos a llamar `PlayerController`. 

Muy importante!! Debemos cargar a nuestro personaje, un componente `Rigidbody2D` que será el que nos sirva para moverlo y hacer otras cosas (es el que va a controlar las físicas de nuestro personaje), asi que si aun no lo tiene, ponselo.

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

Para ello vamos a crear tres variables:

 - La primera para ajustar la velocidad a la que se va a mover el personaje.
 - La segunda para indicar la velocidad máxima a la cual se moverá el personaje
 - La tercera será para refernciar el `Rigidbody` de este.
 - La cuarta será para guardar hacia donde va nuestro player (-1 Izquierda, 0 Parado o 1 Derecha)

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    Rigidbody2D rbPlayer;
    float horDisplace;

```

Lo siguiente que tenemos que hacer es referenciar al `Rigidbody2D` de nuestro Player. Para ello haremos lo siguiente. Dentro del método `Star`, vamos a asignar nuestra variable `rbPlayer`, la cual la definimos anteriormente y mediante `GetComponent` vamos a acceder al componente `Rigidbody2D` de nuestro Player.

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    Rigidbody2D rbPlayer;
    float horDisplace;

    private void Start()
    {
    	//Referenciamos el Rigidbody2D del player
        rbPlayer = GetComponent<Rigidbody2D>();
    }
```


## Moviendo el Personaje

A continuación, lo siguiente que tenemos que hacer, es crear una función para mover horizontalmente a nuestro Player. Así que vamos a crear un método privado al que vamos a llamar `MoveHorizontalPlayer`, el cual basicamente lo va a hacer es aplicar una fuerza horizontal al personaje para moverlo por el terreno. Asi que, sin mas dilación vamos a definir nuestra función.

```c#
void MoveHorizontalPlayer()
    {
        horDisplace = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity =new Vector2(playerSpeedMax * horDisplace,rbPlayer.velocity.y);
        rbPlayer.AddForce(Vector2.right * playerSpeed * horDisplace);
    }
```

Antes de continuar, vamos a explicar un poco que hace esta función.

Primero, vamos a ajustar la velocidad de nuestro player. Esto lo vamos a hacer, accediendo a la propiedad `velocity` de su `Rigidbodo`. Le pasaremos como parámetros a un `Vector2`, `playerSpeedMax`, la cual ser la que indicará de manera fija que velocidad alcanzará como máximo y este lo multiplicaremos por la variable `horDisplace` cuyos valores estaran entre -1 y 1, de este modo, tendremos una velocidad fija para cuando vayamos a la izquiera o la derecha. El siguiente parámetro del `Vector2`, será e valor de `velocity` en el eje `y` actual del player.

En segundo lugar, accedemos al método `AddForce` del `Rigidbody2D` de nuestro player, al que hemos llamado `rbPlayer`. Despues, le pasamos como parámetros una ristra que basicamente lo que hace es:

 - Un `Vector2.right` que lo que hace es indicar que el desplazamiento será en sentido horizontal.
 - Multiplicamos lo anterior por la variable `playerSpeed` la cual la hemos definido previamente como variable de clase.
 - En  último lugar multiplicamos por el valor de `horDisplace`, de este modo, la fuerza a aplicar será positiva o negativa.

No se si te queda claro, pero basicamente y en resumidas cuentas, para mover un objeto 2D lo que haces es aplicar fuerza, que iran en un sentido, que estara definido por una velocidad, un tiempo y el valor que devuelva según pulses la tecla para moverte. Se que es un poco lioso, pero con practica lo iras pillando sin muchas complicaciones. Asi que, seguimos.

Antes de que se me olvide, también podriamos haber usado `transform.position` para mover al personaje, pero es mas correcto el uso de las físicas, ademas es bastante mas eficiente, pero si te hace ilusión, cuando llegue al final, te enseñaré la forma de hacer usando `transform.position`. Tu eres libre de usar la que te de la real gana.

A continuación, vamos a incluir este método dentro del `FixedUpdate` de Unity, dejando el codigo asi:

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    Rigidbody2D rbPlayer;
    float horDisplace;

    private void Start()
    {        
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveHorizontalPlayer(); //Con esto conseguimos que nuestro player se mueva
    }

    void MoveHorizontalPlayer()
    {
        horDisplace = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity =new Vector2(playerSpeedMax * horDisplace,rbPlayer.velocity.y);
        rbPlayer.AddForce(Vector2.right * playerSpeed * horDisplace);
    }
}
```

Lo siguente que podemos hacer, es aplicar el `Script` a nuestro personaje y probar como se comporta. Te vas a llevar alguna sorpresa, pero como soy muy chungo, te la voy a contar antes de que la veas:

 * Si movemos a nuestro muñeco a izquierda y derecha, siempre mira hacia la derecha.

Bien, despues del `Spoiler` que te acabo de hacer de este pequeño fallo (y ademas cosa normal), te voy a contar como vamos a solucionarlo.

## Hacer que el muñeco mire a izquierda o derecha segun vaya en un sentido o en otro.

Este es un problema relativamente sencillo de solucionar. Para ello, simplemente vamos a crear una funcion que llamaremos `ChangeLook` la cual se encargará de cambiar hacia donde mira nuestro personaje, y ademas, crearemos una variable de clase a la cual llamaremos `lookRight` la cual nos servirá de interruptor para comprobar si está mirando hacia la derecha o no, y de ese modo ajustar si valor.

Asi que bien, vamos a comenzar declarando la variable de clase `lookRight` del siguiente modo:

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    Rigidbody2D rbPlayer;
    float horDisplace;
    bool lookRight;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        lookRight = true;
    }

```

Lo siguiente que haremos será crear nuestra función `ChangeLook`.

```c#
void ChangeLook()
{
    float horizontal = Input.GetAxisRaw("Horizontal");
        
    if((horizontal>0 && !lookRight)||(horizontal<0 && lookRight))
    {
        lookRight = !lookRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
```

Creo que la función queda bastante claro lo que hace no? Por un lado, creamos una variable local, que hemos llamado `horizontal`, la cual guardará el valor devuelto (`Tipo float`) de si pulsamos a izquierda o derecha. A continuación comprobamos si el valor de horizontal es `positivo` (se desplaza hacia la derecha) y si no mira a la derecha, o si el valor horizontal es `negativo` y mira hacia la derecha.

Vamos a entenderlo poco a poco:
 
 - Si el valor horizontal es positivo, indica que nos movemos hacia la derecha (todo desplazamiento del 0 hacia la derecha es positivo) y ademas, vemos si al movernos a la derecha el valor de lookRight es falso, con lo cual quiere decir, que te mueves a la derecha pero mira a la izquierda (cosa que esta mal).

 - Si el valor horizontal es negativo, indidca que nos movemos hacia la izquierda (todo desplazamiento del 0 hacia la izquierda es negativo) y ademas, comprobamos si al movernos a la izquierda, el valor de lookRight es verdadero, lo cual indica que mira hacia la derecha (cosa que esta mal)

Pues bien, si vamos hacia la derecha pero miramos a la izquierda o si vamos hacia la izquierda pero miramos hacia la derecha (estoy explicandote la condición del `if`), lo que hacemos es:

 1 - Asignar a lookRight su valor contrario (`lookRight = !lookRight`).
 
 2 - Usar el `transform.localScale` del player para hacer que mire a un sitio u otro. Para ello, simplemente declaramos un `Vector3`, al cual le pasamos como parámetro un `transform.localScale.x * -1`, que lo que hace es cambiar el valor de la escala horizontal del personaje, haciendo asi que se refleje a izquierda o derecha, segun sea positivo o negativo, para el resto de parámetros del `Vector3` indicamos que las `localScale` de `Y` y de `Z`, se mantengan igual.

Bien, pues ya que tenemos la función que nos pone a nuestro player mirando a izquierda o derecha, solo nos queda aplicarla en nuestro código. Para ello la vamos a incluir dentro de la función `Update` de Unity, dado que esta comprobación se realiza a nivel de `frames` y no se emplean fisicas para ello. Asi que se nos queda el codigo de nuestro `script` de momento tal que así:

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    
    Rigidbody2D rbPlayer;
    
    float horDisplace;
    bool lookRight;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        lookRight = true;
    }

    private void Update()
    {
        ChangeLook();
    }

    private void FixedUpdate()
    {
        MoveHorizontalPlayer(); //Con esto conseguimos que nuestro player se mueva
    }

    void MoveHorizontalPlayer()
    {
        horDisplace = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity =new Vector2(playerSpeedMax * horDisplace,rbPlayer.velocity.y);
        rbPlayer.AddForce(Vector2.right * playerSpeed * horDisplace);
    }

    void ChangeLook()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if((horizontal>0 && !lookRight)||(horizontal<0 && lookRight))
        {
            lookRight = !lookRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
```

Ahora si que si, ya cuando movemos a nuestro pixelado amigo, vemos que mira al lado donde se mueve. Problema solucionado... Si es que somos buenos a rabiar!!! Echaté un Cola-Cao que te lo has ganado Michael!!! mas aun despues de haber llegado aquí sin mandarme a freir monas. Se que esto es un pelín densito, pero es que no hay otra forma mi joven amigo, se que soy muy cansino, pero trato de explicartelo de manera que lo entiendas lo mas clarito posible. Esto solo es una pequeña base para que tu puedas hacer cosas mas complejas. Asi que paciencia, tomate el Cola-Cao, que vamos a seguir.

Bien, antes de seguir, para las pruebas vamos a aplicar los siguientes valores en la ventana `Inspector` a las variables `playerSpeed` y `playerSpeedMax`

| Variable | Valor |
|:---|:---|
| playerSpeed | 10 |
| playerSpeedMax | 5 |

## Haciendo que nuestro personaje salte

Lo que vamos a hacer a continuación, es crear una función, la cual permitira a nuestro personaje saltar. Para ello lo primero que vamos a crear es una propiedad para darle valor a la fuerza de salto, y la vamos a llamar `jumpForce`.

`[SerializeField] float jumpForce;`

A continuación pasaremos a crear la función, la cual será tal que así:

```c#
void JumpPlayer()
{
    if (Input.GetButtonDown("space"))
    {
        rbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
```

Básicamente nuestra función lo que hace es, comprobar si se ha pulsado la tecla `Espacio`, y si es así, se le aplica al personaje una fuerza hacia arriba la cual será multiplicada por el valor de `jumpForce`.

A continuación, procedemos a colocar la función que hemos creado dentro del `Update`, quedando nuestro código del siguiente modo:

```c#
public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    [SerializeField] float jumpForce;

    Rigidbody2D rbPlayer;
    
    float horDisplace;
    bool lookRight;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        lookRight = true;
    }

    private void Update()
    {
        ChangeLook();
        JumpPlayer();
    }

    private void FixedUpdate()
    {
        MoveHorizontalPlayer(); //Con esto conseguimos que nuestro player se mueva
    }

    void MoveHorizontalPlayer()
    {
        horDisplace = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity =new Vector2(playerSpeedMax * horDisplace,rbPlayer.velocity.y);
        rbPlayer.AddForce(Vector2.right * playerSpeed * horDisplace);
    }

    void ChangeLook()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if((horizontal>0 && !lookRight)||(horizontal<0 && lookRight))
        {
            lookRight = !lookRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void JumpPlayer()
    {
        if (Input.GetButtonDown("space"))
        {
            rbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
```

Ahora vamos a asignar en el panel `Inspector` un valor de __5__ a la propiedad `Jump Force` y vamos a darle a __Play__ para ver como se comporta.

Si nos fijamos, si le damos varias veces al __Espacio__ nuestro personaje sigue saltando en el aire, lo cual no es lo suyo, salvo que queramos hacer una versión bastarda de _Flappy Bird_ (que por ahora no es la idea). 

Para arreglar esto, podriamos usar los métodos `OnColliderEnter` o `OnColliderExit`, pero despues de pensar un poco, he tomado la decisión de hacerlo mediante el uso de `Raycast`. Básicamente lo que vamos a hacer, es lanzar un rayo contra el suelo para detectar si estamos encima o estamos en el aire. Creeme, esto es mucho efectivo y nos dará menos dolores de cabeza, que el uso de `OnCollider...`

Lo primero que vamos a hacer, es crear una variable de tipo `bool` a la que llamaremos `OnGround`, la cual almacera `true` o `false` si esta o no el personaje en el suelo.

Lo siguiente es crear una función a la que llamaremos `CheckGround` y que comprobará si está o no en el suelo, para ello lanzaremos un rayo (`raycast`) que si impacta en el suelo devolvera `true`.

Antes de nada, vamos a crear una variable de clase a la que llamaremos:

`[SerializeField] float distanceRay;`

Seguidamente escribiremos la función:

```c#
void CheckGround()
{
    Debug.DrawRay(transform.position, Vector2.down*distanceRay, Color.red);

    if (Physics2D.Raycast(transform.position, Vector2.down, distanceRay))
    {
        OnGround = true;
    }
    else
    {
        OnGround = false;
    }
}
```

Quedandonos el código del siguiente modo:

```c#
{
    [SerializeField] float playerSpeed;
    [SerializeField] float playerSpeedMax;
    [SerializeField] float jumpForce;
    [SerializeField] float distanceRay;

    Rigidbody2D rbPlayer;
    
    float horDisplace;
    bool lookRight;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        lookRight = true;
    }

    private void Update()
    {
        ChangeLook();
        CheckGround();
        JumpPlayer();
    }

    private void FixedUpdate()
    {
        MoveHorizontalPlayer(); //Con esto conseguimos que nuestro player se mueva
    }

    void MoveHorizontalPlayer()
    {
        horDisplace = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity =new Vector2(playerSpeedMax * horDisplace,rbPlayer.velocity.y);
        rbPlayer.AddForce(Vector2.right * playerSpeed * horDisplace);
    }

    void ChangeLook()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if((horizontal>0 && !lookRight)||(horizontal<0 && lookRight))
        {
            lookRight = !lookRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    void JumpPlayer()
    {
        if (Input.GetButtonDown("space"))
        {
            rbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void CheckGround()
    {
        Debug.DrawRay(transform.position, Vector2.down*distanceRay, Color.red);

        if (Physics2D.Raycast(transform.position, Vector2.down, distanceRay))
        {
            OnGround = true;
        }
        else
        {
            OnGround = false;
        }
    }
}
```

Como valor de la variable `distanceRay`, le aplicaremos en el `Inspector` un valor de 0.6

Asi que nos queda los valores de las variables del siguiente modo:

| Variable | Valor |
|:---|:---|
| playerSpeed | 10 |
| playerSpeedMax | 5 |
| jumpForce | 5 |
| distanceRay | 0.6 |

Pues bien, hasta aquí hemos visto como hacer que nuestro muñeco se mueva y salte, creo que ha sido bastante instructivo y espero que te haya quedado claro como hacer esto. En principio y recapitulando, veras que no es excesivamente dificil hacer mover o saltar a nuestro personaje, basicamente se trata de añadir fuerzas y poco mas. Quedate con esto en tu cerebro mi joven padawan, porque te va a ser de gran utilidad.

Para la siguiente parte veremos algunas cosas mas interesantes, como animar a nuestro querido personaje, pero eso ya es harina de otro costal, asi que me piro ya, que por hoy esta bien.

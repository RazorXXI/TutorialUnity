# Gestión de GameObjects mediante Scripts

Aquí ya empieza la chicha buena. Vete por un cafelito, cola-cao o lo que te guste, que aquí hay para rato.

Ya volviste con algo para meter al estomago? Pues comencemos, que esta parte es densa de narices.

## Instanciando GameObjects

Como ya hemos visto, un `script` nos permite hacer cosas con nuestros `GameObjects`, pero ademas, nos permite *instanciar* (crear) y destruir `GameObjects` en tiempo de ejecución.

El método que nos permite crear `GameObjects` es **`instantiate`**. Para usarlo, es necesario una referencia al `GameObject` que se va a crear (*instanciar*).

La sintaxis de `instantiate` es la siguiente:
```c#
instantiate(prefabReferencia, posicion, rotacion);
```

Ahora vamos a explicar sus parámetros:
- prefabReferencia: Es una referencia al `GameObject` o `Prefab` que queremos crear.
- posicion: Es un `vector3` el cual va a indicar el punto de aparición del `GameObject`que vamos a crear.
- rotacion: Es un `Quaternion` que va a indicar la rotación con que aparecerá en la escena nuestro objeto.

Para entender esto mejor, que se que puede ser lioso, vamos a ver un ejemplo y a explicarlo paso a paso.

```c#
public GameObject personajeEnemigo;
//Aqui hay mas cosas que no interesan

void Star()
{
  Instantiate(personajeEnemigo, transform.position, Quaternion.identity);
  //Mas cosas para inicializar
}
```

Bien, vamos por partes:

1. `personajeEnemigo` es un `GameObject` que hemos declarado como publico, el cual va a tener la referencia del `prefab` que vamos a querer instanciar. La referencia se la damos a través del editor de Unity, arrastrando el `prefab` o el `GameObject`.
2. `transform.position` es un `Vector3` de posición. En el ejemplo, la orden `transform.position` indica que la posición donde se va a crear el nuevo `GameObject` será justo en la posición donde se encuentra el `GameObject` que porta el `script`.
3. `Quaternion.identity`, es una variable de tipo `Quaternion`, la cual indicar la rotación. Para este ejemplo, la instrucción `Quaternion.identity`, indica que el nuevo `GameObject` se creará con la misma rotación que el objeto que porta el `script`.

De momento hasta aquí fácil verdad??

Ahora vamos a ver otro ejemplo guapo. Vamos a crear un objeto, cuando presionemos una tecla.

```c#
[SerializeField]
GameObject miNuevoObjeto; //No olvidemos de referenciar a un prefab

//Aquí se están haciendo cosas... pasa mas abajo

void Update()
{
  if(Input.GetKeyDown(KeyCode.Space)) //Cuando pulsemos la barra espaciadora
  {
    Instantiate(miNuevoObjeto, transform.position, Quaternion.identity);
  }
}
```

Voy a explicarte como funciona:
1. La condición de nuestro `if` comprueba si pulsamos (`Input.GetKeyDown()`) la tecla barra espaciadora (`KeyCode.Space`).
2. En caso afirmativo de pulsar la barra espaciadora, crearemos un nuevo `GameObject`, el cual hemos referenciado previamente en la variable `miNuevoObjeto`.

Ves que facilito es esto.

Vale, ahora te voy a dar una serie de **TRUCONSEJOS** para que te ayuden a hacerte una idea de algunas cosas que podemos hacer.

|**TRUCONSEJO 1**|
|:---|
|**Cuando queramos generar nuevos objetos, como por ejemplo, balas, monedas u otra cosa, crearemos un objeto vacío "`Empty Object`", al cual se vamos a aplicar el `script` con el que crearemos los objetos que queramos.**|


|**TRUCONSEJO 2**|
|:---|
|**Si queremos crear una vista en primera persona, tenemos que crear una nueva Cámara, y la pondremos de hija del objeto que queramos que tenga ese punto de visión.**|

Bueno, vamos a seguir con el turrón.

Ahora vamos a ver un ejemplo de como generar objetos en un área del espacio de juego, pero de manera aleatoria.

```c#
//Estamos haciendo cosas no moleste y vaya abajo

void Update()
{
  InstantiateMyObject(miObjeto);
}

void InstantiateMyObject(GameObject obj)
{
  int x = Random.Range(18,24);
  int z = Random.Range(78,84);

  Instantiate(obj, new Vector3(x,transform.position.y,z), Quaternion.identity);
}
```

Ostras Pedrín!!! Que hemos hecho aquí??!! Naaa, tranquilo, ahora te cuento:
1. Hemos creado un método al que hemos llamado `InstantiateMyObject` y al cual le vamos a pasar como parámetro un `GameObject` al que indicamos como `obj` en su lista de parámetros.
2. Dentro del método que hemos creado, declaramos dos variables a las cuales hemos llamado `x` y `z`. A su vez, a cada una le hemos asignado un valor de manera aleatoria, el cual es aportado por la función `Random.Range`.
3. Los parámetros de `Random.Range`, nos indican que esta va a generar un número aleatorio el cual este comprendido entre un "mínimo" y un "máximo" que son indicados mediante los parámetros de esta (como por ejemplo 18,24).
4. Por último, llamamos al método `Instantiate` pasando como parámetros lo siguiente:
    - obj: El `GameObject` que vamos a crear y que es suministrado mediante el parámetro de entrada `obj` de nuestro método.
    - `new Vector3(x, transform.position.y,z)`: Estamos indicando una posición para crear el objeto en la cual se define mediante los valores que le pasamos a `Vector3`:
      - x: Variable x la cual tiene un valor aleatorio generado previamente.
      - transform.position.y: El valor de la coordenada `y` que tiene el `gameObject` que porta el `script`.
      - z: Variable z la cual tiene un valor aleatorio generado previamente.
    - Quaternion.identity: Valor de la rotación que tiene el `gameObject` que porta el `script`.

Ya ves que no es tan complicado de entender. Se que acabamos de ver muchos conceptos de golpe y porrazo, pero tranquilo que con paciencia y practica los vas a ir pillando rápido y bien.

Bueno, vamos a seguir viendo ejemplos para ir metiéndonos en la mollera todo esto. Ahora vamos a hacer algo mas chupi pirulí, vamos a ver un ejemplo de como disparar una bala cuando pulsemos una tecla (esto ya te gusta mas eeehh... que eres John Wayne...).

Antes de ver el ejemplo, voy a dar una serie de pautas a tener en cuenta:
1. Debemos tener en nuestra escena un objeto que sea el que dispare la bala (el jugador, un `prefab`, un cañón, algo...).
2. Debemos aplicar al `prefab` que vaya a corresponder con la bala, un `Rigidbody` (**ESTO ES MUY IMPORTANTE QUE NO SE TE OLVIDE DE HACER**, que después me vienes con que no te funciona... avisado quedas).
3. Tenemos que crear el `script` que va a efectuar el disparo de la bala.

Bien, ya que te he explicado como hay que hacerlo, vamos a meternos en el fregao:

```c#
public class DispararBala : MonoBehaviour
{
  [SerializeField] Rigidbody bala;
  [SerializeField] Transform salidaDeBala;
  [SerializeField] float velocidadDisparo;
  [SerializeField] float retardoSalidadBala;
  float intervaloDisparo;

  //Vete para abajo que aqui no hay nada que te interese

  void Update()
  {
    Rigidbody laBala;

    if(Input.GetKeyDown(KeyCode.Space) && Time.time > intervaloDisparo)
    {
      intervaloDisparo = Time.time + retardoSalidadBala;
      laBala = Instantiate(bala,salidaDeBala,Quaternion.identity) as Rigidbody;

      laBala.AddForce(salidaDeBala.forward * 100 * velocidadDisparo);
    }
  }
}
```

Seguro que te estas preguntando (Madre mía... pero que ha hecho este aquí??!!). Es poca cosa realmente, ahora te voy a ir explicando primero para que sirve cada cosa y que hace el código, que realmente es mu simple.

Veamos las variables, para que sirve cada una:
- `bala`: Es la referencia que vamos a realizar desde el editor de Unity al `prefab` que represente nuestra bala.
- `salidaDeBala`: Es la referencia de la posición del objeto que va a crear la bala (a partir de aquí, a los objetos que crean objetos, vamos a darles su nombre técnico correcto que es `spawner`, así que a partir de aquí acostumbrate a verlo y usarlo, vamos a ser un poco profesionales).
- `velocidadDisparo`: Va a representar un valor que será la velocidad con la que saldrá la bala una vez creada.
- `retardoSalidaBala`: Indica un tiempo de retardo, desde que se dispara una bala y hasta que se pueda disparar la siguiente. Para que no salgan todas juntas, vamos.
- `intervaloDisparo`: Es la cadencia de disparo, la cual es un valor calculado en función al tiempo.

Vale, ahora que ya sabes que es cada variable y para que sirve, te voy a explicar un poquito que hace este código:

1. Ni que decir tiene, que lo primero que hacemos es declarar las variables que vamos a usar... Yo te lo digo por si acaso.
2. Dentro de nuestro maravilloso método `Update`, creamos un objeto `Rigidbody` al cual hemos llamado `laBala` y que va a ser el que porte el `Rigidbody` del objeto instanciado.
3. Con nuestro `if` comprobamos si hemos pulsado la barra espaciadora y si el tiempo transcurrido es mayor que el valor del intervalo que hemos indicado para que salga una bala.
4. Si la condición del `if` se cumple:
    - Primero asignamos el intervalo aplicando una suma del tiempo transcurrido y del retardo de la salida de la bala.
    - Instanciamos la bala.
    - Aplicamos una fuerza a la bala con los siguientes parámetros:
      - La bala saldrá hacia delante (`salidaDeBala.forward`).
      - Multiplicado por un valor que hemos decidido que sea 100 y por el valor de la variable `velocidadDisparo`.

Realmente simple verdad? De este modo, creamos el disparo de la bala con muy pocas líneas de código y ya podemos ponernos a crear nuestro propio **Doom**. (Tranquilo Lucke, que para eso aun te queda un rato, pero vas por buen camino).

Bueno, vamos a seguir haciendo cosas con los `scripts`. Ahora vamos a crear un `script` que mueva o rote un objeto (Si ya vamos a empezar a mover cosas... poco a poco leñe, que Roma no se construyó en 3 días).

Vamos al lio, pero primero, vamos a ver que necesitamos hacer para mover o rotar un objeto:
1. Tenemos que declarar 2 variables de clase, una para los ángulos de rotación y la otra para el movimiento.
2. Tenemos que crear una función para mover y otra para rotar.

Al turrón:

```c#
public class moveAndRotate : MonoBehaviour
{
  [SerializeField] float angleOfRotation;
  [SerializeField] float distanceToMove;  

  //Otra vez mirando aquí... tira para abajo, que aquí se hacen otras cosas

  void FixedUpdate() //Acuérdate que dijimos que usamos este para mover cosas
  {
    RotateObject(); //Llamamos al método para rotar el objeto
    MovingObject(); //Llamamos al método para mover el objeto
  }

  void MovingObject() //Nuestro método para mover
  {
    if(Input.GetKey(KeyCode.UpArrow)) //Vamos a comprobar si pulsamos la flecha arriba
    {
      transform.Translate(vector3.forward * distanceToMove * Time.deltaTime);
    }
    else if(Input.GetKey(KeyCode.DownArrow)) //Comprobamos si pulsamos la flecha abajo
    {
      transform.Translate(vector3.back * distanceToMove * Time.deltaTime);
    }
  }

  void RotateObject() //Nuestro método para rotar
  {
    if(Input.GetKey(KeyCode.LeftArrow))
    {
      transform.Rotate(new Vector3(0, -angleOfRotation,0) * Time.deltaTime);
    }
    else if(Input.GetKey(KeyCode.RightArrow))
    {
      transform.Rotate(new Vector3(0, angleOfRotation,0) * Time.deltaTime);
    }
  }
}
```

Bien, que hace todo esto que hemos puesto aquí? Pues es muy simple. Básicamente lo que hace es mover un objeto por el plano horizontal hacia adelante y hacia atrás, y cuando llamamos al método `RotateObject` hace que el objeto gire hacia la izquierda o la derecha. 

Ahora voy a explicarte, que hace algunas de las funciones de nuestro `script`.

Comenzamos:
- `transform.Translate(vector3.forward * distanceToMove * Time.deltaTime)`: Básicamente esta función lo que hace es mediante `vector3.forward` desplazar el objeto, el cual calculamos su desplazamiento, multiplicando la distancia que queremos que se mueva (`distanceToMove`) por el tiempo (`Time.deltaTime`). Acuérdate de eso de (Espacio = Velocidad * Tiempo). Aquí la velocidad la calculamos con `vector3.forward * distanceToMove` y el tiempo pues creo que queda claro cual es no? (Por si no lo tienes claro, el tiempo lo da `Time.deltaTime`).

|**NOTA**|
|:---|
|**No te voy a explicar lo que hace el if siguiente no?? Ya sabes, con DownArrow vamos a mover hacia atrás el objeto, igual que antes, pero en vez de adelante, hacia atrás (vector3.back)**|

- `transform.Rotate(new Vector3(0, -angleOfRotation,0) * Time.deltaTime)`: Aquí lo que hacemos es llamar al método `Rotate`, al cual le pasamos como parámetros la rotación que queremos hacer en función del tiempo. Para ello creamos un `Vector3` cuyos parámetros los indicamos como (0,-angleOfRotation,0), esto lo que hace, es que solamente rote en torno al eje `y`, dejando fijo los otros dos. El valor de `angleOfRotation` es negativo, dado que estamos realizando un giro hacia la izquierda (sentido anti horario), para un giro a la derecha, ya habrás deducido que el valor de `angleOfRotation` es positivo, ya que gira en sentido horario. Si no lo tienes claro, imaginate un reloj de pulsera, lo normal es que las manecillas giren hacia la derecha (sentido horario, giro positivo, hacia la derecha...), con lo cual para girar a la izquierda tenemos que indicar su valor como negativo (sentido antihorario, giro negativo, hacia la izquierda...).

Ves como no era tan difícil de entender... Vamos bien mi joven amigo... Here we go, que vienen curvas.

Bueno, de momento hemos visto varias cosas:
- Como instanciar objetos.
- Como mover objetos.
- Como girar objetos.

Pues bien, ahora vamos a seguir viendo como instanciar objetos... ¿Otra vez? A que te lo has preguntado mi joven Peregrin Tuk... Pues bien, la respuesta es si, otra vez pero, esta vez vamos a ver como instanciar `GameObjects` y asignarlos a un `array` de `GameObjects`, dado que hasta ahora hemos visto como hacerlo con objetos individuales, ahora vamos a rizar un poco el rizo y vamos a crear `arrays` a la vez que instanciamos.

Nada mejor que un buen ejemplo para verlo mas mejor:

```c#
//Aquí se están haciendo cosas...

[SerializeField] GameObject vehicle; 
//Array para almacenar 10 GameObjects
[SerializeField] GameObject[] createdVehicle = new GameObject[10];
int n; //Lo vamos a usar como indice de nuestro array

void Update()
{
  if(Input.GetKey(KeyCode.Space)) 
  {
    createNewVehicle();
  }
}

void createdNewVehicle()
{
  int x = Random.Range(18,24); //Posición aleatoria en el eje x
  int z = Random.Range(78,84); //Posición aleatoria en el eje z

  createdVehicle[n] = Instantiate(vehicle, new Vector3(x,transform.position.y,z), Quaternion.identity);

  n++; //Incrementamos n cuando creamos un nuevo objeto
}
```

Creo que de momento con lo que te he explicado hasta ahora, este ejemplo no es necesario que te diga lo que hace no?? o Si??...

Bueno, te haré un breve resumen.
1. Hemos creado una variable para referenciar el `prefab` que hemos llamado `vehicle`.
2. A continuación hemos creado un `array` de `GameObject` al cual hemos llamado `createdVehicle` el cual guardará un máximo de 10 `GameObject`.
3. Hemos creado una función que hemos llamado `createdNewVehicle`, la cual lo que hace es, crear un `GameObject`de `vehicle`, en una posición aleatoria y cuya rotación es la del `spawner`[^2] que porta el `script`, donde una vez instanciado el nuevo objeto, es asignado al `array` llamada `createdVehicle` en la posición indicada por `n` y una vez creado y asignado, incrementamos `n` para el siguiente objeto que se cree.
4. Como dijimos, las entradas de datos irán en el `Update`, es por ello que es aquí donde detectamos si se pulsa una tecla o no, en cuyo caso positivo, será llamada nuestro método y creando un nuevo objeto.

[^2]: Acuérdate que te dije que un `spawner` era un objeto que instanciaba `GameObjects`.

Pues ya esta, aquí te he explicado básicamente como funciona y lo que hemos hecho. Todo claro mi joven aprendiz??

## Destruyendo Cosas de Forma Controlada

Uff... mucho tute con esto de crear, mover... jope, que de cosas podemos hacer y todo lo que hemos visto en un ratito. Tranquilo, que aun queda mas, así que yo que tu me iba por un chupachups de Koyak, que esto aun va para largo.

Bien, pues como hemos visto como se crean nuevos objetos en la escena, ahora vamos a ver lo divertido. Como se destruyen objetos en la escena de juego.

Para destruir un `GameObject` se usa el método `Destroy()`.

Vamos a ver como se destruye algo con un ejemplo y lo comentamos:

```c#
void OnCollisionEnter(Collision coll)
{
  if(coll.GameObject.tag == "bullet")
  {
    Destroy(gameObject, 0.5f);
  }
}
```

Vamos a ver que ha pasado aquí y que hace este ejemplo:
1. Primero, el `script` comprueba si un objeto cuyo **TAG** es "*bullet*", colisiona con el `GameObject` que tiene añadido el `script`.
2. Si el objeto cuyo "*tag*" es "*bullet*" colisiona con el `gameObject` que tiene el `script`, entonces:
  - El `gameObject` que tiene el `script` será destruido al transcurso de medio segundo (indicado como el parámetro 0.5f).

Hasta aquí no debe haber problema no?? Esto es mas simple que el mecanismo de un chupete.

Bueno, seguimos con lo que estamos. Recordamos cuando hablamos de los métodos `Find` para localizar cosas en nuestra escena? Pues bien, también podemos buscar objetos como ya dijimos por su clase, o buscar varios objetos y devolverlos en un `array`, pues teniendo esto claro, podemos usar ese `array` para destruir los objetos. Y como? Te estarás preguntando. Pues fácil, simplemente haciendo lo siguiente:

```c#
Destroy(variableArray[indice].gameObject);
```

Tan fácil como eso. De esa forma, localizamos el `GameObject` dentro del array y lo destruimos.

Esta vez la explicación ha sido corta.
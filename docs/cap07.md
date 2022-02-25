# Capítulo 7 - Control de Componentes

En este capítulo vamos a ver muchas cosas, desde como se comunican entre si los `GameObjects`, como interactuan y mazo de cosillas chulas. Ponte cómodo, vete a tomar un refrigerio antes y vuelve, que aquí tenemos para un ratito. Asi que sin mas dilación, vamos ya a meternos en faena.

  ## Como se comunican los Objetos a través del código
  
  Un detalle importante para poder acceder a un componente, es que es necesario tener una referencia al mismo.
  
  Para obtener una referencia a un componente, debemos acceder a este, del siguiente modo:
  
  ```c#
  GetComponent<Componente>();
  ```
  
  Lo vamos a entender mejor con un ejemplo:
  
  ```c#
  public Rigidbody rig = GetComponent<Rigidbody>();
  ```
  
  Con la variable `rig` podemos cambiar los valores de las propiedades del `Rigidbody` referenciado.
  
  Por lo tanto y para que quede completamente claro, la manera de comunicarse con los `GameObjects` es mediante **referencias**.
  
  La manera mas común de referenciar un GameObject, es mediante su asignación (arrastrarlo) en el editor de Unity. Aunque también se pueden referenciar mediante código, eso lo veremos mas adelante, la mas común y cómoda es mediante el arrastrar en el editor.
  
  | **OJO AL MANOJO** |
  |:---|
  | **Cuando creemos un script con una funcionalidad para un objeto, no debemos olvidar REFERENCIARLO para poder usarlo, ya que de lo contrario, el compilador de Unity nos dará un error.** |
  
  Acabamos de ver, la primera manera de comunicarnos con los `GameObjects` mediante la referencia a estos, pero también, nos podemos comunicar gracias a los eventos de tipo `colisión`.
  
  Por ejemplo, un método que nos permite comunicar con un `GameObject`, sería el método `OnTriggerEnter`.
  
  Este método, se ejecuta cuando dos objetos se superponen. Una condición para esto, es que el objeto que porte el `script`, tenga activado en su `Collider`, la propiedad `Is Trigger`.
  
  La sintaxis de este método es:
   
  ```c#
  void OnTriggerEnter(Collider other)
  {
    //Acciones a ejecutar al producirse el método
  }
  ```
  
  Un uso para este método, sería el poner un `Collider` que no se vea y al traspasarlo, se desencadene una acción en nuestro juego.
  
  | **IMPORTANTE** |
  |:---|
  | **"Is Trigger" hace que los objetos sean traspasables, no colisionan o se detienen al chocar.** |
  
  Como ya sabemos, para comunicar un objeto con otro, debe tener en su código, una `referencia`, como variable de clase con la que quiera operar.
  
  Vamos a ver esto mejor con un ejemplo:
  
  ```c#
  //Archivo Enemy.cs
  public class Enemy : MonoBehaviour
  {
    [SerializeField] int life;
  
    //Otras cosas de la clase
  }
  ```

  ```c#
  //Archivo Warrior.cs
  public class Warrior : MonoBehaviour
  {
    [SerializeField] Enemy enemies; //Referencia a la clase Enemy
  }
  ```
  
  Desde el código, podemos acceder a los componentes propios del objeto que tenga aplicado el `script` o a los de otro objeto al que hagamos referencia desde el código.
  
  Una cosa que debemos saber, es que para acceder a los componentes propios debemos realizarlo mediante el siguiente formato de instrucción:
  
  ```c#
  GetComponent<COMPONENTE>().Atributo;
  ```
  
  Por ejemplo:
  
  ```c#
  GetComponent<Rigidbody>().mass = 20; //Hemos accedido al atributo mass del Rigidbody del objeto
  ```
  
  De un modo parecido, para acceder a los componentes y atributos de otro objeto, lo haremos mediante su referencia:
  
  ```c#
  objeto.GetComponent<COMPONENTE>().Atributo;
  ```
  
  Lo vamos a entender mejor con un ejemplo:
  
  ```c#
  public Enemy enemies;
  
  //Otras acciones y funciones
  
  enemies.GetComponent<Rigidbody>().mass = 5;
  ```
  
  Que locura PACO!!! pero aun queda mas, que esto está empezando a ponerse divertido.
  
  También podemos acceder a los atributos de otro objeto, mediante su clase (COMO??!!! AQUI ES CUANDO TE ESTALLA EL CEREBRO!!!)... Pues claro que mediante su clase!!! No se te vaya de vista, que un `Script` es otro componente mas... (LO VAS PILLANDO??).
  
  Bien, ahora te voy a poner un ejemplo de esto que te acabo de contar, para que lo vayas asimilando un poquito mejor:
  
  ```c#
  GameObject enemy;
  //Otras chascas varias
  
  enemy.GetComponent<Enemy>().life;
  //Enemy es el Script donde esta la clase
  //Te acuerdas que puse Enemy.cs un poco mas arriba??
  
  //Y life, es un atributo de la clase Enemy
  ```
  
  Chian Ta Ta Chiaaaaan....!!! Ahora si te acabo de dejar con las patas colgando de la silla, verdad??
  
  Bueno, ahora que lo has empezado a flipar, te diré, que hay también otros métodos muy útiles para localizar `GameObjects` dentro de la escena de juego. Estos son los métodos `Find`, estos nos permiten encontrar y referenciar `GameObjects` dentro de nuestra escena, pero claro... es   demasiado bonito para que sea perfecto. Y porque no es perfecto, te estarás preguntando... ("PREGUNTATELO LEÑE, QUE TE VOY A DAR LA PARRAFADA DEL PORQUE...").
  
  El problema de los `métodos Find` es que para encontrar un objeto, ha de recorrer todos los objetos de la escena. Vas pillando por donde voy?? Y que pasa que tenga que hacer eso?? Pues depende... si solo tienes 3 objetos en la escena (cosa poco probable... ya que tendrás por lo general  el ciento y la madre) no es problema, lo va a encontrar rápido, pero como tengas chorrocientos objetos, es un problema, dado que va a tener que recorrerlos todos para encontrar uno en concreto, y cual es la pega...?? Pues muy fácil, que te va a bajar los FPS y el rendimiento se te va a   ir a por tabaco a Logroño.
  
  Si mi querido amigo, los `find` te petan el rendimiento de tu juego que es cosa mala.
  
  (Jorobas Cuasimodo... Te estarás diciendo... OOOH... SI QUIERO BUSCAR ALGO ME LAS VOY A VER NEGRA... TENGO QUE TENER POCAS COSAS... NO PUEDO USAR FIND... NOOOOO!!!) Tranquilo hombre... no te desesperes, te voy a contar otras formas de localizar objetos en la escena de juego mucho  mejores y mas optimas de usar la mierda del `find`, para que tu juego no se vea afectado por la maldición de FPS (**Faraón Posiblemente Solterón...** No significa eso, pero a mi me gusta mas).
  
  Vamos a ver, de mas peor a mas mejor la manera de localizar objetos (OK Joven Lucke??):
  
  - Forma 1: La mas chunga y que te peta el rendimiento.
    
    ```c#
    
    [SerializeField]
    GameObject objetoBuscado;
    
    objetoBuscado = GameObject.Find("MainCamera");
    ```

  - Forma 2: Esta tambien es chunga, pero no tan chunga como la primera.
  
    ```c#
    
    [SerializeField] Camera cam;
    
    cam = FindObjectOfType<Camera>();
    //Aquí va a buscar un objeto de tipo Cámara
    //Lo pillas Lucke??
    ```

  - Forma 3: Esta ya va siendo menos chunga, pero no es la mas mejor, tampoco es la mas peor. Es la del medio.

    ```c#
    
    [SerializeField]
    GameObject cam;
    
    cam = GameObject.FindGameObjectWithTag("Cam03");
    ```
  
  Vamos acercándonos a la perfección, pero no del todo. Este forma de buscar un objeto tiene una pega... (UNA PEGA??!!! PERO QUE ME ESTAS CONTANDO... ESTO ES PERFECTO, LA OCTAVA MARAVILLA, ES UN OBRA DE ARTE PARA BUSCAR...!!) Dejame decirte que NO!!.
  
  Piensa un poco. Aquí como ves en la instrucción, estamos buscando la referencia de un objeto, mediante su "TAG"... Bien!!! Si te has dado cuenta de ese detalle, es que eres un portento!!! Maaaaquina!!!. Sigamos...
  
  Que sucedería si tuviéramos varios objetos con el mismo "TAG"?? (Y PORQUE TENDRIA QUE TENER VARIOS OBJETOS CON EL MISMO TAG?? SEGURO QUE TE LO ACABAS DE PREGUNTAR...) bien, yo te doy la respuesta, tu tranquilo PORTENTO... comete un Osito de Haribo para lo que te voy a contar.
  
  Es muy común tener varios objetos con el mismo "TAG" por ejemplo, para identificar tipos de enemigos... cámaras... etc... Entonces, esta forma de localizar objetos por su "TAG", puede ser un marrón, ya que nos devolverá un objeto que coincida con el "TAG" le hemos dicho, pero no   necesariamente tiene que devolvernos el que nosotros queremos, seguramente nos devolverá cualquier otro que no nos sirva...
  
  - Forma 4: Aquí ya lo bordamos, con este nos hacen capitán de fragata.

    ```c#
    
    [SerializeField] GameObject[] enemigos;
    
    enemigos = GameObject.FindObjectsWithTag("Enemy");
    //Aunque te parezca igual que el otro, no lo es, fijate que este tiene una 's' antes del With
    ```

  Con esta forma, ya nos importa todo un pedo... Aquí buscamos todos los objetos con un tipo de "TAG" y los vamos a cargar en un `array` para después recorrer el array y buscar y operar con el que queramos... AHORA SI!!! 
  
  Te has dado cuenta "Michael" como este si es el suyo... (DE NADA MAJETE, SE QUE ACABO DE CAMBIAR TU VIDA...).
  
  Como hemos visto, hay muchas formas de buscar objetos dentro de nuestra escena, ya en tu mano está usar una forma u otra. Lo mas importante siempre, es que prestes atención a usar la que menos estropicio te haga al rendimiento de tu juego, ya que como te he comentado, no es lo mismo   buscar un objeto entre 10 objetos que haya en la escena (ESO ES POCA COSA...) que ponerse a buscar en una escena donde puedes tener 2000 objetos... ya la cosa cambia.
  
**UPS!!! Que se me olvidaba decirte una cosa MUY IMPORTANTE**

| **MUY IMPORTANTE** |
|:---|
| **NO METAS NUNCA UN MÉTODO FIND DENTRO DEL "UPDATE". SI LO HACES, YA ENTONCES SI QUE VAS A TIRAR EL RENDIMIENTO A LA CLOACA!!!** |

Advertido quedas... Luego no me cuentes que no te dije nada.
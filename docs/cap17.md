# Capítulo 5: Conceptos de Programación Avanzada
## 5.1 - Clases Estáticas
En este punto vamos a ver ciertos aspectos avanzados de la programación en C#, e iremos profundizando poco a poco para ver como podemos ampliar y mejorar nuestros códigos.

Tranquilos, que esto es facil.

### 5.1.1 - Definición de Clase Estática
---
Una clase estática es aquella en la que sus variables y métodos, que indiquemos como estáticos, compartirán los datos que almacenen en todas las instancias de esa clase. 

### 5.1.2 - Una visión mas sencilla de Clase Estática
 ---
 Sé que la chapa que te he soltado antes te ha dejado igual, así que voy a explicarlo mejor, fuera de su definición _"oficial"_.

 Pensemos en lo siguiente. Cuando instanciamos un objeto de una clase, este tendrá sus valores de variables y métodos según lo modifiquemos en su instancia, y si instanciamos otro objeto, este último, tendrá otros valores... Hasta aquí todo correcto. Pero, si una variable de la clase es marcada como __static__, todas las instancias que creemos de esa clase, cuando modifiquemos la variable _estatica_, esta tendrá el mismo valor en el resto de instancias, durante toda la ejecución del programa.

 Para que entendamos lo anterior, diremos que los atributos de una clase, no van a representar valores de una instancia, sino que directamente va a representar a la clase.

 Y tu preguntaras, como accedo al atributo o método estático de un objeto de una clase... pues muy simple, simplemente nombrando a la clase en cuestion (__OJO: NO AL OBJETO...__) seguida de punto y el nombre del atributo o el método.

 Ya puesto, estaras preguntando como se declara un atributo o un método como estático... o no?? Bueno, si no te lo preguntas, yo te lo cuento. La manera de declarar un atributo o un método como estático, es básicamente incluyendo la palabra `static`. Te pongo un ejemplito para que lo veas mas claro.

 ```c#
public class Bullet
{
  public static int cuentaBullets = 0; //Atributo estatico
  public Bullet()  //El constructor de la clase
  {
    cuantaBullet++;
  }
}

public class PruebaBullet:MonoBehaviour
{
  void Start()
  {
    //Cada vez que creo un objeto de la clase Bullet, en esta se incrementa
    //la variable cuentaBullet.
    Bullet bullet01 = new Bullet();
    Bullet bullet02 = new Bullet();
    Bullet bullet03 = new Bullet():
  }

  //Aqui asignamos el valor de cuentaBullet a una variable
  //Observar que llamamos a la clase y no a uno de los objetos creado.
  int numeroBullets = Bullet.cuentaBullet;

  Debug.Log(numeroBullets);
}
 ```

 El ejemplo que hemos visto, es para ir creando objetos a partir de la clase, pero por ejemplo, supongamos que voy a crear objetos, arrastrando su `prefab`.

 En ese caso, debemos incluir la clase `Bullet` como componente del _GameObject_ en cuestión y en ese caso, la clase __Bullet__ si deberá heredar de `MonoBehaviour`.

 ```c#
class Bullet : MonoBehaviour
{
  public static int cuentaBullet = 0;

  void Start()
  {
    cuentaBullet++;
    Debug.Lot(cuentaBullet);
  }
}
 ```

 Como hemos dicho, podemos declarar además de variables, métodos estáticos, los cuales serán métodos de la clase propiamente y no de las instancias de esta.

 A continuación vamos a poner un ejemplo de como sería un método estático.

 Vamos a suponer que pertenece a la clase `Bullet` del ejemplo anterior.
 ```c#
 public static void demasiadasBalas()
 {
  if(cuentaBullet > 10)
  {
    Debug.Log("Demasiadas Balas...");
  }
 }
 ```

 Si quisieramos llamar este método desde cualquier otra clase, deberiamos hacerlo de la siguiente manera:

 ```c#
 Bullet.demasiadasBalas();
 ```

 Si por ejemplo ejemplo queremos comprobar si se han disparados demasiadas balas, pondriamos la instrucción anterior dentro del método `Update()`.

 Una cosa muy importante a tener en cuenta, es que no podemos usar métodos "*normales*" o de instancias en los métodos estaticos, ya que generarian un conflicto, ya que los primeros son **valores de la clase** y los últimos son **especificos de cada objeto**.

 Antes de terminar con este punto, voy a haceros una consideración y es que, es posible crear **clases estáticas**. 

 Una **clase estática** es muy útil, si queremos realizar una clase compuesta únicamente por **atributos y métodos estaticos**, cuya finalidad no sea la creación de instancias u objetos.

 Un ejemplo muy típico en Unity de clase estatica es la `clase input` o algunas clases matemáticas como `mathf`.
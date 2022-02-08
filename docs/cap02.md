# Variables y Tipos de Datos

  ## Definición de Variable

  Una variable es un espacio en memoria, que se reserva para almacenar un dato.

Una vez tenemos claro que es una variable, vamos a explicar como se declaran y sus tipos de datos.

Una variable consta de:
- **Identificador** : Es el nombre que le vamos a dar a la variable. Este nombre debe ser descriptivo para saber que es lo que va a guardar nuestra variable.
- **Tipo de Dato** : Determina el tipo de dato que guardará la variable. Los tipos de datos mas comunes son:
  | Tipo | Descripción |
  | :--- | :--- |
  | **int** | Números enteros |
  | **long** | Números enteros largos (64bits) |
  | **double** | Número decimal de precisión doble |
  | **float** | Número decimal de precisión simple |
  | **bool** | Booleano (verdadero ó falso) |
  | **string** | Cadena de caracteres |
  
Para poder usar una variable en nuestro script, primero debemos declararla del siguiente modo:
```
TipoVariable IdentificadorNombre;
```

Viendo un ejemplo, seria algo así:
``` c#
int edadJugador;
```

Otra cosa que podemos hacer, es inicializar una variable en el momento de su declaración, lo cual seria:
```
Tipo Identificador = Valor;
```
Ejemplo:
``` c#
int edadPlayer = 18;
```

  ### Tips importantes sobre las Variables

Como hemos visto, según indiquemos, una variable puedes ser pública o privada, pudiendo ser vista por el inspector de **Unity** o no. Pero a lo mejor, queremos que una variable no sea accesible por otras clases, pero si desde el editor de **Unity**, para ello, indicaremos la propiedad `[SerializeField]` en la declaración de la variable. De este modo, permitimos que una variable sea privada, pero si accesible desde el editor de Unity. 

A continuación un ejemplo:

``` c#
[SerializeField]
private int playerLife; //Esta variable es privada, pero accesible desde el editor de Unity
```

Como normal general para una buena práctica, lo correcto es poner las variables de clase como privadas, y usar `[SerializeField]` para poderlas mostrar y utilizar desde el editor.

## Operadores en C#
Tenemos varios tipos de operadores que nos permiten realizar operaciones, los mas comunes son:

**Operadores Numéricos**

| Operador | Operación |
|:---  | :--- |
| + | Operador Suma o Concatenar |
| - | Operador resta |
| * | Operador multiplicación |
| / | Operador división |
| % | Operador módulo (resto división entera|

**Operadores Lógicos**
| Operador | Operación |
|:--- | :---|
|&& | Operador AND |
| II | Operador OR |
| ! | Operador NOT (Negación) |
| == | Comparación de Igualdad |
| != | Distinto |
| < | Menor que |
| > | Mayor que |
| <= | Menor ó igual que |
| >= | Mayor ó igual que |

Una cosa muy importante que debemos tener en cuenta es la visibilidad de las variables, la cual puede ser:
- **Public**: Pública, la cual puede ser vista desde fuera de la clase y desde el inspector de Unity.
- **Private**: Privada, la cual no es visible desde fuera de la clase ni en el inspector de Unity.

Para declarar una variable como *publica* o *privada*, debemos hacerlo del siguiente modo:
```
public/private TipoDato Identificador;
```

Veamos un ejemplo de ambos:
```c#
public int edad; //Esta variable sería pública
private float vida; //Esta variable sería privada
```

**NOTA**

**Es importante indicar, que si no se especifica el modificador de acceso de una variable, C# toma por defecto este como private.**

Otro dato importante que debemos saber, es que C# por defecto inicializa las variables por defecto según el tipo de dato:

| Tipo de Dato | Valor Inicializado |
| :--- | :--- |
| int | 0 |
| bool | false |
| float | 0.0 |
| string | null |
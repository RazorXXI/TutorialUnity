# Funciones

Como hemos ido viendo, los `scripts` son componentes que nosotros creamos, para darle comportamientos y funcionalidades a los **GameObjects** de nuestro juego o aplicación.

En este capítulo vamos a aprender a crear nuestras propias funciones ó también llamados mas correctamente **métodos**.

## Declaración y uso de funciones

En C# podemos crear nuestras propias funciones, es eso mismo lo que va a ampliar la funcionalidad de lo que queramos hacer en nuestros juegos gracias a nuestros *scripts*.

La forma de declarar una función en C# es del siguiente modo:

```
ValorDevuelto NombreFuncion(<parámetros>)
{
  //Aquí vendría el código de nuestra función.
}
```

Vemos en el esquema de arriba, que indicamos un valor de devolución como "*ValorDevuelto*", pero, una función puede devolver un valor o directamente no devolver nada, en cuyo caso el valor de devolución se conoce como `void`.

A continuación un ejemplo de una función real que no devuelve nada.

```c#
void funcionSaludame()
{
  Debug.Log("Hola Muchacho, bienvenido a Unity");
}
```

En la función anterior, vemos que el valor que devuelve la función es `void` lo cual indica que no devuelve nada. En este ejemplo, simplemente se mostraría un mensaje en la consola de Unity tal y como se indica en nuestra función.

Si queremos que una función devuelva un valor, para ello debe tener en algún punto de su código una llamada a `return`, el cual indica que devolverá lo que esté a la derecha de el. Vamos a ver un ejemplo.

```c#
int SumarDosNumeros(int num1, int num2)
{
  int sumatorio;
  sumatorio = num1 + num2;

  return sumatorio;
}
```

En el ejemplo, vemos que le pasamos dos números como parámetros a nuestra función, la cual sumará ambos y lo devolverá mediante la variable `sumatorio` y la llamada del `return`.

Creo que hasta aquí de momento claro el concepto de función, tranquilo que esto se puede complicar tanto como quieras, de momento estamos empezando con lo facilito.
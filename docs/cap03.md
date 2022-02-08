# Mostrar Información por Consola

Este capítulo es mas bien corto, pues tampoco hay mucho que decir al respecto.

La consola de `Unity` nos va a resultar de gran utilidad para poder depurar nuestros `Scripts`, dado que vamos a poder lanzar mensajes para ver si se va ejecutando correctamente nuestro `script`.

La instrucción que nos va a servir para poder mostrar información por la consola es:

```
Debug.Log(<Variable o Valor>);
```

A continuación un ejemplo para entenderlo mejor:

```c#
string playerName = "Michael";
Debug.Log(playerName); //Esto nos mostrará el nombre del Jugador por consola
```
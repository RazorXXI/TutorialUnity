# Capítulo 6 - Scriptable Object
Aquí empezamos con la chicha guapa.

Un `scriptable object` es un tipo de objeto que podemos usar para darle propiedades a otros objetos, pudiendo crear un tipo de `asset especial`, que se puede asignar a otros assets.

Se que suena un poco lioso ahora mismo, pero en breve lo entenderas mejor.

Vamos a ver como se define.

```c#
using UnityEngine;

[CreateAssetMenu] //Esto nos creara un nuevo Asset en nuestro menu
public class ScriptableObjectCharacter: ScriptableObject
{
    public int health; //Salud del personaje
    public string typeOfCharacter;
    public bool canDoMagic;
    public Material characterMaterial;
}
```

Aquí hemos definido el `Scriptable Object` que vamos a aplicar a otros objetos.

Por ejemplo.

```c#
using UnityEngine;

public class OrcWarriorCharacter: Monobehaviour
{
    public ScriptableObjectCharacter orcScriptableObject;
    [SerilizeField] string orcName;

    void Awake()
    {
        orcScriptableObject.typeOfCharacter = orcName;
        GetComponent<MeshRenderer>().material = orcScriptableObject.characterMaterial;
    }
    .
    .
    .
}
```

Si definimos varios scriptable objects por ejemplo, tipo orco, mago, guerrero u otro tipo, vamos a poder ir dando al asset `ScriptableObjectCharacter` diferentes valores, los cuales van a ser aplicados al objeto que lo vaya a usar.

Queda mas o menos claro la gran utilidad que nos da el uso de `scriptable objects`?. La potencia o mejor dicho la flexibilidad es poder desacoplar código y aplicar propiedades o comportamientos a diferentes objetos que vayamos creando en nuestro juego.

> ### 💡 Sugerencia
> El uso de los scriptable objects es practico para cuando tenemos muchos Game Objects con una serie de atributos o comportamientos comunes.
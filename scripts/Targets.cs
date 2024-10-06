using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// Class Targets
/// 
/// <remarks>
/// Clase para rellenar un objeto tipo target mediante color al momento que este es seleccionado
/// </remarks>
/// 
/// </summary>
public class Targets : MonoBehaviour
{
    //Translation playerTranslation;
    Transform player;

    [SerializeField] Image fill;
    float t = 0;
    [SerializeField] float chargeTime = 1.5f;

    bool charging, selected, onPosition;

    private void Start()
    {
        //playerTranslation = FindObjectOfType<Translation>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DOTween.Init(false, true, LogBehaviour.Default);

        if (Vector3.Distance(transform.position, player.position) < 0.1f)
        {
            Selected(true);
            onPosition = true;
        }
    }

    void FixedUpdate()
    {
        if (!selected)                                                                          //Si el target no esta seleccionado
        {
            if (charging)                                                                       //Si el target esta disponible para que cargue la imagen
            {
                if (t < 1)                                                                      //Si no ha llegado al tiempo final de carga
                {
                    t += Time.fixedDeltaTime / chargeTime;                                      //Contador t para que vaya rellenando la forma en funcion del tiempo
                    fill.fillAmount = t;                                                        //Cantidad de relleno
                }
                else                                                                            //Ha llegado al final de la carga
                {
                    Selected(true);                                                             //Esta seleccionado
                    player.DOMove(transform.position, 2f).OnComplete(() => onPosition = true);  //Desplazo al player una vez ha cargado el target
                }
            }
            else
            {
                if (t > 0)
                {
                    t -= Time.fixedDeltaTime / 0.75f;
                    fill.fillAmount = t;
                }
            }
        }
        else if (onPosition)
        {
            if (Vector3.Distance(transform.position, player.position) > 0.5f)
            {
                selected = false;
                onPosition = false;
            }
        }
    }

    public void Charge()
    {
        charging = true;
    }

    public void Discharge()
    {
        charging = false;
    }

    public void Selected(bool state)
    {
        selected = state;

        if (state)
        {
            t = 1;
            fill.fillAmount = t;
        }
        else onPosition = false;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Contador de Cuenta atras avanzado - Aqui podemos programar el conteo de hasta minutos
public class CountDownTimer : MonoBehaviour
{
    [SerializeField] int minutes;           //Para indicar los minutos de la cuenta atrás
    [SerializeField] float seconds;         //Para indicar los segundos de la cuenta atrás
    [SerializeField] bool countDownFinish;  //Para la condición de finalización del contador
    [SerializeField] Text counterText;      //Para la referencia del canvas

    // Update is called once per frame
    void Update()
    {
        CountDownExecuter();    //Ejecuta la cuenta atrás
        CountDownUpdateText();  //Muestra la cuenta atrás en el canvas
    }

    void CountDownExecuter()
    {
        int sec;    //Variable para poder controlar el conteo de segundos

        if (!countDownFinish)   //Comprobamos que no haya finalizado el contador
        {
            seconds -= Time.deltaTime; //Vamos descontando segundos
            sec = (int)seconds; //Convertimos el valor devuelto en segundos a tipo entero para asignarlo a la variable sec

            if (sec == 0) //Hemos llegado a 0 segundos 
            {
                if (minutes == 0) countDownFinish = true;  //Si hemos llegado a 0 minutos hemos terminado
                else
                {
                    minutes--;      //Descontamos una unidad a los minutos
                    seconds = 60;   //Reiniciamos los segundos
                }
            }

        }
    }

    void CountDownUpdateText()
    {
        int sec;
        sec = (int)seconds;
        if (sec<10) counterText.text = minutes.ToString() + ":0" + sec.ToString(); //Esta linea es para que no se vea feo al bajar de 0
        else counterText.text = minutes.ToString() + ":" + sec.ToString();
    }
}
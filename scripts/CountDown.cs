using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Contador de cuenta atras simple - Solo cuenta segundos.
public class CountDown : MonoBehaviour
{
    [SerializeField] float countDownTime; //Para el tiempo que va a realizar la cuenta atrás
    [SerializeField] bool countDownFinished; //Para indicar que a terminado la cuenta atrás
    [SerializeField] Text countDownText; //Para referenciar el texto del canvas

    void Update()
    {
        CountDownExecuter(); //Función que va a realizar la cuenta atrás
    }

    void CountDownExecuter() 
    {
        int valueTime;
        if (!countDownFinished) //Condición para controlar que aun no a terminado la cuenta atrás
        {
            countDownTime -= Time.deltaTime;
            valueTime = (int)countDownTime;
            countDownText.text = valueTime.ToString();//Actualizamos el valor text del componente CountDownTex con valueTime
            //valueTime llama a su método ToString, para convertirlo, dado que valueTime es de tipo int y countDownText de tipo string

            if (valueTime == 0) countDownFinished = true;
        }
    }
}
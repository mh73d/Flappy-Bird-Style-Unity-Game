 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText ;
    [SerializeField] float elapsedTime;
     public LogicScript logic ;



    void Update(){

        if(elapsedTime >0){
            elapsedTime -= Time.deltaTime;// make the time decrese

        }
        else if(elapsedTime<0){
            elapsedTime=0;
            timerText.color = Color.red;
            logic.winGame();
            Time.timeScale = 0;
        }

        
        int minutes = Mathf.FloorToInt(elapsedTime/60);
        int secondes = Mathf.FloorToInt(elapsedTime%60);



        timerText.text = string.Format("{0:00}:{1:00}", minutes , secondes);
    }


    
}

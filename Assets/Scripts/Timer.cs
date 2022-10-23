using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeLeft;
    private GameManager gameManagerScript;
    
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(!gameManagerScript.isGameOver){
            if(timeLeft > 0){
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }else{
                Debug.Log("Timeup!");
                timeLeft = 0;
                gameManagerScript.isGameOver = true;
            }

        }
    }

    private void updateTimer(float currentTime){
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes,seconds);

    }

    public void setTimerOn(float time){
        gameManagerScript.isGameOver = false;
        timeLeft = time;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    //Этот код отвечает за логику игры 
    public Text _timer, end1, end2, end3, end4;
    public Slider _slider;
    public GameObject _player;
    public float timeLeft = 20f, timeThatWasAdded=0, allTime=0;
    public int kills = 0, missedKills=0, missedKillsThatWasCounted=0;
    void Start()
    {
        _timer.text = timeLeft.ToString();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        allTime += Time.deltaTime;
        //Лишает времени игрока, если он пропустил противника
        timeLeft = timeLeft - (missedKills - missedKillsThatWasCounted) * 3;
        missedKillsThatWasCounted = missedKills;
        _timer.text = Mathf.Round(timeLeft).ToString();
        
        
        //Если игрок убил более 10 противников ему причисляются доп. очки и время
        if (kills - timeThatWasAdded > 9)
        {
            timeThatWasAdded += 10;
            if ((timeLeft+8)<30)
            {
                timeLeft += 8;
            }
            else
            {
                timeLeft = 30;
            }
        }
        _slider.value = kills - timeThatWasAdded;



        //Конец игры по окончанию времени
        if (timeLeft < 0.2f)
        {
            Time.timeScale = 0;
            timeLeft = 0;
            end1.text = "Конец игры";
            end2.text = "Время игры: " + Mathf.Round(allTime);
            if (timeThatWasAdded / 10 * 5 - missedKillsThatWasCounted * 3 + kills > 0)
            {
                end3.text = "Счет: " + (timeThatWasAdded / 10 * 5 - missedKillsThatWasCounted * 3 + kills);
            }
            else
            {
                end3.text = "Счет: 0";
            }
            end4.text = "Чтобы начать сначала, нажмите левую кнопку мыши!";
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    //Отвечает за управлением играком/мышью
    public GameObject _game;
    private float distance = 1f, timeLeft = 0.3f;
    private int countKills = 0;
    private void MovingToMouse()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        transform.position = objPosition; // и собственно объекту записываються координаты
    }

    //При прикосновении с объектом уничтожает его, засчитывает уничтожение и передает кол-во уничтожении в осн. код.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        countKills++;
        _game.GetComponent<Game>().kills = countKills;
        
    }

    
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        //Небольшая задержка перед атакой
        //Хотел сымитировать замах кулаком
        if (Input.GetMouseButtonDown(0) && timeLeft < 0)
        {
            MovingToMouse();
            timeLeft = 0.7f;
        }
        if (timeLeft < 0.25f)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }
        if (timeLeft < 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            MovingToMouse();
        }
        GetComponent<Animation>().enabled = false;
    }
    
}

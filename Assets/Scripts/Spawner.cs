using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Код по спавну противников
    public GameObject _game, _enemy = null;
    public float timeLeft = 2f, stage2TimeLeft = 20f, stage3TimeLeft = 40f;
    private void Start()
    {
        timeLeft = Random.Range(1f, 2f);
    }
    //Если противник прошел все поле живым, то передает в осн. код информацию о пропуске
    //и разворачивает врага 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        _game.GetComponent<Game>().missedKills++;
        CreateNewEnemy();
    }
    //Клонирует префаб противника
    public void CreateNewEnemy()
    {
        Instantiate(_enemy, new Vector3(transform.position.x * 0.9f, transform.position.y + Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);        
    }

    //Чем дольше игра, тем больше противников
    private void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        stage2TimeLeft -= Time.deltaTime;
        stage3TimeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = Random.Range(1.5f, 3f);
            CreateNewEnemy();
        }
        if (stage2TimeLeft<0)
        {
            stage2TimeLeft= Random.Range(5f, 8f);
            CreateNewEnemy();
        }
        if (stage3TimeLeft < 0)
        {
            stage3TimeLeft = Random.Range(4f, 7f);
            CreateNewEnemy();
        }
    }
}

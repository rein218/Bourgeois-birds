using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Поведение противников
    private int speed, side = 1;
    private float angleA = -1f, angleB = 1f, downRange = -0.015f, upRange = 0.015f;
    private bool movingToRight = true;

    //Разварачивает текстурку птицы если она идет справа на лево
    void Spin()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }
    
    private void Start()
    {
        //Радает случайную скорость
        speed = Random.Range(19, 13);
        //Определяет в какую сторону притце надо двигаться
        if (transform.position.x > 0)
        {
            speed *= -1;
            movingToRight = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        
    }

    //Движение противника
    //Я рассчитывал сделать их более не предсказуемыми, что впринциве у меня и вышло
    private void FixedUpdate()
    {
        //постоянное подергивание и верчение 
        transform.position += transform.right / speed;
        transform.Rotate(0, 0, Random.Range(angleA, angleB));
        transform.position += transform.up * Random.Range(upRange, downRange);

        //Эта часть кода не дает противнику улететь за границы или крутиться на месте
        if (transform.rotation.z > 12)
        {
            angleA = -1.7f;
            angleB = -0.5f;
            transform.Rotate(0, 0, 9);
        }
        else if (transform.rotation.z < -12)
        {
            angleA = 0.5f;
            angleB = 1.7f;
            transform.Rotate(0, 0, -9);
        }
        else
        {
            angleA = -1f;
            angleB = 1f;
        }

        if (transform.position.y > 4)
        {
            upRange = -0.006f;        }
        else if (transform.position.y < -4)
        {
            downRange = 0.006f;
        }
        else
        {
            upRange = 0.015f; 
            downRange = -0.015f;
        }
    }

}
    


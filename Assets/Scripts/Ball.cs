using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 1f;
    private int score = 1;
    private int damage = 1;
    public Color mainColor { get; private set; }

    private float limitY;


    private void Update()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);

        if(transform.position.y <= limitY)
        {
            ScoreManager.Instance.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void UpScore()
    {
        ScoreManager.Instance.UpScore(score);
    }

    public void SetValues(float speed, int score, int damage, Color mainColor, float limitY)
    {
        this.speed = speed;
        this.score = score;
        this.damage = damage;
        this.mainColor = mainColor;
        this.limitY = limitY;

        GetComponent<SpriteRenderer>().color = mainColor;
    }
}





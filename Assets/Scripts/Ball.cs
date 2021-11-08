using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1f;
    public int score = 1;
    public int damage = 1;
    public Color mainColor = Color.white;

    public float limitY;

    private void Awake()
    {
        mainColor = Random.ColorHSV();
        GetComponent<SpriteRenderer>().color = mainColor;


    }

    private void Update()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);

        if(transform.position.y <= limitY)
        {
            Score.Instance.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void UpScore()
    {
        Score.Instance.UpScore(score);
    }



}

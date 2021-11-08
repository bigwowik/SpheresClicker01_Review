using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallClicker : MonoBehaviour, IPointerDownHandler
{
    public GameObject destroyEffect;

    private Ball ball;

    void Awake()
    {
        ball = GetComponent<Ball>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(name + " Game Object Clicked!");
        var newDestroyEffect = Instantiate(destroyEffect, transform.position, transform.rotation);
        newDestroyEffect.GetComponent<ParticleSystemRenderer>().material.color = ball.mainColor;
        ball.UpScore();

        //Destroy(newDestroyEffect, 3f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    public float upDistance = 1f;
    public float downDistance = 1f;
    public float widthRange = 0.9f;

    public Ball ballPrefab;

    private List<Ball> spawnedBalls = new List<Ball>();


    Vector3 upCenter;
    float width;

    float limitY;


    private void Start()
    {
        var camera = Camera.main;
        var upLeftBorder = camera.ScreenToWorldPoint(new Vector3(0f, camera.scaledPixelHeight, 0f));
        var upRightBorder = camera.ScreenToWorldPoint(new Vector3(camera.scaledPixelWidth, camera.scaledPixelHeight, 0f));

        width = Vector3.Distance(upLeftBorder, upRightBorder);

        upCenter = upLeftBorder + (Vector3.right * (width / 2));
        upCenter.z = 0;



        var downLeftBorder = camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        limitY = downLeftBorder.y - downDistance;

        var downRightBorder = camera.ScreenToWorldPoint(new Vector3(camera.scaledPixelWidth, 0f, 0f));


        InvokeRepeating("SpawnOneBall", 0, 1f);
        
    }

    

    void SpawnOneBall()
    {
        var newPos = upCenter + Vector3.right * Random.Range((-width/2) * widthRange, (width/2) * widthRange) + Vector3.up * upDistance;
        var newBall = Instantiate(ballPrefab, newPos, Quaternion.identity);
        newBall.limitY = limitY;
        spawnedBalls.Add(newBall);
        Debug.Log("Ball was spawned at:" + newPos);
    }
}

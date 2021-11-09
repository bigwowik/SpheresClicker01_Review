using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [Header("Border to spawn balls upper the screen")]
    public float upDistance = 1f;
    [Header("Border to destroy ball under the screen")]
    public float downDistance = 1f;
    [Header("Width of screen multiplier to spawn balls in screen Range")]
    public float widthRange = 0.9f;
    [Header("Ball Prefab")]
    public Ball ballPrefab;

    
    [Header("StartValues")]
    public float startSpeed = 1f;
    public float speedAcceleration = 0.05f;
    
    [Header("Spawn Rate. One ball try to spawn in this time.")]
    public float spawnRateTime = 0.1f;
    [Header("Chance to spawn one ball in spawnRateTime. "), Range(0,1)]
    public float spawnRate = 0.2f;


    [Header("Speed Randomness"), Range(0,1)]
    public float speedRangeMin = 0.9f;
    [Range(1f,2f)]
    public float speedRangeMax = 1.1f;
    [Header("Score Values. Min = 1"), Range(1, 30)]
    public int ScoreMax = 1;
    [Header("Damage Values. Min = 1"), Range(1, 30)]
    public int DamageMax = 1;

    //privates
    private float worldSpeed;
    private float width;
    private float limitY;  //down lmit to destroy balls
    private Vector3 upCenter;

    private List<Ball> spawnedBalls = new List<Ball>();


    private void Start()
    {
        //game borders
        var camera = Camera.main;
        var upLeftBorder = camera.ScreenToWorldPoint(new Vector3(0f, camera.scaledPixelHeight, 0f));
        var upRightBorder = camera.ScreenToWorldPoint(new Vector3(camera.scaledPixelWidth, camera.scaledPixelHeight, 0f));

        width = Vector3.Distance(upLeftBorder, upRightBorder);

        upCenter = upLeftBorder + (Vector3.right * (width / 2));
        upCenter.z = 0;

        var downLeftBorder = camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));

        limitY = downLeftBorder.y - downDistance; 

        worldSpeed = startSpeed;

        InvokeRepeating("SpawnOneBall", 0, 0.1f);
    }

    private void Update()
    {
        worldSpeed += Time.deltaTime * speedAcceleration;
    }

    void SpawnOneBall()
    {
        if (Random.Range(0, 1f) > spawnRate) //for better randomness
            return;

        var newPos = upCenter + Vector3.right * Random.Range((-width/2) * widthRange, (width/2) * widthRange) + Vector3.up * upDistance;
        var newBall = Instantiate(ballPrefab, newPos, Quaternion.identity);

        RandomGenerator(newBall);

        spawnedBalls.Add(newBall);
        //Debug.Log("Ball was spawned at:" + newPos);
    }

    void RandomGenerator(Ball ball)
    {
        var newSpeed = worldSpeed * Random.Range(speedRangeMin, speedRangeMax);
        var newScore = Random.Range(1, ScoreMax + 1);
        var newDamage = Random.Range(1, DamageMax + 1);
        var newColor = Random.ColorHSV();

        ball.SetValues(newSpeed, newScore, newDamage, newColor, limitY);
    }


}

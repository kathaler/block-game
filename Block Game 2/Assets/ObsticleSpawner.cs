using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{

    Vector2 screenHalfSize;

    public GameObject obsticle;

    float nextSpawnTime;
    public Vector2 secondsBetweenSpawnTimeMinMax;

    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawnTime = Mathf.Lerp(secondsBetweenSpawnTimeMinMax.y, secondsBetweenSpawnTimeMinMax.x, Difficulty.GetDifficultyPercent());

            Vector2 position = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + obsticle.transform.localScale.y);
            float scaleSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float scaleAngle = Random.Range(spawnAngleMax, -spawnAngleMax);

            nextSpawnTime = Time.time + secondsBetweenSpawnTime;
            GameObject newObsticle = (GameObject)Instantiate(obsticle, position, Quaternion.Euler(Vector3.forward * scaleAngle));

            newObsticle.transform.localScale = Vector2.one * scaleSize;
        }
        
    }
}

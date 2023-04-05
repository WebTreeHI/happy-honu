using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    public float spawnRate = 3;
    public float Xpos = 0;
    private float timer = 0;
    public float heightOffset = 5;

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) 
          {
            timer += Time.deltaTime;
          }
        else
          {
            spawnObstacle();
            timer = 0;
          }     
    }

    void spawnObstacle()
    {
      float lowestPoint = transform.position.y - heightOffset;
      float highestPoint = transform.position.y + heightOffset;
      
      Instantiate(ObstaclePrefab, new Vector3(transform.position.x + Xpos, Random.Range(lowestPoint,highestPoint),0), transform.rotation);
    }
}

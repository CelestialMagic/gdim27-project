using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_SpawnObstacles : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstacles;
    
    public float maxX,
                 maxY,
                 minX,
                 minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacles[(Random.Range(0, obstacles.Count))], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }

}

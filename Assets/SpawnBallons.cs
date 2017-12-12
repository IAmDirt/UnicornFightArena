using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallons : MonoBehaviour
{
    float SpawnPositionX;

    public GameObject Rompetroll;
    public Vector2 SpawnDirection;

    public float spawnRate;
    float nextSpawn;

    void start()
    {

    }

    void Update()
    {

        SpawnPositionX = Random.Range(-6f, 6f);
        SpawnDirection = new Vector2(SpawnPositionX, 1);

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            GameObject Spawn = Instantiate(Rompetroll);
            Vector2 MyPosition = transform.position;
            Spawn.transform.position = MyPosition + SpawnDirection;
        }
    }
}
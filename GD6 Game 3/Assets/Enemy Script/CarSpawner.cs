using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public float SpawnDelay = .3f;

    float NextTimeToSpawn = 0f;

    public GameObject car;

    public Transform[] SpawnPoints;
  
    void Update()
    {

        if (NextTimeToSpawn >= Time.time)
        {
            SpawnCar();
            NextTimeToSpawn = Time.time + SpawnDelay;
        }




    }


    void SpawnCar()
    {

        int RandomIndex = Random.Range (0, SpawnPoints.Length);
        Transform SpawnPoint = SpawnPoints[RandomIndex];


        Instantiate(car, SpawnPoint.position, SpawnPoint.rotation);









    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaptorSpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float repeatRate = 500;
    private float repeatRateMax = 500;
    private float startDelay = 2;
    //private PlayerController playerControllerScript;
    private float spawnOnX;
    private float spawnOnZ;
    private float spawnTime;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private Vector3 spawnPos = new Vector3(0, 0, 100);
    private Vector3 spawnRot = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime >= repeatRate && gameManagerScript.isGameStarted)
        {
            SpawnRaptor();
            spawnTime = 0;

            // reduce the repeatRateMax
            if (repeatRateMax >= 100)
            {
                repeatRateMax -= Random.Range(0, 5);
            }

            //randomize the next spawn
            repeatRate = Random.Range(10, repeatRateMax);
        }
        else
        {
            spawnTime += 1;
        }
    }

    void SpawnRaptor()
    {
        // Instantiate an object if the player hasn't got a Game Over
        //if (playerControllerScript.gameOver == false)
        //{
        //    Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        //}

        // Spawn on the left or on the right?
        int leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {
            spawnOnZ = 20;
            spawnRot = new Vector3(0, 180, 0);
        }
        else 
        {
            spawnOnZ = 100;
            spawnRot = new Vector3(0, 0, 0);
        }
        spawnOnX = Random.Range(-10, 10);

        spawnPos = new Vector3(spawnOnX, 0, spawnOnZ);

        Instantiate(obstaclePrefab, spawnPos, Quaternion.Euler(spawnRot));
        

        
    }
}

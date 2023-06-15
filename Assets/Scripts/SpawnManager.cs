using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private float repeatRate = 5;
    private float startDelay = 2;
    //private PlayerController playerControllerScript;
    private Vector3 spawnPos = new Vector3(0, 0, 100);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        //playerControllerScript = playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        // Instantiate an object if the player hasn't got a Game Over
        //if (playerControllerScript.gameOver == false)
        //{
        //    Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        //}

        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}

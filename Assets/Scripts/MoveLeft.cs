using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    //private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Stop movement if the player has Game Over
        //if (playerControllerScript.gameOver == false)
        //{
        //    transform.Translate(Vector3.left * Time.deltaTime * speed);
        //}

        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}

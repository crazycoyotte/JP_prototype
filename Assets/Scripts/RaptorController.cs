using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RaptorController : MonoBehaviour
{
    public GameObject vehicle;
    public AudioSource carHit;
    public bool getHit = false;

    private bool hitable = true;
    private GameObject player;
    private int speed = 6;
    private Vector3 raptorOrientation;
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRotation();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyRaptor();
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the raptor touch the vehicle
        if (other.tag == "Vehicle")
        {
            transform.Rotate(0, 180, 0);
            carHit.Play();
            getHit = true;
            hitable = false;
            playerScript.life -= 1;
            Debug.Log("Live : " + playerScript.life);
        }
    }

    // Destroy the raptor
    public void DestroyRaptor()
    {
        if (transform.position.z <= 20 || transform.position.z >= 100)
        {
            Destroy(gameObject);
        }
    }

    // move the raptor to the vehicle
    private void Move()
    {
        if (transform.position.z > vehicle.transform.position.z)
        {
            if (getHit)
            {
                speed = 12;
                if (hitable)
                {
                    transform.Rotate(0, 180, 0);
                    hitable = false;
                }
            }
            else
            {
                speed = 25;
            }

        }
        else
        {
            if (getHit)
            {
                speed = 25;
                if (hitable)
                {
                    transform.Rotate(0, 180, 0);
                    hitable = false;
                }
            }
            else
            {
                speed = 12;
            }
        }
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        

    }

    // turn the rotation to the vehicle
    private void SpawnRotation()
    {
        double deltaOnX = transform.position.x - vehicle.transform.position.x;
        double deltaOnZ = transform.position.z - vehicle.transform.position.z;

        double tangente = Mathf.Atan((float)deltaOnZ / (float)deltaOnX);
        double angleDegres = tangente * (180.0 / Mathf.PI);


        if (transform.position.z < vehicle.transform.position.z)
        {
            if (transform.position.x < vehicle.transform.position.x)
            {
                transform.Rotate(0, 90 - (float)angleDegres, 0);
            }
            else
            {
                transform.Rotate(0, 270 - (float)angleDegres, 0);
            }

        }
        else
        {
            if (transform.position.x < vehicle.transform.position.x)
            {
                transform.Rotate(0, 270 - (float)angleDegres, 0);
            }
            else
            {
                transform.Rotate(0, 90 - (float)angleDegres, 0);
            }
        }
    }
}

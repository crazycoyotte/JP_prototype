using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float repeatWidth;
    private Vector3 startPos;
    private Vector3 respawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z;
        respawnPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= -40)
        {
            transform.position = respawnPos;
        }
    }
}

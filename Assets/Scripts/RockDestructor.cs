using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestructor : MonoBehaviour
{
    private float leftBound = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy object if it is out of the screen on the left
        if (transform.position.z <= leftBound )
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float speed = 20.0f;

    private float rangeX;
    private float rangeY;
    private GameObject cross;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input for camera rotation
        float horizontalInput = Input.GetAxis("Horizontal");

        // Get the horizontal input for camera rotation
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate the camera around the Y-axis based on the input and rotation speed
        gameObject.transform.Translate(Vector3.right * verticalInput * speed * Time.deltaTime);
        // Rotate the camera around the Z-axis based on the input and rotation speed
        gameObject.transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);


    }
}

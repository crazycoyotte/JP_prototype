using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public AudioClip bodyHit;
    public GameObject smokePrefab;
    
    private AudioSource bulletAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vehicle")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Road")
        {
            Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);
            Instantiate(smokePrefab, position, smokePrefab.transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Raptor")
        {
            RaptorController hitRaptor = other.GetComponent<RaptorController>();
            if (!hitRaptor.getHit)
            { 
                hitRaptor.getHit = true;
                bulletAudio.PlayOneShot(bodyHit, 0.5f);
                other.transform.Rotate(0, 180, 0);
                Debug.Log("touché");
            }
        }
    }
}

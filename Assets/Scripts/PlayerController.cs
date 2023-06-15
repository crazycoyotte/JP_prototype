using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject focalPoint;
    public GameObject bulletPrefab;
    public GameObject cross;
    public AudioClip bodyHit;
    public GameObject smokePrefab;
    public int life;

    private AudioSource bulletAudio;
    private Camera cam;
    private int actualLife = 3;
    private int maxLife = 5;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        bulletAudio = GetComponent<AudioSource>();
        life = actualLife;
        actualLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        /*{
            Vector3 orientation = focalPoint.gameObject.transform.rotation.eulerAngles + transform.rotation.eulerAngles;
            Quaternion bulletRotation = Quaternion.Euler(orientation);
            Instantiate(bulletPrefab, transform.position, focalPoint.gameObject.transform.rotation);

        }*/
        {
            // Calcul des coordonnées de l'écran
            Vector3 crossPosition = cross.transform.position;
            Vector3 screenPosition = cam.WorldToScreenPoint(crossPosition);

            // Creation du raycast
            Ray ray = cam.ScreenPointToRay(screenPosition);

            // Effectuer le raycast
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Objet touché par le rayon
                Debug.Log($"L'objet touché : {hit.collider.gameObject.name}");
            }
            // Dessiner le rayon dans l'éditeur Unity
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

            if (hit.collider.gameObject.name == "Raptor_Animated_LODG_Blue(Clone)")
            {
                RaptorController raptorScript = hit.collider.gameObject.GetComponent<RaptorController>();
                bulletAudio.PlayOneShot(bodyHit, 0.5f);
                if (raptorScript != null)
                {
                    if (raptorScript.hitable == true)
                    {
                        raptorScript.getHit = true;
                        raptorScript.DropLoot(hit);
                        UpdateScore();
                    }
                    
                }
                
            }

            if (hit.collider.gameObject.name == "Road" || hit.collider.gameObject.name == "Grass")
            {
                Vector3 position = new Vector3(transform.position.x, 0, transform.position.z);
                Instantiate(smokePrefab, hit.point, smokePrefab.transform.rotation);
            }

            if (hit.collider.gameObject.name == "LifePointBonus(Clone)")
            {
                if (life < actualLife)
                {
                    life += 1;
                }
                Destroy(hit.collider.gameObject);
            }
        }



    }

    private void UpdateLife()
    {
        Transform lifebarTransform = transform.Find("Lifebar"); // Remplacez "Lifebar" par le nom de votre objet Lifebar

        if (lifebarTransform != null)
        {
            for (int i = 1; i <= 5; i++)
            {
                string lifePointEmptyObject = "LifePointEmpty" + i;
                string lifePointObject = "LifePoint" + i;
                Transform lifePointEmpty = lifebarTransform.Find(lifePointEmptyObject);
                Transform lifePoint = lifebarTransform.Find(lifePointObject);
                if (lifePointEmpty != null)
                {
                    lifePointEmpty.gameObject.SetActive(i <= actualLife);
                }
                if (lifePoint != null)
                {
                    lifePoint.gameObject.SetActive(i <= life);
                }
            }
        }
    }

    private void UpdateScore()
    {
        score += 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject focalPoint;
    public AudioClip bodyHit;
    public GameObject smokePrefab;
    public int life;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    private int score = 0;
    private float rangeX;
    private float rangeY;
    private float speed = 20.0f;
    private GameObject cross;
    private AudioSource bulletAudio;
    private Camera cam;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    private int actualLife = 3;
    private int maxLife = 5;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        bulletAudio = GetComponent<AudioSource>();
        cross = GameObject.Find("Reticule");
        life = actualLife;
        actualLife = maxLife;
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        Debug.Log(gameManagerScript.isGameOver + "Start");
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLifeBar();
        if (life <= 0)
        {
            gameManagerScript.SetGameOver();
        }

        if (!gameManagerScript.isGameOver)
        {
            // Get the horizontal input for camera rotation
            float horizontalInput = Input.GetAxis("Horizontal");

            // Get the horizontal input for camera rotation
            float verticalInput = Input.GetAxis("Vertical");

            // Rotate the camera around the Y-axis based on the input and rotation speed
            cross.transform.Translate(Vector3.right * verticalInput * speed * Time.deltaTime);
            // Rotate the camera around the Z-axis based on the input and rotation speed
            cross.transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
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
                        SetLife(1);
                    }
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        
    }

    private void UpdateLifeBar()
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
        scoreText.text = score.ToString();
        finalScoreText.text = scoreText.text;
    }

    public void SetLife(int lifeMod)
    {
        life += lifeMod;
    }
}

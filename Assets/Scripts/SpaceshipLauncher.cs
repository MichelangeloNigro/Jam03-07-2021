using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLauncher : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController player;
    TileManager tileManager;
    UiManager managerUi;
    public bool canJump;
    public float launchSpeed;
    public bool isMoving;
    bool isLanuched;

    private Camera mainCamera;
    public Vector2 widthThreshold;
    public Vector2 heightThreshold;

    public GameObject deathCanvas;

    public bool isOut;
    CameraMover cameraMover;
    public SO_SFX death;

    public void Awake()
    {
       

     
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        tileManager = FindObjectOfType<TileManager>();
        managerUi = FindObjectOfType<UiManager>();
        mainCamera = Camera.main;
        cameraMover = FindObjectOfType<CameraMover>();
        isOut = false;
        isMoving = false;
        
    }
    private void Update()
    {
        Launch();
        if(isMoving)
        {
            transform.Translate(Vector2.up * launchSpeed * Time.deltaTime);
        }

        if (isOut)
        {
            managerUi.DeathCanvas.enabled = true;
            Time.timeScale = 0;
            isOut = false;
            SFXManager.Instance.playSFX(death);
            dreamloLeaderBoard.Instance.AddScore(PlayerPrefs.GetString("Name"), PlayerPrefs.GetInt("Highscore"));
            //non vuole funzionare
        }

    }
    void Launch()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space)|| (Input.touchCount>0))
            {
                Debug.Log("LAUNCH");
                canJump = false;
                player.canRotate = false;
                isMoving = true;


            }
        }
    }
    void ForceLaunch()
    {
        //rb.velocity = Vector2.up * player.angle;
        Debug.Log("Maybe");
        transform.Translate(Vector2.up * launchSpeed * Time.deltaTime);
        canJump = false;
        player.canRotate = false;
        isMoving = true;
        cameraMover.ChangeLevel();
    }
    public void EnterAtmosphere(Collider2D collision)
    {
        transform.Rotate(0, 0, 180);
        player.planetToRotate = collision.gameObject;
        player.transform.up = (player.transform.position-player.planetToRotate.transform.position).normalized;
        rb.velocity = Vector2.zero;
        canJump = true;
        player.canRotate = true;
        collision.gameObject.GetComponent<PlanetController>().isvisit = true;
        isMoving = false;
    }

    public void EnterFinalPlanet(Collider2D collision)
    {
        isMoving = false;
        player.planetToRotate = collision.gameObject;
        player.transform.up = (player.transform.position - player.planetToRotate.transform.position).normalized;
        rb.velocity = Vector2.zero;
        player.canRotate = true;
        canJump = false;
        collision.gameObject.GetComponent<PlanetController>().isvisit = true;
        
        StartCoroutine(WaitForLaunch());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Planet") && collision.gameObject!=player.planetToRotate)
        {
            if (!collision.gameObject.GetComponent<PlanetController>().isvisit) {
                managerUi.points += 100;
            }
            if (!collision.gameObject.GetComponent<PlanetController>().endingPlanet)
            {
                EnterAtmosphere(collision);
            }
            else
            {
                EnterFinalPlanet(collision);
            }
        }
        if (collision.CompareTag("BlackHole") && collision.gameObject != player.planetToRotate)
        {

            Time.timeScale = 0;
            managerUi.DeathCanvas.enabled = true;
            SFXManager.Instance.playSFX(death);
            dreamloLeaderBoard.Instance.AddScore(PlayerPrefs.GetString("Name"), PlayerPrefs.GetInt("Highscore"));
        }

    }


    private IEnumerator WaitForLaunch()
    {
        
        var x = Mathf.Deg2Rad * this.gameObject.transform.eulerAngles.z;      
        var cos = (Mathf.Sin(x));

        while ( (1-Mathf.Abs(cos)>0.001f) || cos>0 )
        {
            x = Mathf.Deg2Rad * this.gameObject.transform.eulerAngles.z;
            if (x > 360) {
                x = 0;
            }
            cos = (Mathf.Sin(x));
            
            
           
            yield return null;
        }
        ForceLaunch();
    }

    /*public void OutOfScreenSpace()
    {
       Vector2 screenPosition = mainCamera.ScreenToWorldPoint(transform.position);
        if (screenPosition.x < -((mainCamera.aspect * mainCamera.orthographicSize)) || screenPosition.x > (mainCamera.aspect * mainCamera.orthographicSize) || screenPosition.y < -(mainCamera.rect.height) || screenPosition.y > mainCamera.rect.height)
        {
            Debug.Log("uscito");
            isOut = true;
           
        } else
        {
            isOut = false;
        }
    } */

    void OnBecameInvisible()
    {
        isOut = true;
    }
}


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

    private Camera mainCamera;
    public Vector2 widthThreshold;
    public Vector2 heightThreshold;

    public GameObject deathCanvas;

    public bool isOut;
    CameraMover cameraMover;

    public void Awake()
    {
        mainCamera = Camera.main;
        cameraMover = FindObjectOfType<CameraMover>();
        isOut = false;

        Debug.Log(mainCamera.aspect * mainCamera.orthographicSize);
        Debug.Log(mainCamera.rect.height);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
        tileManager = FindObjectOfType<TileManager>();
        managerUi = FindObjectOfType<UiManager>();
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
            //non vuole funzionare
        }

    }
    void Launch()
    {
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
        rb.velocity = Vector2.up * player.angle;
        canJump = false;
        player.canRotate = false;
        isMoving = true;
        cameraMover.ChangeLevel();
    }
    public void EnterAtmosphere(Collider2D collision)
    {
        transform.Rotate(0, 0, 180);
        player.planetToRotate = collision.gameObject;
        rb.velocity = Vector2.zero;
        canJump = true;
        player.canRotate = true;
        collision.gameObject.GetComponent<PlanetController>().isvisit = true;
        isMoving = false;
    }

    public void EnterFinalPlanet(Collider2D collision)
    {
        player.planetToRotate = collision.gameObject;
        tileManager.SpawnTiles();
        rb.velocity = Vector2.zero;
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
        }

    }


    private IEnumerator WaitForLaunch()
    {
        var jumped = false;
        while(!jumped)
        {
          var angle=Vector3.Angle(this.gameObject.transform.eulerAngles, transform.forward);
            Debug.Log(angle);
            if(angle==0)
            {
                jumped = true;
                ForceLaunch();
            }
            yield return null;
        }
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


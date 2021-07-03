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

    }
    public void EnterAtmosphere(Collider2D collision)
    {
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
        canJump = false;
        collision.gameObject.GetComponent<PlanetController>().isvisit = true;
        StartCoroutine(WaitForLaunch());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Atmosphere") && collision.gameObject!=player.planetToRotate)
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
}


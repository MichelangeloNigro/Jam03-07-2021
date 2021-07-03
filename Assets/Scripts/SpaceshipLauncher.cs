using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLauncher : MonoBehaviour
{
    Rigidbody2D rb;
    // reference scriptRotazione
    //TileManager tileManager;
    bool canJump;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //tileManager = FindObjectOfType<TileManager>();
        //prendersi lo script
    }
    private void Update()
    {
        Launch();
    }
    void Launch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up;//* velocità di rotazione;
            //smetti di rotà;
        }
    }
    void ForceLaunch()
    {

            rb.velocity = Vector2.up;//* velocità di rotazione;
            //smetti di rotà;

    }
    public void EnterAtmosphere()
    {
        rb.velocity = Vector2.zero;
        canJump = true;
    }

    public void EnterFinalPlanet()
    {
        //tileManager.SpawnTiles();
        canJump = false;
        StartCoroutine(WaitForLaunch());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Atmosphere"))
        {
            if (!collision.gameObject.GetComponent<PlanetController>().endingPlanet)
            {
                EnterAtmosphere();
                //rota;
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


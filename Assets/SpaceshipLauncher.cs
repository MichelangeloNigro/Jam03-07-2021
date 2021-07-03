using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipLauncher : MonoBehaviour
{
    Rigidbody2D rb;
    // reference scriptRotazione
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    public void EnterAtmosphere()
    {
        rb.velocity = Vector2.zero;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Atmosphere"))
        {
            EnterAtmosphere();
            //rota;
        }
    }
}


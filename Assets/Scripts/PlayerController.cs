using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[HideInInspector] public float timeCounter = 0;
    public CircleCollider2D planetCollider;
    public Vector2 centerPlanet;
    public float offset;

    public void Start()
    {
        centerPlanet = planetCollider.bounds.center;
    }

    public void Update()
    {
        timeCounter += Time.deltaTime;

        float x = Mathf.Cos(timeCounter);
        float y = Mathf.Sin(timeCounter);
        //float z = Mathf.Cos(timeCounter);

        transform.position = centerPlanet + new Vector2 (x*offset, y*offset);
    }
}

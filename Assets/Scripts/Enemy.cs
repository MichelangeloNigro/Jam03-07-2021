using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerController))]

public class Enemy : MonoBehaviour
{
    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<PlayerController>().angle = player.angle;
    }
}

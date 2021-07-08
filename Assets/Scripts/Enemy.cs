using UnityEngine;
[RequireComponent(typeof(PlayerController))]

public class Enemy : MonoBehaviour
{
    private PlayerController player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<PlayerController>().angle = player.GetComponent<PlayerController>().angle;
    }
}

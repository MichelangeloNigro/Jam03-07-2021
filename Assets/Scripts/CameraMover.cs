using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject tileSample;
    Animator animator;
    public TileManager manager;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    public void ChangeLevel()
    {
        StartCoroutine(Slide());
    }
    public IEnumerator Slide()
    {
        var XPos = transform.position.x;
        while (transform.position.x < manager.lastTile.transform.position.x+0.01f)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            yield return null;
        }
        manager.SpawnTiles();
    }
}

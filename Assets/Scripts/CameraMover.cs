using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject tileSample;
    [SerializeField] SpaceshipLauncher player;
    public TileManager manager;
    public void ChangeLevel()
    {
        StartCoroutine(Slide());
    }
    public IEnumerator Slide()
    {
        while (transform.position.x < manager.lastTile.transform.position.x+5f)
        {
            player.canJump = false;
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            yield return null;
        }
        manager.SpawnTiles();
        player.canJump = true;
    }
}

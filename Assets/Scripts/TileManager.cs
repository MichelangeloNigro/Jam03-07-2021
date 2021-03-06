using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]List<GameObject> Tiles;
    public GameObject lastTile;
    [SerializeField]float offestX;
    public Transform parent;
    

    

    public void  SpawnTiles() {
        Vector3 pos = new Vector3(lastTile.transform.position.x + offestX, lastTile.transform.position.y, lastTile.transform.position.z);
        var instance = Instantiate(Tiles[Random.Range(0,Tiles.Count)],pos, Quaternion.identity,parent);
        lastTile = instance;
        
    }


}

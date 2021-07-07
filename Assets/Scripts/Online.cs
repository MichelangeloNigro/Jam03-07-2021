using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Online : MonoBehaviour
{
    public GameObject content;
    public GameObject text;
    public dreamloLeaderBoard db;
    List<dreamloLeaderBoard.Score> punteggi = new List<dreamloLeaderBoard.Score>();

    private void Awake()
    {
        db.AddScore("pippo", 0);

    }
    private void Update()
    {
        if (punteggi.Count==0)
        {
            punteggi = dreamloLeaderBoard.Instance.ToListHighToLow();
            for (int i = 0; i < punteggi.Count; i++)
            {
                GameObject clone = Instantiate(text, content.transform);
                clone.GetComponent<Text>().text = punteggi[i].playerName + " "+ punteggi[i].score.ToString();
            }
        }
       
    }
}

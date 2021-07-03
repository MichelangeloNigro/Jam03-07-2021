using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public Text point;
    public int points;
    public Canvas DeathCanvas;


    private void Start()
    {
        points = 0;
        DeathCanvas.enabled = false;
        point.text = "Punteggio: " + points.ToString();

    }

    public void Update() {
        point.text = "Punteggio: " + points.ToString();
    }

}
